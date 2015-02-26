Imports System.Data.Entity

Public Class ContactsController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDataContext

    Shared Function GetAllContacts() As ContactModel()
        Dim temp = New ApplicationDataContext().Contacts.ToList()
        temp.Sort()
        Return temp.ToArray()
    End Function

    Shared Function GetUpcomingBirthdays(ByVal contacts As ContactModel()) As ContactModel()
        Return contacts.ToList().FindAll(Function(p1) p1.Birthday.DayOfYear >= Date.Now.DayOfYear And p1.Birthday.DayOfYear < Date.Now.DayOfYear + 6).ToArray()
    End Function

    '
    ' GET: /Contacts/

    Function Index() As ActionResult
        Return View(db.Contacts.ToList())
    End Function

    '
    ' GET: /Contacts/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim contactmodel As ContactModel = db.Contacts.Find(id)
        If IsNothing(contactmodel) Then
            Return HttpNotFound()
        End If
        Return View(contactmodel)
    End Function

    '
    ' GET: /Contacts/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Contacts/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal contactmodel As ContactModel) As ActionResult
        If ModelState.IsValid Then
            db.Contacts.Add(contactmodel)
            db.SaveChanges()
            Return New RedirectResult(Url.Action("Index", "Home") + "#" + contactmodel.Id.ToString())
        End If

        Return View(contactmodel)
    End Function


    <HttpPost()> _
    Function Search(ByVal searchText As String) As ActionResult
        Dim contacts As ContactModel() = ContactsController.GetAllContacts().ToList().FindAll(Function(p1) p1.FullName.ToLower().Contains(searchText.ToLower().Trim())).ToArray()
        ViewData("Contacts") = contacts
        ViewData("Addresses") = AddressesController.GetAddresses(contacts)
        ViewData("Phones") = PhonesController.GetPhones(contacts)
        ViewData("Birthdays") = ContactsController.GetUpcomingBirthdays(contacts)
        Return View("~/Views/Home/Index.vbhtml")
        'Return RedirectToAction("Index", "Home")
    End Function

    '
    ' GET: /Contacts/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim contactmodel As ContactModel = db.Contacts.Find(id)
        If IsNothing(contactmodel) Then
            Return HttpNotFound()
        End If
        Return View(contactmodel)
    End Function

    '
    ' POST: /Contacts/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal contactmodel As ContactModel) As ActionResult
        If ModelState.IsValid Then
            db.Entry(contactmodel).State = EntityState.Modified
            db.SaveChanges()
            Return New RedirectResult(Url.Action("Index", "Home") + "#" + contactmodel.Id.ToString())
        End If

        Return View(contactmodel)
    End Function

    '
    ' GET: /Contacts/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim contactmodel As ContactModel = db.Contacts.Find(id)
        If IsNothing(contactmodel) Then
            Return HttpNotFound()
        End If
        Return View(contactmodel)
    End Function

    '
    ' POST: /Contacts/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        Dim contactmodel As ContactModel = db.Contacts.Find(id)
        db.Contacts.Remove(contactmodel)
        db.SaveChanges()
        Return New RedirectResult(Url.Action("Index", "Home") + "#" + contactmodel.Id.ToString())
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class
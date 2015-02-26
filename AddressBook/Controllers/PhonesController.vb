Imports System.Data.Entity

Public Class PhonesController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDataContext

    Shared Function GetPhones(ByVal Contacts As ContactModel()) As PhoneModel()
        Dim phones As New List(Of PhoneModel)
        For Each contact In Contacts
            phones.AddRange(New ApplicationDataContext().Phones.ToList().FindAll(Function(p1) p1.ContactId = contact.Id))
        Next
        Return phones.ToArray()
    End Function

    '
    ' GET: /Phones/

    Function Index() As ActionResult
        Return View(db.Phones.ToList())
    End Function

    '
    ' GET: /Phones/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim phonemodel As PhoneModel = db.Phones.Find(id)
        If IsNothing(phonemodel) Then
            Return HttpNotFound()
        End If
        Return View(phonemodel)
    End Function

    '
    ' GET: /Phones/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Phones/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal phonemodel As PhoneModel) As ActionResult
        If ModelState.IsValid Then
            db.Phones.Add(phonemodel)
            db.SaveChanges()
            Return New RedirectResult(Url.Action("Index", "Home") + "#" + phonemodel.ContactId.ToString())
        End If

        Return View(phonemodel)
    End Function

    '
    ' GET: /Phones/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim phonemodel As PhoneModel = db.Phones.Find(id)
        If IsNothing(phonemodel) Then
            Return HttpNotFound()
        End If
        Return View(phonemodel)
    End Function

    '
    ' POST: /Phones/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal phonemodel As PhoneModel) As ActionResult
        If ModelState.IsValid Then
            db.Entry(phonemodel).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index", "Home")
        End If

        Return View(phonemodel)
    End Function

    '
    ' GET: /Phones/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim phonemodel As PhoneModel = db.Phones.Find(id)
        If IsNothing(phonemodel) Then
            Return HttpNotFound()
        End If
        Return View(phonemodel)
    End Function

    '
    ' POST: /Phones/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        Dim phonemodel As PhoneModel = db.Phones.Find(id)
        db.Phones.Remove(phonemodel)
        db.SaveChanges()
        Return New RedirectResult(Url.Action("Index", "Home") + "#" + phonemodel.ContactId.ToString())
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class
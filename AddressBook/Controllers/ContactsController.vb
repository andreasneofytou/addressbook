Imports System.Data.Entity

Public Class ContactsController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDataContext

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
            Return RedirectToAction("Index")
        End If

        Return View(contactmodel)
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
            Return RedirectToAction("Index")
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
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim contactmodel As ContactModel = db.Contacts.Find(id)
        db.Contacts.Remove(contactmodel)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class
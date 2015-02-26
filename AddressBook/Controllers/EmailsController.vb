Imports System.Data.Entity

Public Class EmailsController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDataContext

    Shared Function GetEmails(ByVal Contacts As ContactModel()) As EmailModel()
        Dim emails As New List(Of EmailModel)
        For Each contact In Contacts
            emails.AddRange(New ApplicationDataContext().Emails.ToList().FindAll(Function(p1) p1.ContactId = contact.Id))
        Next
        Return emails.ToArray()
    End Function

    '
    ' GET: /Emails/

    Function Index() As ActionResult
        Return View(db.Emails.ToList())
    End Function

    '
    ' GET: /Emails/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim emailmodel As EmailModel = db.Emails.Find(id)
        If IsNothing(emailmodel) Then
            Return HttpNotFound()
        End If
        Return View(emailmodel)
    End Function

    '
    ' GET: /Emails/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Emails/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal emailmodel As EmailModel) As ActionResult
        If ModelState.IsValid Then
            db.Emails.Add(emailmodel)
            db.SaveChanges()
            Return New RedirectResult(Url.Action("Index", "Home") + "#" + emailmodel.ContactId.ToString())
        End If

        Return View(emailmodel)
    End Function

    '
    ' GET: /Emails/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim emailmodel As EmailModel = db.Emails.Find(id)
        If IsNothing(emailmodel) Then
            Return HttpNotFound()
        End If
        Return View(emailmodel)
    End Function

    '
    ' POST: /Emails/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal emailmodel As EmailModel) As ActionResult
        If ModelState.IsValid Then
            db.Entry(emailmodel).State = EntityState.Modified
            db.SaveChanges()
            Return New RedirectResult(Url.Action("Index", "Home") + "#" + emailmodel.ContactId.ToString())
        End If

        Return View(emailmodel)
    End Function

    '
    ' GET: /Emails/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim emailmodel As EmailModel = db.Emails.Find(id)
        If IsNothing(emailmodel) Then
            Return HttpNotFound()
        End If
        Return View(emailmodel)
    End Function

    '
    ' POST: /Emails/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As ActionResult
        Dim emailmodel As EmailModel = db.Emails.Find(id)
        db.Emails.Remove(emailmodel)
        db.SaveChanges()
        Return New RedirectResult(Url.Action("Index", "Home") + "#" + emailmodel.ContactId.ToString())
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class
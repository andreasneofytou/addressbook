Imports System.Data.Entity

Public Class CountriesController
    Inherits System.Web.Mvc.Controller

    Private db As New ApplicationDataContext

    '
    ' GET: /Countries/

    Function Index() As ActionResult
        Return View(db.Countries.ToList())
    End Function

    '
    ' GET: /Countries/Details/5

    Function Details(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim countrymodel As CountryModel = db.Countries.Find(id)
        If IsNothing(countrymodel) Then
            Return HttpNotFound()
        End If
        Return View(countrymodel)
    End Function

    '
    ' GET: /Countries/Create

    Function Create() As ActionResult
        Return View()
    End Function

    '
    ' POST: /Countries/Create

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Create(ByVal countrymodel As CountryModel) As ActionResult
        If ModelState.IsValid Then
            db.Countries.Add(countrymodel)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(countrymodel)
    End Function

    '
    ' GET: /Countries/Edit/5

    Function Edit(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim countrymodel As CountryModel = db.Countries.Find(id)
        If IsNothing(countrymodel) Then
            Return HttpNotFound()
        End If
        Return View(countrymodel)
    End Function

    '
    ' POST: /Countries/Edit/5

    <HttpPost()> _
    <ValidateAntiForgeryToken()> _
    Function Edit(ByVal countrymodel As CountryModel) As ActionResult
        If ModelState.IsValid Then
            db.Entry(countrymodel).State = EntityState.Modified
            db.SaveChanges()
            Return RedirectToAction("Index")
        End If

        Return View(countrymodel)
    End Function

    '
    ' GET: /Countries/Delete/5

    Function Delete(Optional ByVal id As Integer = Nothing) As ActionResult
        Dim countrymodel As CountryModel = db.Countries.Find(id)
        If IsNothing(countrymodel) Then
            Return HttpNotFound()
        End If
        Return View(countrymodel)
    End Function

    '
    ' POST: /Countries/Delete/5

    <HttpPost()> _
    <ActionName("Delete")> _
    <ValidateAntiForgeryToken()> _
    Function DeleteConfirmed(ByVal id As Integer) As RedirectToRouteResult
        Dim countrymodel As CountryModel = db.Countries.Find(id)
        db.Countries.Remove(countrymodel)
        db.SaveChanges()
        Return RedirectToAction("Index")
    End Function

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        db.Dispose()
        MyBase.Dispose(disposing)
    End Sub

End Class
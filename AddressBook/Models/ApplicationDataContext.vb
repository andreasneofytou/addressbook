Imports System.Data.Entity

Public Class ApplicationDataContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property Contacts As DbSet(Of ContactModel)
    Public Property Countries As DbSet(Of CountryModel)
    Public Property Emails As DbSet(Of EmailModel)
    Public Property Phones As DbSet(Of PhoneModel)
    Public Property PhoneTypes As DbSet(Of PhoneTypeModel)
    Public Property Towns As DbSet(Of TownModel)
End Class

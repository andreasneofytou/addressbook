Imports System.Data.Entity

Public Class ApplicationDataContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("DefaultConnection")
    End Sub

    Public Property Contacts As DbSet(Of ContactModel)
    Public Property Emails As DbSet(Of EmailModel)
    Public Property Phones As DbSet(Of PhoneModel)
    Public Property Addresses As DbSet(Of AddressModel)
End Class

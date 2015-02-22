Imports System.ComponentModel.DataAnnotations

Public Class Address
    <Key> _
    Public Property Id As Integer
    Public Property Street As String
    Public Property HouseNum As String
    Public Property PostCode As String
    Public Property TownId As String
    Public Property CountryId As String

End Class

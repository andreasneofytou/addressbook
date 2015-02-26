Imports System.ComponentModel.DataAnnotations

Public Class AddressModel
    <Key> _
    Public Property Id As Integer
    Public Property ContactId As Integer
    Public Property Street As String
    Public Property HouseNum As String
    Public Property PostCode As String
    Public Property Town As String
    Public Property Country As String

End Class

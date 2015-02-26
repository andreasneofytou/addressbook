Imports System.ComponentModel.DataAnnotations

Public Class PhoneModel
    <Key> _
    Public Property Id As Integer
    Public Property PhoneTypeId As String
    Public Property ContactId As Integer
    Public Property PhoneNum As Integer
End Class

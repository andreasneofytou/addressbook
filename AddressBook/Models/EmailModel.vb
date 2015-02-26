Imports System.ComponentModel.DataAnnotations

Public Class EmailModel
    <Key> _
    Public Property Id As Integer
    Public Property ContactId As Integer
    Public Property EmailAddress As String
    Public Property EmailType As String

End Class

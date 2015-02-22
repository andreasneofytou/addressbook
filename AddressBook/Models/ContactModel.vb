Imports System.ComponentModel.DataAnnotations

Public Class ContactModel
    <Key> _
    Public Property Id As Integer
    Public Property Name As String
    Public Property Surname As String
    Public Property Birthday As Date

    Public Property FullName() As String
        Get
            Return Name + " " + Surname
        End Get
        Private Set(value As String)
            Dim temp() As String = value.Split(" ")
            If temp.Length > 1 Then
                Name = temp(0)
                Surname = temp(1)
            ElseIf temp.Length = 1 Then
                Name = temp(0)
            End If
        End Set
    End Property

End Class

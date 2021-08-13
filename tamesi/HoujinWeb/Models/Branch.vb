Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Branch
    Public Property HoujinID As String

    Public Property BranchCode As String

    <DisplayName("支店名")>
    <Required(ErrorMessage:="支店名を入力して下さい")>
    Public Property BranchName As String

    Public Property CityName As String

    Public Property Version As Integer

End Class

Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class HoujinTbl
    <DisplayName("法人ID")>
    <Required(ErrorMessage:="法人IDを入力して下さい")>
    Public Property HoujinID As String

    <DisplayName("法人名称")>
    <Required(ErrorMessage:="法人名称を入力して下さい")>
    Public Property HoujinName As String

    Public Property DelFlg As Boolean
End Class

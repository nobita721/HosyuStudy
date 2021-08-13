Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Product
    Public Property HoujinID As String

    <DisplayName("取り扱い商品名")>
    <Required(ErrorMessage:="取り扱い商品名を入力して下さい")>
    Public Property ProductName As String

    <DisplayName("商品詳細")>
    <Required(ErrorMessage:="商品詳細を入力して下さい")>
    Public Property ProductDetail As String

    Public Property DelFlg As Integer

    Public Property UpdateDate As DateTime

    Public Property UpdateUser As String

End Class

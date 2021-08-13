Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Prefecture
    Public Property BranchCode As String

    <DisplayName("都道府県名")>
    <Required(ErrorMessage:="都道府県名を選択して下さい")>
    Public Property PrefectureName As String

    <DisplayName("都市名")>
    <Required(ErrorMessage:="都市名を選択して下さい")>
    Public Property CityName As String

    <DisplayName("地域名")>
    <Required(ErrorMessage:="地域名を選択して下さい")>
    Public Property AreaName As String

End Class

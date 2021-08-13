Imports System.Data.SqlClient

Public Class HoujinTblRepository
    Private con As SqlConnection

    '-----------------------------------------------
    '   SqlConnection                               
    '-----------------------------------------------
    Private Sub connection()
        Dim constr As String = ConfigurationManager.ConnectionStrings("getconn").ToString
        con = New SqlConnection(constr)
    End Sub

    '-----------------------------------------------
    '   法人情報の追加
    '-----------------------------------------------
    Public Function AddHoujinInfo(obj As HoujinModel) As Boolean

        connection()

        Dim strSQL As String = String.Empty
        strSQL &= "INSERT   INTO    HoujinTbl   " & vbCrLf
        strSQL &= "VALUES(  @HoujinID,          " & vbCrLf
        strSQL &= "         @HoujinName,        " & vbCrLf
        strSQL &= "         @DelFlg             " & vbCrLf
        strSQL &= "         )                   " & vbCrLf

        Dim com As New SqlCommand(strSQL, con)
        com.CommandType = CommandType.Text

        'パラメータをセット
        com.Parameters.AddWithValue("@HoujinID", obj.HoujinID)
        com.Parameters.AddWithValue("@HoujinName", obj.HoujinName)
        com.Parameters.AddWithValue("@DelFlg", False)

        con.Open()
        Dim i As Integer = com.ExecuteNonQuery
        con.Close()

        If i >= 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    '-----------------------------------------------
    '   法人情報の一覧
    '-----------------------------------------------
    Public Function GetHoujin(obj As HoujinModel) As List(Of HoujinTbl)

        connection()

        Dim HoujinList As List(Of HoujinTbl) = New List(Of HoujinTbl)
        Dim strSQL As String = String.Empty
        strSQL &= "SELECT   HoujinID,HoujinName" & vbCrLf
        strSQL &= "FROM     HoujinTbl           " & vbCrLf
        strSQL &= "WHERE    HoujinID LIKE '%' + @HOUJINID + '%'" & vbCrLf
        strSQL &= "AND      HoujinName LIKE '%' + @HOUJINNAME + '%'" & vbCrLf
        strSQL &= "ORDER BY HoujinID            " & vbCrLf

        Dim com As New SqlCommand(strSQL, con)
        com.CommandType = CommandType.Text

        'Nothingを空文字に変換できないので仕方ないので関数内で変換することにした
        '汎用的じゃないのでいまいち(文字列以外の検索項目の場合別途関数作成する必要あり)
        'Dim a As String
        'a = Convert.ToString(obj.HoujinID)
        'a = GetInpStr(obj.HoujinID)

        'パラメータをセット
        com.Parameters.AddWithValue("@HOUJINID", GetInpStr(obj.HoujinID))
        com.Parameters.AddWithValue("@HOUJINNAME", GetInpStr(obj.HoujinName))

        Dim da As New SqlDataAdapter(com)
        Dim dt As DataTable = New DataTable

        con.Open()
        da.Fill(dt)
        con.Close()

        '読み込んだ値をListにセット
        For Each dr As DataRow In dt.Rows
            Dim Record As New HoujinTbl
            With Record
                .HoujinID = dr.Item("HoujinID").ToString
                .HoujinName = dr.Item("HoujinName").ToString
            End With
            HoujinList.Add(Record)
        Next

        Return HoujinList

    End Function

    '-----------------------------------------------
    '   法人情報の更新
    '-----------------------------------------------
    Public Function UpdateHoujinInfo(ByVal houjinid As String, obj As HoujinTbl) As Boolean

        connection()

        Dim strSQL As String = String.Empty
        strSQL &= "UPDATE   HoujinTbl                   " & vbCrLf
        strSQL &= "SET      HoujinID = @HOUJINID,       " & vbCrLf
        strSQL &= "         HoujinName = @HOUJINNAME    " & vbCrLf
        strSQL &= "WHERE    HoujinID = @UPDID           " & vbCrLf

        Dim com As New SqlCommand(strSQL, con)
        com.CommandType = CommandType.Text

        'パラメータをセット
        com.Parameters.AddWithValue("@HOUJINID", GetInpStr(obj.HoujinID))
        com.Parameters.AddWithValue("@HOUJINNAME", GetInpStr(obj.HoujinName))
        com.Parameters.AddWithValue("@UPDID", houjinid)

        con.Open()
        Dim i As Integer = com.ExecuteNonQuery
        con.Close()

        If i >= 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    '-----------------------------------------------
    '   法人情報の削除 　
    '-----------------------------------------------
    Public Function DeleteHoujinInfo(houjinid As String) As Boolean

        connection()

        Dim strSQL As String = String.Empty
        strSQL &= "DELETE   HoujinTbl               " & vbCrLf
        strSQL &= "WHERE    HoujinID = @HOUJINID    " & vbCrLf

        Dim com As New SqlCommand(strSQL, con)
        com.CommandType = CommandType.Text

        'パラメータをセット
        com.Parameters.AddWithValue("@HOUJINID", houjinid)

        con.Open()
        Dim i As Integer = com.ExecuteNonQuery
        con.Close()

        If i >= 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    '-----------------------------------------------
    '   法人情報の存在チェック
    '-----------------------------------------------
    Public Function HoujinInfoCheck(obj As HoujinModel) As Boolean

        connection()

        Dim HoujinList As List(Of HoujinTbl) = New List(Of HoujinTbl)
        Dim strSQL As String = String.Empty
        strSQL &= "SELECT   COUNT(*)" & vbCrLf
        strSQL &= "FROM     HoujinTbl           " & vbCrLf
        strSQL &= "WHERE    HoujinID   = @HOUJINID" & vbCrLf
        strSQL &= "OR   HoujinName = @HOUJINNAME" & vbCrLf

        Dim com As New SqlCommand(strSQL, con)
        com.CommandType = CommandType.Text

        'パラメータをセット
        com.Parameters.AddWithValue("@HOUJINID", GetInpStr(obj.HoujinID))
        com.Parameters.AddWithValue("@HOUJINNAME", GetInpStr(obj.HoujinName))

        con.Open()
        Dim cnt As Integer = com.ExecuteScalar
        con.Close()

        If cnt = 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    '-----------------------------------------------
    '   Null変換(文字型)
    '-----------------------------------------------
    Public Function GetInpStr(inp As String) As String
        If inp Is Nothing Then
            inp = ""
        End If

        Return inp
    End Function

End Class

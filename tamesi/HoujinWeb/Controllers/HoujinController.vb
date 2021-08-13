Option Strict Off   '※OnだとViewBagの記述時に遅延バインディングエラー

Imports System.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Controllers
    Public Class HoujinController
        Inherits Controller

        'メニュー左フレーム(全画面共通)
        Function HoujinMenu() As ActionResult
            Return View()
        End Function

        'トップページ右フレーム
        Function HoujinSerch() As ActionResult
            TempData("Display") = "Serch"
            Return View()
        End Function

        '法人検索画面
        Function HoujinSerchDetails() As ActionResult
            '法人検索画面でのみメニューの登録画面リンクを表示するため設定
            TempData("Display") = "SerchDetails"
            Return View()
        End Function

        '法人検索画面からを値を受け取って法人一覧画面を表示
        Function HoujinInfoList(houjinmodel As HoujinModel) As ActionResult

            'ADOで取得
            Dim HoujinRepo As New HoujinTblRepository
            ModelState.Clear()
            Return View(HoujinRepo.GetHoujin(houjinmodel))
        End Function

        '法人情報登録画面表示(※入力項目=空)
        ' GET: Houjin/HoujinInfoCreate
        Function HoujinInfoCreate() As ActionResult
            Return View()
        End Function

        '法人情報登録処理
        ' POST: Houjin/HoujinInfoCreate
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function HoujinInfoCreate(houjinmodel As HoujinModel, houjincreateback As String) As ActionResult

            Try
                Dim HoujinRepo As New HoujinTblRepository

                'ADOで登録
                If ModelState.IsValid Then
                    If HoujinRepo.HoujinInfoCheck(houjinmodel) Then
                        If HoujinRepo.AddHoujinInfo(houjinmodel) Then
                            ViewBag.Message = "データの登録に成功しました"
                        End If
                    Else
                        ViewBag.Message = "法人IDまたは法人名称が存在します"
                        Return View()
                    End If
                End If
                Return RedirectToAction("HoujinSerchDetails")
            Catch
                Return View()
            End Try
        End Function

        '法人編集画面表示(※選択データ)
        ' GET: Houjin/HoujinInfoEdit
        Function HoujinInfoEdit(ByVal houjinid As String, houjinmodel As HoujinModel) As ActionResult
            Dim HoujinRepo As New HoujinTblRepository
            '変更前の法人IDを保持する。(サンプルではこんなことしなくてもID保持されているが、なんでできてるのかよくわからん。。)
            TempData("beforeId") = houjinid
            Return View(HoujinRepo.GetHoujin(houjinmodel).Find(Function(model) model.HoujinID = houjinid))
        End Function

        '法人情報更新処理
        ' POST: Houjin/HoujinInfoEdit
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function HoujinInfoEdit(houjintbl As HoujinTbl) As ActionResult
            Try
                Dim HoujinRepo As New HoujinTblRepository

                '保持していた変更前のIDを設定
                Dim houjinid As String = TempData("beforeId")

                'ADOで登録
                If ModelState.IsValid Then
                    If HoujinRepo.UpdateHoujinInfo(houjinid, houjintbl) Then
                        ViewBag.Message = "データの更新に成功しました"
                    End If
                End If
                Return RedirectToAction("HoujininfoList")
            Catch
                Return View()
            End Try
        End Function

        '法人情報削除画面表示
        ' GET: Houjin/HoujinInfoDelete
        Function HoujinInfoDelete(ByVal houjinid As String, houjinmodel As HoujinModel) As ActionResult
            Dim HoujinRepo As New HoujinTblRepository
            '削除する法人IDを保持する。(サンプルではこんなことしなくてもID保持されているが、なんでできてるのかよくわからん。。)
            TempData("deleteId") = houjinid
            Return View(HoujinRepo.GetHoujin(houjinmodel).Find(Function(model) model.HoujinID = houjinid))
        End Function

        '法人情報削除処理
        ' POST: Houjin/HoujinInfoDelete
        <HttpPost()>
        Function HoujinInfoDelete() As ActionResult
            Try
                Dim HoujinRepo As New HoujinTblRepository

                '保持していた削除するIDを設定
                Dim houjinid As String = TempData("deleteId")

                If HoujinRepo.DeleteHoujinInfo(houjinid) Then
                    ViewBag.AlertMsg = "データを削除しました。"
                End If
                Return RedirectToAction("HoujininfoList")
            Catch
                Return View()
            End Try
        End Function

        '----以下タブ付き画面のコントローラ-----------



    End Class
End Namespace
Option Strict Off   '※OnだとViewBagの記述時に遅延バインディングエラー

Imports System.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace Controllers
    Public Class HoujinTabController
        Inherits Controller

        '法人タブ付き一覧画面
        Function HoujinTabList() As ActionResult
            TempData("Display") = "TabList"
            Return View()
        End Function


        ' GET: HoujinTab/Details/5
        Function Details(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' GET: HoujinTab/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: HoujinTab/Create
        <HttpPost()>
        Function Create(ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add insert logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: HoujinTab/Edit/5
        Function Edit(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: HoujinTab/Edit/5
        <HttpPost()>
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function

        ' GET: HoujinTab/Delete/5
        Function Delete(ByVal id As Integer) As ActionResult
            Return View()
        End Function

        ' POST: HoujinTab/Delete/5
        <HttpPost()>
        Function Delete(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add delete logic here

                Return RedirectToAction("Index")
            Catch
                Return View()
            End Try
        End Function
    End Class
End Namespace
﻿using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Common;
using WebFormBL;

namespace WebFormBL
{
    public class A952_ShouhinBL
    {

        // データ取得
        public List<V_Shouhin> GetShouhinSelect(A950_CommonPropertyBL cb, bool inpchk = false)
        {
            try
            {
                // クエリ作成
                String queryString = String.Empty;
                queryString = "SELECT ShouhinId, HistNo, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM V_Shouhin";

                // Where条件
                String queryWhereAddString = String.Empty;
                if (!inpchk)
                {
                    // 存在チェック以外
                    queryWhereAddString = " WHERE Del_Flg = 0";
                }
                if (cb.ShouhinId != String.Empty)
                {
                    // 商品ID条件設定
                    if (queryWhereAddString == String.Empty)
                    {
                        queryWhereAddString = queryWhereAddString + " WHERE ShouhinId LIKE @ShouhinId";
                    }
                    else
                    {
                        queryWhereAddString = queryWhereAddString + " AND ShouhinId LIKE @ShouhinId";
                    }
                }
                if (cb.ShouhinName != String.Empty)
                {
                    // 商品名条件設定
                    if (queryWhereAddString == String.Empty)
                    {
                        queryWhereAddString = queryWhereAddString + " WHERE ShouhinName LIKE @ShouhinName";
                    }
                    else
                    {
                        queryWhereAddString = queryWhereAddString + " AND ShouhinName LIKE @ShouhinName";
                    }
                }
                if (cb.ShouhinDetail != String.Empty)
                {
                    // 商品詳細条件設定
                    if (queryWhereAddString == String.Empty)
                    {
                        queryWhereAddString = queryWhereAddString + " WHERE ShouhinDetail LIKE @ShouhinDetail";
                    }
                    else
                    {
                        queryWhereAddString = queryWhereAddString + " AND ShouhinDetail LIKE @ShouhinDetail";
                    }
                }

                // 商品IDで昇順
                String queryOrderByString = " ORDER BY ShouhinId";

                queryString = queryString + queryWhereAddString + queryOrderByString;

                // 接続文字列取得
                String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

                // 取得結果を格納するデータテーブルを生成
                DataTable dt = new DataTable();

                //接続情報を使ってコネクションを生成
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //SQL文とコネクションを設定
                    using (SqlCommand cmd = new SqlCommand(queryString, conn))
                    {
                        // パラメータ設定
                        cmd.Parameters.AddWithValue("@ShouhinId", "%" + cb.ShouhinId + "%");
                        cmd.Parameters.AddWithValue("@ShouhinName", "%" + cb.ShouhinName + "%");
                        cmd.Parameters.AddWithValue("@ShouhinDetail", "%" + cb.ShouhinDetail + "%");

                        // データアダプターにsqlコマンドを設定
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;

                        // クエリ実行、データテーブルに設定
                        adapter.Fill(dt);
                    }
                }

                // 取得用クラスをリスト型で生成
                List<V_Shouhin> list = new List<V_Shouhin>();

                //データテーブルからlistに変換(Linq)
                list = (from DataRow dr in dt.Rows
                        select new V_Shouhin()
                        {
                            ShouhinId = dr["ShouhinId"].ToString(),
                            HistNo = int.Parse(dr["HistNo"].ToString()),
                            ShouhinName = dr["ShouhinName"].ToString(),
                            ShouhinDetail = dr["ShouhinDetail"].ToString(),
                            ZaikoSuu = int.Parse(dr["ZaikoSuu"].ToString()),
                            UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString())
                        }).ToList();

                return list;
            }
            catch(Exception ex)
            {
                // エラー発生箇所を設定
                errorinfoBase.errlocation = "【BL】データ取得処理例外情報";

                // exをスローしなくても、UIに投げられたタイミングで実際の発生行は、消えちゃうので
                // このタイミングのスタックトレースの情報も共通クラスに格納することにした。
                // throwだけだと発生行以外の内容が二重で出力されるので、throw exのままあえて破棄する
                errorinfoBase.innerStackTrace = ex.StackTrace;
                throw ex;
            }
        }

        // データ登録(商品登録画面、商品詳細画面共通)
        public void ShouhinInsert(A950_CommonPropertyBL cb, bool ins = false)
        {
            try
            {
                // 接続文字列取得
                String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

                // 接続情報を使ってコネクションを生成
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    // クエリ作成
                    DateTime dt = DateTime.Now;
                    String updTime = dt.ToString("yyyy/MM/dd HH:mm:ss.fff");
                    SqlCommand cmd = new SqlCommand("INSERT INTO V_Shouhin (ShouhinId, HistNo, ShouhinName, ShouhinDetail, ZaikoSuu, " +
                                                    "UpdateDate, Del_Flg) VALUES (" +
                                                    "@ShouhinId, @HistNo, @ShouhinName, @ShouhinDetail, @ZaikoSuu, " +
                                                    "'" + updTime + "', " + 0 + ")", conn);

                    // パラメータ設定
                    cmd.Parameters.AddWithValue("@ShouhinId", cb.ShouhinId);
                    cmd.Parameters.AddWithValue("@HistNo", cb.HistNo);
                    cmd.Parameters.AddWithValue("@ShouhinName", cb.ShouhinName);
                    cmd.Parameters.AddWithValue("@ShouhinDetail", cb.ShouhinDetail);
                    if (ins)
                    {
                        // 新規登録の場合
                        cmd.Parameters.AddWithValue("@ZaikoSuu", cb.NyuukaSuu);
                    }
                    else 
                    {
                        // 更新の場合
                        cmd.Parameters.AddWithValue("@ZaikoSuu", cb.ZaikoSuu);
                    }
                

                    // DB接続、クエリ実行、DB切断
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // エラー発生箇所を設定
                errorinfoBase.errlocation = "【BL】データ登録処理例外情報";
                errorinfoBase.innerStackTrace = ex.StackTrace;
                throw ex;
            }
        }

        // データ削除(商品詳細画面、商品削除画面共通)
        public void ShouhinDelete(A950_CommonPropertyBL cb)
        {
            try
            {
                // 接続文字列取得
                String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

                // 接続情報を使ってコネクションを生成
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    // クエリ作成
                    DateTime dt = DateTime.Now;
                    String updTime = dt.ToString("yyyy/MM/dd HH:mm:ss.fff");
                    SqlCommand cmd = new SqlCommand("UPDATE V_Shouhin SET " +
                                                    "Del_Flg = 1, " +
                                                    "UpdateDate = '" + updTime + "'" +
                                                    "Where ShouhinId = @ShouhinId " +
                                                    "AND HistNo = @HistNo", conn);

                    // パラメータ設定
                    cmd.Parameters.AddWithValue("@ShouhinId", cb.ShouhinId);
                    cmd.Parameters.AddWithValue("@HistNo", cb.HistNo);

                    // DB接続、クエリ実行、DB切断
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                // エラー発生箇所を設定
                errorinfoBase.errlocation = "【BL】データ削除処理例外情報";
                errorinfoBase.innerStackTrace = ex.StackTrace;
                throw ex;
            }
        }
    }
}
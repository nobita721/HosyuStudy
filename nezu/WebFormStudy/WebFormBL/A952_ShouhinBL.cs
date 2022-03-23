using System;
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
        public List<V_Shouhin> GetShouhinSelect(A950_CommonPropertyBL cb)
        {
            try
            {
                // クエリ作成
                String queryString = String.Empty;
                queryString = "SELECT ShouhinId, HistNo, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM V_Shouhin WHERE Del_Flg = 0";

                // Where条件
                String queryWhereAddString = String.Empty;
                if (cb.ShouhinId != String.Empty)
                {
                    // 商品ID条件設定
                    queryWhereAddString = " AND (ShouhinId LIKE @ShouhinId";
                }
                if (cb.ShouhinName != String.Empty)
                {
                    // 商品名条件設定
                    if (queryWhereAddString == String.Empty)
                    {
                        queryWhereAddString = queryWhereAddString + " AND (ShouhinName LIKE @ShouhinName";
                    }
                    else
                    {
                        queryWhereAddString = queryWhereAddString + " OR ShouhinName LIKE @ShouhinName";
                    }
                }
                if (cb.ShouhinDetail != String.Empty)
                {
                    // 商品詳細条件設定
                    if (queryWhereAddString == String.Empty)
                    {
                        queryWhereAddString = queryWhereAddString + " AND (ShouhinDetail LIKE @ShouhinDetail";
                    }
                    else
                    {
                        queryWhereAddString = queryWhereAddString + " OR ShouhinDetail LIKE @ShouhinDetail";
                    }
                }
                if (queryWhereAddString != String.Empty) 
                {
                    queryWhereAddString = queryWhereAddString + ")";
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
            catch (Exception ex)
            {
                // エラー発生箇所を設定
                errorinfoBase.errlocation = "【BL】データ取得処理例外情報";
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
                throw ex;
            }
        }
    }
}
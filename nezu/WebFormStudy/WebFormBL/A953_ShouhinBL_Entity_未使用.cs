using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Data.Entity;
using WebFormBL.Models;

namespace WebFormBL
{
    public class A953_ShouhinBL_Entity_未使用
    {
        // データ取得
        public List<V_Shouhin> GetShouhinSelect(A950_CommonPropertyBL cb)
        {

            // Entity SQL文字列の設定
            String queryString = String.Empty;
            queryString = "SELECT ShouhinId, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM T_Shouhin WHERE Del_Flg = 0";

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

            //// Enttityframeworkで取得
            //using (var context = new T_ShouhinContext())
            //{


            //    // SQL発行
            //    var shouhin = context.Database.SqlQuery<T_Shouhin>(queryString,
            //                                        new SqlParameter("@ShouhinId", "%" + cb.ShouhinId + "%"),
            //                                        new SqlParameter("@ShouhinName", "%" + cb.ShouhinName + "%"),
            //                                        new SqlParameter("@ShouhinDetail", "%" + cb.ShouhinDetail + "%"));

            //    // ここでエラー
            //    // エラー内容は以下
            //    // System.InvalidOperationException： 'T_Shouhin'の 'ZaikoSuu'プロパティを
            //    // 'System.Byte'値に設定できませんでした。このプロパティは、タイプ
            //    // 'System.Int32'のnull以外の値に設定する必要があります。 '
            //    //return shouhin.ToList();
            //}


            // 一旦コメントアウト
            // Datasetで返すやつ
            // 接続文字列取得
            String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

            // 取得結果を格納するデータセットを生成
            //DataSet ds = new DataSet();
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

                    // クエリ実行、データセットに設定
                    //adapter.Fill(ds);
                    adapter.Fill(dt);
                }
            }

            List<V_Shouhin> list = new List<V_Shouhin>();

            //// データテーブルからlistに変換(Generic Methodを使った処理(Refrection))
            //A951_Common cmn = new A951_Common();
            //list = cmn.ConvertDataTable<T_Shouhin>(dt);

            //データテーブルからlistに変換(Linq)
            list = (from DataRow dr in dt.Rows
                    select new V_Shouhin()
                    {
                        ShouhinId = dr["ShouhinId"].ToString(),
                        ShouhinName = dr["ShouhinName"].ToString(),
                        ShouhinDetail = dr["ShouhinDetail"].ToString(),
                        ZaikoSuu = int.Parse(dr["ZaikoSuu"].ToString()),
                        UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString())
                    }).ToList();

            return list;
        }
    }
}

using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using WebFormBL;

namespace WebFormBL
{
    public class A952_ShouhinBL
    {

        // データ取得
        public DataSet GetShouhinSelect(A950_CommonPropertyBL cb)
        {

            // クエリ作成
            String queryString = String.Empty;
            queryString = "SELECT ShouhinId, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM T_Shouhin WHERE Del_Flg = 0";

            // Where条件
            String queryWhereAddString = String.Empty;
            if (cb.ShouhinId != String.Empty)
            {
                // 商品ID条件設定
                queryWhereAddString = " AND ShouhinId LIKE @ShouhinId";
            }
            if (cb.ShouhinName != String.Empty)
            {
                // 商品名条件設定
                if (queryWhereAddString == String.Empty)
                {
                    queryWhereAddString = queryWhereAddString + " AND ShouhinName LIKE @ShouhinName";
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
                    queryWhereAddString = queryWhereAddString + " AND ShouhinDetail LIKE @ShouhinDetail";
                }
                else
                {
                    queryWhereAddString = queryWhereAddString + " OR ShouhinDetail LIKE @ShouhinDetail";
                }
            }

            // 商品IDで昇順
            String queryOrderByString = " ORDER BY ShouhinId";

            queryString = queryString + queryWhereAddString + queryOrderByString;

            // 接続文字列取得
            String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

            // 取得結果を格納するデータセットを生成
            DataSet ds = new DataSet();

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
                    adapter.Fill(ds);
                }
            }

            return ds;

        }

        // データ登録
        public void ShouhinInsert(A950_CommonPropertyBL cb)
        {

            // 接続文字列取得
            String connectionString = ConfigurationManager.ConnectionStrings["HosyuStudy"].ConnectionString;

            //接続情報を使ってコネクションを生成
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                // クエリ作成
                DateTime dt = DateTime.Now;
                String updTime = dt.ToString("yyyy/MM/dd HH:mm:ss.fff");
                SqlCommand cmd = new SqlCommand("INSERT INTO T_Shouhin (ShouhinId, ShouhinName, ShouhinDetail, ZaikoSuu, " +
                                                "UpdateDate, Del_Flg) VALUES (" +
                                                "@ShouhinId, @ShouhinName, @ShouhinDetail, @ZaikoSuu, " +
                                                "'" + updTime + "', " + 0 + ")", conn);

                // パラメータ設定
                cmd.Parameters.AddWithValue("@ShouhinId", cb.ShouhinId);
                cmd.Parameters.AddWithValue("@ShouhinName", cb.ShouhinName);
                cmd.Parameters.AddWithValue("@ShouhinDetail", cb.ShouhinDetail);
                cmd.Parameters.AddWithValue("@ZaikoSuu", cb.NyuukaSuu);

                // DB接続、クエリ実行、DB切断
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}
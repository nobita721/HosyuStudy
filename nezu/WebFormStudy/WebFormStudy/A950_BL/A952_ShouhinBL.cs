using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebFormStudy.A950_BL
{
    public class A952_ShouhinBL
    {
        public String GetShouhinSelect(A950_CommonBL cb)
        {

            // クエリ作成
            // sqlパラメータは、まだやっていない
            String queryString = String.Empty;
            queryString = "SELECT ShouhinId, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM T_Shouhin ";

            String queryWhereString = String.Empty;
            if (cb.ShouhinId != String.Empty)
            {
                // 商品ID条件設定
                queryWhereString = "WHERE ShouhinId LIKE '%" + cb.ShouhinId + "%'";
            }
            if (cb.ShouhinName != String.Empty)
            {
                // 商品名条件設定
                if (queryWhereString == String.Empty) 
                {
                    queryWhereString = queryWhereString + "WHERE ShouhinName LIKE '%" + cb.ShouhinName + "%'";
                }
                else 
                {
                    queryWhereString = queryWhereString + " OR ShouhinName LIKE '%" + cb.ShouhinName + "%'";
                }
            }
            if (cb.ShouhinDetail != String.Empty)
            {
                // 商品詳細条件設定
                if (queryWhereString == String.Empty)
                {
                    queryWhereString = queryWhereString + "WHERE ShouhinDetail LIKE '%" + cb.ShouhinDetail + "%'";
                }
                else
                {
                    queryWhereString = queryWhereString + " OR ShouhinDetail LIKE '%" + cb.ShouhinDetail + "%'";
                }
            }


            //queryString = queryString + "WHERE ShouhinId LIKE '%" + cb.ShouhinId + "%'";
            //queryString = queryString + " AND ShouhinName LIKE '%" + cb.ShouhinName + "%'";
            //queryString = queryString + " AND ShouhinDetail LIKE '%" + cb.ShouhinDetail + "%'";
            queryString = queryString + queryWhereString;
            return queryString.ToString();
        }
    }
}
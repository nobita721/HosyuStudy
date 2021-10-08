using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace WebFormStudy.A950_BL
{
    public class A952_ShouhinBL
    {
        public void SetShouhinSelect(A950_CommonBL cb, SqlDataSource sds)
        {

            // クエリ作成
            // 課題：sqlインジェクション対策は、まだやっていない
            String queryString = String.Empty;
            queryString = "SELECT ShouhinId, ShouhinName, ShouhinDetail, ZaikoSuu, UpdateDate FROM T_Shouhin ";

            String queryWhereString = String.Empty;
            if (cb.ShouhinId != String.Empty)
            {
                // 商品ID条件設定
                queryWhereString = "WHERE ShouhinId LIKE '%" + cb.ShouhinId + "%'";
                //queryWhereString = "WHERE ShouhinId LIKE '%@ShouhinId%'";
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

            sds.SelectCommand = queryString + queryWhereString;

        }
    }
}
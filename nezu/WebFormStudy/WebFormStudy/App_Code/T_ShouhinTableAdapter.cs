using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using WebFormStudy.A950_BL;

namespace ShouhinDataSetTableAdapters
{
    public partial class shouhinTableAdapter
    {
        // SELECTメソッド（取得用のメソッド）であることを宣言（2）
        // →結局つかわない。オブジェクトデータテーブルは、後でまるごと消す
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public ShouhinDataSet.T_ShouhinDataTable GetShouhinInfo(A950_CommonBL cb)
        {
            //// SqlCommandオブジェクトを生成
            //SqlCommand comm = this.Connection.CreateCommand();



            // 型付きデータセットを生成
            ShouhinDataSet ds = new ShouhinDataSet();

            // 型付きデータテーブル（bookDataTable）に結果を流し込み（3）
            //this.Adapter.SelectCommand = comm;
            //this.Adapter.Fill(ds.T_Shouhin);
            return ds.T_Shouhin;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace WebFormBL
{
    public class A950_CommonPropertyBL
    {
        private string m_displayid;
        private string m_displayname;
        private string m_menunameleft;
        private bool m_menulefthide;
        private bool m_menuleftenab;
        private Color m_menuleftforecolor;
        private string m_menunameright;
        private bool m_menurighthide;
        private bool m_menurightenab;
        private Color m_menurightforecolor;
        private string m_mode;
        private string m_url;
        private string m_shouhinid;
        private int m_histno;
        private string m_shouhinname;
        private string m_shouhindetail;
        private int m_nyuukasuu;
        private int m_zaikosuu;

        // 画面ID
        public string DisplayId
        {
            get { return m_displayid; }
            set { m_displayid = value; }
        }
        // 画面名
        public string DisplayName
        {
            get { return m_displayname; }
            set { m_displayname = value; }
        }
        // メニュー名(左)
        public string MenuNameLeft
        {
            get { return m_menunameleft; }
            set { m_menunameleft = value; }
        }
        // メニュー表示非表示(左)
        public bool MenuLeftHide
        {
            get { return m_menulefthide; }
            set { m_menulefthide = value; }
        }
        // メニュー活性非活性(左)
        public bool MenuLeftEnab
        {
            get { return m_menuleftenab; }
            set { m_menuleftenab = value; }
        }
        // メニュー文字色(左)
        public Color MenuLeftForeColor
        {
            get { return m_menuleftforecolor; }
            set { m_menuleftforecolor = value; }
        }
        // メニュー名(右)
        public string MenuNameRight
        {
            get { return m_menunameright; }
            set { m_menunameright = value; }
        }
        // メニュー表示非表示(右)
        public bool MenuRightHide
        {
            get { return m_menurighthide; }
            set { m_menurighthide = value; }
        }
        // メニュー活性非活性(右)
        public bool MenuRightEnab
        {
            get { return m_menurightenab; }
            set { m_menurightenab = value; }
        }
        // メニュー文字色(右)
        public Color MenuRightForeColor
        {
            get { return m_menurightforecolor; }
            set { m_menurightforecolor = value; }
        }
        // 編集参照モード
        public string Mode
        {
            get { return m_mode; }
            set { m_mode = value; }
        }
        // 遷移先URL
        public string Url
        {
            get { return m_url; }
            set { m_url = value; }
        }
        // 商品ID
        public string ShouhinId
        {
            get { return m_shouhinid; }
            set { m_shouhinid = value; }
        }
        // 履歴No
        public int HistNo
        {
            get { return m_histno; }
            set { m_histno = value; }
        }
        // 商品名
        public string ShouhinName
        {
            get { return m_shouhinname; }
            set { m_shouhinname = value; }
        }
        // 商品詳細
        public string ShouhinDetail
        {
            get { return m_shouhindetail; }
            set { m_shouhindetail = value; }
        }
        // 入荷数
        public int NyuukaSuu
        {
            get { return m_nyuukasuu; }
            set { m_nyuukasuu = value; }
        }
        // 在庫数
        public int ZaikoSuu
        {
            get { return m_zaikosuu; }
            set { m_zaikosuu = value; }
        }
    }
}
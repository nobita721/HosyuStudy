using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormBL
{
    public class A950_CommonPropertyBL
    {
        private string m_displayid;
        private string m_displayname;
        private string m_menunameleft;
        private string m_menunameright;
        private bool m_menulefthide;
        private bool m_menurighthide;
        private bool m_menuleftenab;
        private bool m_menurightenab;
        private string m_url;
        private string m_shouhinid;
        private string m_shouhinname;
        private string m_shouhindetail;
        private int m_nyuukasuu;
        private int m_zaikosuu;

        public string DisplayId
        {
            get { return m_displayid; }
            set { m_displayid = value; }
        }
        public string DisplayName
        {
            get { return m_displayname; }
            set { m_displayname = value; }
        }
        public string MenuNameLeft
        {
            get { return m_menunameleft; }
            set { m_menunameleft = value; }
        }
        public string MenuNameRight
        {
            get { return m_menunameright; }
            set { m_menunameright = value; }
        }
        public bool MenuLeftHide
        {
            get { return m_menulefthide; }
            set { m_menulefthide = value; }
        }
        public bool MenuRightHide
        {
            get { return m_menurighthide; }
            set { m_menurighthide = value; }
        }
        public bool MenuLeftEnab
        {
            get { return m_menuleftenab; }
            set { m_menuleftenab = value; }
        }
        public bool MenuRightEnab
        {
            get { return m_menurightenab; }
            set { m_menurightenab = value; }
        }
        public string Url
        {
            get { return m_url; }
            set { m_url = value; }
        }
        public string ShouhinId
        {
            get { return m_shouhinid; }
            set { m_shouhinid = value; }
        }
        public string ShouhinName
        {
            get { return m_shouhinname; }
            set { m_shouhinname = value; }
        }
        public string ShouhinDetail
        {
            get { return m_shouhindetail; }
            set { m_shouhindetail = value; }
        }
        public int NyuukaSuu
        {
            get { return m_nyuukasuu; }
            set { m_nyuukasuu = value; }
        }
        public int ZaikoSuu
        {
            get { return m_zaikosuu; }
            set { m_zaikosuu = value; }
        }
    }
}
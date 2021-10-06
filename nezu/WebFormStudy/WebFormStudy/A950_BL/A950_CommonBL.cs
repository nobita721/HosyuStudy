using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormStudy.A950_BL
{
    public class A950_CommonBL
    {
        private string m_shouhinid;
        private string m_shouhinname;
        private string m_shouhindetail;


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
    }
}
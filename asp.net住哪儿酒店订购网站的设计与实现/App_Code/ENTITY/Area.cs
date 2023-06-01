using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///Area 的摘要说明：地区实体
    /// </summary>

    public class Area
    {
        /*地区id*/
        private int _areaId;
        public int areaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        /*地区名称*/
        private string _areanName;
        public string areanName
        {
            get { return _areanName; }
            set { _areanName = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void menu_MenuItemDataBound(object sender, MenuEventArgs e)
        {
            //if (SiteMap.CurrentNode != null)
            //{
            //    if (e.Item.Text == SiteMap.CurrentNode.Title)
            //    {
            //        e.Item.Parent.Selected = true;
            //    }
            //    else
            //    {
            //        e.Item.Selected = true;
            //    }
            //}
        }
    }
}
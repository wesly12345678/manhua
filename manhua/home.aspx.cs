using System;
using System.Web.UI.WebControls;

namespace manhua
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //For the numbering the list
            //int i = 1;
            //foreach (var li in lvPopular.Items)
            //{
            //    Label label = (Label)li.FindControl("lblNumber");
            //    label.Text = i.ToString();
            //    i++;
            //}
        }

        protected void ldsPopularComic_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Arguments.MaximumRows = 5;
        }

        protected void LinqDataSource1_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Arguments.MaximumRows = 5;
        }

        protected void LinqDataSource2_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            e.Arguments.MaximumRows = 5;
        }
    }
}
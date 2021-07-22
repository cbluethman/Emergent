using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Emergent
{
    public partial class _Default : Page
    {
        protected global::System.Web.UI.WebControls.TextBox txtVersion;
        protected global::System.Web.UI.WebControls.Button btnSubmit;
        protected global::System.Web.UI.WebControls.GridView dgData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var lstAll = (List<App_Code.Software>)Emergent.App_Code.SoftwareManager.GetAllSoftware();
            var lstPart = new List<App_Code.Software>();
            DataTable table = new DataTable();

            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Version", typeof(string));

            foreach (var item in lstAll)
            {
                if (versionCompare(txtVersion.Text, item.Version) < 0)
                {
                    lstPart.Add(item);
                }
            }

            foreach (var s in lstPart)
            {
                DataRow row = table.NewRow();
                row["Name"] = s.Name;
                row["Version"] = s.Version;
                table.Rows.Add(row);
            }

            DataSet ds = new DataSet();

            ds.Tables.Add(table);
            dgData.DataSource = ds;
            dgData.DataBind();
        }

        private int versionCompare(string v1, string v2)
        {
            // vnum stores each numeric
            // part of version
            int vnum1 = 0, vnum2 = 0;

            // loop until both string are
            // processed
            for (int i = 0, j = 0; (i < v1.Length
                || j < v2.Length);)
            {
                // storing numeric part of
                // version 1 in vnum1
                while (i < v1.Length && v1[i] != '.')
                {
                    vnum1 = vnum1 * 10 + (v1[i] - '0');
                    i++;
                }

                // storing numeric part of
                // version 2 in vnum2
                while (j < v2.Length && v2[j] != '.')
                {
                    vnum2 = vnum2 * 10 + (v2[j] - '0');
                    j++;
                }

                if (vnum1 > vnum2)
                {
                    return 1;
                }

                if (vnum2 > vnum1)
                {
                    return -1;
                }

                // if equal, reset variables and
                // go for next numeric part
                vnum1 = vnum2 = 0;
                i++;
                j++;
            }

            return 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Menu : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            
            lblDate.Text = DateTime.Now.ToLongDateString();
            if (Session["login"] != null)
            {
                Connexion cn = new Connexion(Server);
                DataTable dt = cn.extraire(string.Format("select prenom,nom from Client where login={0}", Session["login"].ToString()));
                lblNom.Text = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString();
                Menu1.Items.Add(new MenuItem("Historique", "Historique", null, "Historique.aspx"));
                Menu1.Items.Add(new MenuItem("Logout", "Logout", null, "Logout.aspx"));
            }
            else
                Menu1.Items.Add(new MenuItem("Login", "Login", null, "Login.aspx"));
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    Connexion cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
            Response.Redirect("Home.aspx");

        if(!IsPostBack)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["pwd"] != null)
            {
                txtLogin.Text = Request.Cookies["login"].Value;
                txtPwd.Text = Request.Cookies["pwd"].Value;//cookie works fine but the textbox can't get it
                                                           //because it's on password mode
            }
        }
        MenuTab Menu = new MenuTab();
        Menu.Afficher(tbMenu,Session["login"]);
        cn = new Connexion(Server);
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable dt = cn.extraire("select login,password from Client" +
                                   " where login=" + txtLogin.Text + " and password='" + txtPwd.Text + "'");
        if (dt.Rows.Count == 1)
        {
            Session["login"] = txtLogin.Text;
            if (chkMemo.Checked)
            {
                Response.Cookies["login"].Value = txtLogin.Text.ToString();
                Response.Cookies["pwd"].Value = txtPwd.Text.ToString();
                Response.Cookies["login"].Expires = DateTime.Now.AddMonths(1);
                Response.Cookies["pwd"].Expires = DateTime.Now.AddMonths(1);
            }
            Response.Redirect("Home.aspx");
        }
        else
        Response.Write("<script>alert('Login ou Mot de passe Incorrects')</script>");           
    }
}
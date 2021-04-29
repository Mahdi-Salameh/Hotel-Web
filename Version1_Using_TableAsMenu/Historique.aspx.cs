using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Historique : System.Web.UI.Page
{
    Connexion cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null)
            Response.Redirect("Login.aspx");

        MenuTab Menu = new MenuTab();
        Menu.Afficher(tbMenu, Session["login"]);

        cn = new Connexion(Server);
        DataTable dt = cn.extraire("select numeroChambre as Numero,Format(dateArrivee,'dd/MM/yyyy') as [Date d'arrivee]," +
                                   "Format(dateDepart,'dd/MM/yyyy') as [Date de depart],totale as Totale from Reservation" +
                                   " where loginClient="+Session["login"] +" order by dateArrivee desc");
        grvHistorique.DataSource = dt;
        grvHistorique.DataBind();
        lblCaption.Visible = true;
    }
}
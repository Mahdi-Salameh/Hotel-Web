using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Reservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] == null)
            Response.Redirect("Login.aspx");
        if (Request.QueryString["Numero"] == null || Session["dateArrivee"] == null || Session["dateDepart"] == null || Session["nbJours"] == null)
            Response.Redirect("Home.aspx");

        Connexion cn = new Connexion(Server);
        DataTable dt = cn.extraire("select tarif from Chambre,Categorie" +
                                   " where id=idCategorie and numero=" + Request.QueryString["Numero"]);
        int totale = int.Parse(dt.Rows[0].ItemArray[0].ToString()) * (int)Session["nbJours"];

        //à ce niveau toutes les données sont vraies 
        cn.modifier(string.Format("insert into Reservation values({0},{1},#{2}#,#{3}#,{4})",
                    Request.QueryString["Numero"], Session["login"].ToString(), Session["dateArrivee"].ToString()
                    , Session["dateDepart"].ToString(), totale.ToString()));

        //effacer les données de la session pour éviter les réservations inappropriées
        //peut etre l'utilisateur a ecrit manuellement dans URL le numero de chambre 
        Session["dateArrivee"] = null;
        Session["dateDepart"] = null;
        Session["nbJours"] = null;
        Response.Redirect("Historique.aspx");
    }
}
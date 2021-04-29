using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Home : System.Web.UI.Page
{
    Connexion cn;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new Connexion(Server);
        if (!IsPostBack)
        {
            DataTable dt = cn.extraire("select id,libelle from Categorie");
            drpCategorie.DataSource = dt;
            drpCategorie.DataTextField = "libelle";
            drpCategorie.DataValueField = "id";
            drpCategorie.DataBind();
            drpCategorie.Items.Insert(0, new ListItem("Tout", "0"));
        }
    }

    protected void drpCategorie_SelectedIndexChanged(object sender, EventArgs e)
    {
        //autopostback = true
        Page.Validate();
        if (Page.IsValid)
            afficherGrv();
        else
        {
            grvReservation.DataSource = null;
            grvReservation.DataBind();
            lblCaption.Visible = false;
        }
    }
    protected void btnRechercher_Click(object sender, EventArgs e)
    {
        //je mets CausesValidation=false car si le gridview a etait deja afficher
        //et l'utilisateur change les donnes et fait un erreur grvReservation reste affiche avec l'ancinenne donnes
        //donc avec cette methode je peut effacer le grv s'il ya un erreur
        Page.Validate();
        if (Page.IsValid)
            afficherGrv();
        else
        {
            grvReservation.DataSource = null;
            grvReservation.DataBind();
            lblCaption.Visible = false;
        }
    }


    protected void afficherGrv()
    {
        int nbJours;
        try
        {
            string[] tabA = txtArrivee.Text.Split('/');
            string[] tabD = txtDepart.Text.Split('/');
            DateTime Arrivee = new DateTime(int.Parse(tabA[2]), int.Parse(tabA[1]), int.Parse(tabA[0]));
            DateTime Depart = new DateTime(int.Parse(tabD[2]), int.Parse(tabD[1]), int.Parse(tabD[0]));
            TimeSpan diff = Depart.Subtract(Arrivee);
            if (diff.TotalDays == 0)
                nbJours = 1;
            else
                nbJours = (int)diff.TotalDays;

            if (nbJours <= 0) throw new Exception();
            if (Session["login"] != null)
            {
                Session["nbJours"] = nbJours;
                Session["dateArrivee"] = Arrivee;
                Session["dateDepart"] = Depart;
            }


            string temp = "";
            if (drpCategorie.SelectedIndex > 0)
                temp = "and id=+" + drpCategorie.SelectedValue;

            DataTable dt = cn.extraire(string.Format("select numero as Numero, etage as Etage, libelle as Type, tarif as Tarif" +
                                " from Chambre, Categorie" +
                                " where id = idCategorie {0}" +
                                " and numero not in (select numeroChambre from Reservation, Chambre" +
                                                    " where numeroChambre = numero" +
                                                    " and(  (#{1}# BETWEEN dateArrivee and dateDepart)" +
                                                        " or(#{2}# BETWEEN dateArrivee and dateDepart)" +
                                                        " or(#{3}# < dateArrivee and #{4}# > dateDepart)" +
                                                        ")" +
                                                    ") order by numero", temp, Arrivee, Depart, Arrivee, Depart));
            grvReservation.DataSource = dt;
            grvReservation.DataBind();
            lblCaption.Visible = true;
        }
        catch (ArgumentOutOfRangeException ex1)
        {
            grvReservation.DataSource = null;
            grvReservation.DataBind();
            lblCaption.Visible = false;
            Response.Write("<script>alert('Dates Incorrects')</script>");
        }
        catch (Exception ex2)
        {
            grvReservation.DataSource = null;
            grvReservation.DataBind();
            lblCaption.Visible = false;
            Response.Write("<script>alert(\"Date d'Arrive > Date de depart\")</script>");
        }
    }

    protected void grvReservation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["login"] == null)
            Response.Redirect("Login.aspx");
        //else
        Response.Redirect("Reservation.aspx?Numero=" + grvReservation.SelectedRow.Cells[1].Text);
    }
}
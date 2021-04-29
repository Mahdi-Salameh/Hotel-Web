using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuTab Menu = new MenuTab();//J'ai utilisé cette méthode pour avoir les mêmes résultats de question
        Menu.Afficher(tbMenu,Session["login"]);//Pour afficher la menu et tester si l'utilisateur est connecte ou non
    }
}
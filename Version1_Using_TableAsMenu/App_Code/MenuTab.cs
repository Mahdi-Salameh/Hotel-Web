using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;//pour definir Controle Table

//J'ai utilisé cette méthode pour avoir les mêmes résultats de question
public class MenuTab
{
    private TableRow R;
    private TableCell C1,C2,C3;
    public MenuTab()
    {
        R = new TableRow();
        C1 = new TableCell();
        C2 = new TableCell();
        C3 = new TableCell();
        R.HorizontalAlign = HorizontalAlign.Center;
    }

    public void Afficher(Table Tab, object sessionLogin)
    { 
        R.Cells.AddRange(new TableCell[] {C1,C2,C3});
        Tab.Rows.Add(R);
        C1.Text = "<a href = 'Home.aspx' >Home</a>";
        if (sessionLogin != null)
        {
            C2.Text = "<a href='Historique.aspx'>Historique</a>";
            C3.Text = "<a href='Logout.aspx'>Logout</a>";
        }
            
        else
        {
            C2.Text= "<a href='Login.aspx'>Login</a>";
            C3.Text = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

public class Connexion
{
    private OleDbConnection cn;
    public Connexion(HttpServerUtility S)//S est un objet de la class HttpServerUtility
                                         //S va prend la valeur de l'objet Server
    {
        cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" +
                                 " Data Source =" + S.MapPath("App_Data\\Hotel.accdb") + ";" +
                                 " Persist Security Info = True");
    }

    public DataTable extraire(string sql)
    {
        OleDbDataAdapter adp = new OleDbDataAdapter(sql,cn);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        return dt;
    }

    public int modifier(string sql)
    {
        try
        {
            if (cn.State != ConnectionState.Open)
                cn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, cn);
            return cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            return -1;
        }
        finally
        {
            cn.Close();
        }
    }
}
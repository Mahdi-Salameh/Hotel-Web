<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Historique.aspx.cs" Inherits="Historique" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .grv{
            text-align:center;
        }
        .caption{
            color:#990000;
            font-weight:bold;
            font-size:x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="tbMenu" runat="server" BorderColor="#990000" BorderStyle="Outset" HorizontalAlign="Center" Width="400px" BorderWidth="5px">
            </asp:Table>
            <br />
            <div class="grv">
                <asp:Label ID="lblCaption" runat="server" Visible="false" CssClass="caption" Text="Historique"></asp:Label>
                <asp:GridView ID="grvHistorique" runat="server" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" Width="400px" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

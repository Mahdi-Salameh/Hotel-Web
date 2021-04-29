<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

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
            <table align="center" width=400px style="border: 5px outset #990000;">
                <tr>
                    <td>Date d’arrivée:</td>
                    <td>
                        <asp:TextBox ID="txtArrivee" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtArrivee" ErrorMessage="Date d'arrivee Obligatoire!">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtArrivee" ValidationExpression="\d{2}/\d{2}/\d{4}" ErrorMessage="Date d'arrivee format incorrect! (Format: dd/mm/yyyy)">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Date de départ:</td>
                    <td>
                        <asp:TextBox ID="txtDepart" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtDepart" ErrorMessage="Date de depart Obligatoire!">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" runat="server" ControlToValidate="txtDepart" ValidationExpression="\d{2}/\d{2}/\d{4}" ErrorMessage="Date de depart format incorrect! (Format: dd/mm/yyyy)">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Chambre:</td>
                    <td>
                        <asp:DropDownList ID="drpCategorie" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpCategorie_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRechercher" runat="server" CausesValidation="false" Text="Rechercher" OnClick="btnRechercher_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="grv">
                <asp:Label ID="lblCaption" runat="server" CssClass="caption" Text="Chambres Disponibles" Visible="False"></asp:Label>
                <asp:GridView ID="grvReservation" runat="server" Width="400px" HorizontalAlign="Center" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grvReservation_SelectedIndexChanged">              
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField HeaderText="Reservation" SelectText="Reserver" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
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
            <br />
            <table align="center">
                <tr>
                    <td>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="400px" BorderStyle="Outset" BorderWidth="5px" BorderColor="#990000" />
                    </td>
                </tr>
            </table>      
            <br />
        </div>
    </form>
</body>
</html>

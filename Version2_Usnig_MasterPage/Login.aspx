<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table align="center" width=400px style="background-color:#FFFBD6; border: 5px outset #990000;">
            <tr>
                <td >Login:</td>
                <td>
                    <asp:TextBox ID="txtLogin" runat="server" placeholder="UserID"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin" ForeColor="Red" ErrorMessage="Login Obligatoire!">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtLogin" ForeColor="Red" Operator="DataTypeCheck" Type="Integer" ErrorMessage="Login Incorrect!">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td >Password:</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ForeColor="Red" ErrorMessage="Password Obligatoire!">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="102px" OnClick="btnLogin_Click" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="chkMemo" runat="server" Text="Memoriser Login et Password" />
                </td>
            </tr>
        </table>
        <br />
        <table align="center">
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderColor="#990000" BorderStyle="Outset" BorderWidth="5px" Width="400px" BackColor="#FFFBD6" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="L1_Rekursija.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            LD_6. Apskritimas.
            <br />
            <br />
            <div>
                Spindulys r: <asp:TextBox ID="TextBox1"  runat="server" Height="16px" Width="64px" TextMode="Number"></asp:TextBox>
                &nbsp; 1 <= r <= 16<br />
            </div>
            <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" Width="147px" />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table1" style="text-align:center; width:auto;" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Overline="False" GridLines="Both" HorizontalAlign="Left" CellPadding="15" CellSpacing="7" Font-Underline="False" ForeColor="Black">
            </asp:Table>
            <br />
    </form>
</body>
</html>

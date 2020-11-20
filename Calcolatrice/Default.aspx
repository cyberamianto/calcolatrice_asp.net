<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Calcolatrice.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblRisultato" runat="server"></asp:Label>
        <br />
        <asp:TextBox ID="txtEl" runat="server" ReadOnly="True" Width="229px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSalvaInMemoria" runat="server" OnClick="btnSalvaInMemoria_Click" Text="MS" ToolTip="Salvataggio in memoria" Width="50px" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMostraMemoria" runat="server" OnClick="btnMostraMemoria_Click" Text="MR" ToolTip="Mostra il contenuto della memoria" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancellaMemoria" runat="server" OnClick="btnCancellaMemoria_Click" Text="MC" ToolTip="Cancella il contenuto della memoria" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAggiungiMemoria" runat="server" OnClick="btnAggiungiMemoria_Click" Text="M+" ToolTip="Aggiunta alla memoria" Width="50px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSottrazioneMemoria" runat="server" OnClick="btnSottrazioneMemoria_Click" Text="M-" ToolTip="Sottrazione alla memoria" Width="50px" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancCarattere" runat="server" OnClick="btnCancCarattere_Click" Text="←" Width="50px" />
&nbsp;<p>
            <asp:Button ID="btn7" runat="server" OnClick="btn7_Click" Text="7" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn8" runat="server" OnClick="btn8_Click" Text="8" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn9" runat="server" OnClick="btn9_Click" Text="9" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPiu" runat="server" OnClick="btnPiu_Click" Text="+" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancellaTutto" runat="server" OnClick="btnCancellaTutto_Click" Text="C" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnRadice" runat="server" OnClick="btnRadice_Click" Text="rad" Width="50px" ToolTip="Radicale" />
        </p>
        <p>
            <asp:Button ID="btn4" runat="server" OnClick="btn4_Click" Text="4" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn5" runat="server" OnClick="btn5_Click" Text="5" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn6" runat="server" OnClick="btn6_Click" Text="6" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMeno" runat="server" OnClick="btnMeno_Click" Text="-" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVirgola" runat="server" OnClick="btnVirgola_Click" Text="," Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPercentuale" runat="server" Text="%" Width="50px" OnClick="btnPercentuale_Click" ToolTip="Percentuale" />
        </p>
        <p>
            <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="1" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn2" runat="server" OnClick="btn2_Click" Text="2" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn3" runat="server" OnClick="btn3_Click" Text="3" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPer" runat="server" OnClick="btnPer_Click" Text="x" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCambioSegno" runat="server" OnClick="btnCambioSegno_Click" Text="+/-" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPotenza" runat="server" OnClick="btnPotenza_Click" Text="x^2" ToolTip="Elevamento alla seconda" Width="50px" />
        </p>
        <p>
            <asp:Button ID="btnCancella" runat="server" OnClick="btnCancella_Click" Text="CA" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn0" runat="server" OnClick="btn0_Click" Text="0" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDiviso" runat="server" OnClick="btnDiviso_Click" Text="/" Width="50px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUguale" runat="server" OnClick="btnUguale_Click" Text="=" Width="50px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnFratta" runat="server" OnClick="btnFratta_Click" Text="1/x" Width="50px" />
        &nbsp;&nbsp;&nbsp;
        </p>
    </form>
</body>
</html>

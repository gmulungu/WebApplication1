<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Supermarket<%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no data records to display.">
        </asp:GridView>
    </p>
    <p>name &amp; description: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp; Price:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;
        <asp:Image ID="Image1" runat="server" Height="16px" Width="16px" />
&nbsp;<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="IMAGE UPLOAD" />
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert" />
    </p>
    <p>Name&amp;Description</p>
</asp:Content>

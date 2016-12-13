<%@ Page Title="Yönetim - Yönetici Giriş" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.YoneticiGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Müzik Kutusuna giriş yapın.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Yönetici girişi yapın:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <li class="one">
            <h5>E-Posta Adresi</h5>
            <p>
                <asp:TextBox ID="txtEPosta" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="E-Posta boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtEPosta"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="two">
            <h5>Şifre</h5>
            <p>
                <asp:TextBox ID="txtSifre" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorSifre" runat="server" ErrorMessage="Şifre boş geçilemez." ControlToValidate="txtSifre" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnGiris" runat="server" Text="Giriş" OnClick="btnGiris_Click" />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>
<%@ Page Title="Yönetim - Şarkı Düzenle" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="SarkiYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.SarkiYonet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Şarkı Düzenleme Ekranı.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Şarkı bilgisini değiştiriniz:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <li class="one">
            <h5>Şarkı Adı</h5>
            <p>
                <asp:TextBox ID="txtSarki" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Şarkı adı boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtSarki"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="two">
            <h5>Şarkıcı</h5>
            <p>
                <asp:DropDownList ID="cmbSarkici" runat="server"></asp:DropDownList>
            </p>
        </li>
        <li class="three">
            <h5>Müzik Türü</h5>
            <p>
                <asp:DropDownList ID="cmbMuzikTuru" runat="server"></asp:DropDownList>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>

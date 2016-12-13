<%@ Page Title="Profil Düzenle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="MuzikKutusuWeb.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Profil Düzenleme Ekranı.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Bilgilerinizi değiştiriniz:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <li class="one">
            <h5>Adınız</h5>
            <p>
                <asp:TextBox ID="txtAdiniz" runat="server" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Ad boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtAdiniz"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="two">
            <h5>Soyadınız</h5>
            <p>
                <asp:TextBox ID="txtSoyadiniz" runat="server" MaxLength="20"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorSifre" runat="server" ErrorMessage="Soyad boş geçilemez." ControlToValidate="txtSoyadiniz" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="three">
            <h5>E-Posta Adresi</h5>
            <p>
                <asp:TextBox ID="txtEPosta" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="E-Posta boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtEPosta"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="four">
            <h5>Şifre</h5>
            <p>
                <asp:TextBox ID="txtSifre" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Şifre boş geçilemez." ControlToValidate="txtSifre" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
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

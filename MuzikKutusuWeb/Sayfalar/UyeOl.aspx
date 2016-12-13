<%@ Page Title="Üye Ol" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="MuzikKutusuWeb.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Müzik Kutusuna üye olun.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Bilgileri giriniz:</h3>
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
        <li class="three">
            <h5>Şifre Tekrar</h5>
            <p>
                <asp:TextBox ID="txtSifreTekrar" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorSifreTekrar" runat="server" ErrorMessage="Şifre Tekrar boş geçilemez." ControlToValidate="txtSifreTekrar" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator><asp:CompareValidator ID="CompareValidatorSifre" runat="server" ErrorMessage="Şifre ile Şifre tekrar aynı değil." ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" Display="Dynamic" SetFocusOnError="True" Type="String" Text="*"></asp:CompareValidator>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnUyeOl" runat="server" Text="Üye Ol" OnClick="btnUyeOl_Click" />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>

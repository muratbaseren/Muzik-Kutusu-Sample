<%@ Page Title="Yönetim - Şarkıcıları Yönet" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="SarkicilariYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.SarkicilariYonet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Şarkıcıları Yönetin.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Şarkıcılar:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:Repeater ID="rptSarkicilar" runat="server">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/SarkiciYonet.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Düzenle</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/SarkicilariYonet.aspx?Sil=1&ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Sil</asp:HyperLink>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "SarkiciAd") %></span></li>
                <li>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <hr />
        </li>
        <li>
            <h3>Şarkıcı Ekle:</h3>
        </li>
        <li class="one">
            <h5>Şarkıcı</h5>
            <p>
                <asp:TextBox ID="txtSarkici" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Şarkıcı boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtSarkici"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li class="two">
            <h5>Şarkıcı Twitter ScreenName(örn;@IMDb için IMDb giriniz.)</h5>
            <p>
                <asp:TextBox ID="txtSarkiciTwitter" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Şarkıcı twitter screen name boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtSarkiciTwitter"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnSarkiciEkle" runat="server" Text="Ekle" OnClick="btnSarkiciEkle_Click"  />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>


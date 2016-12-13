<%@ Page Title="Yönetim - Şarkıcı Yönet" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="SarkiciYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.SarkiciYonet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Şarkıcı Düzenleme Ekranı.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Şarkıcı bilgisini değiştiriniz:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:Repeater ID="rptSarkici" runat="server">
            <ItemTemplate>
                <li class="one">
                    <h5>Şarkıcı</h5>
                    <p>
                        <asp:TextBox ID="txtSarkici" runat="server" MaxLength="50"  Text='<%# DataBinder.Eval(Container.DataItem, "SarkiciAd") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Şarkıcı boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtSarkici"></asp:RequiredFieldValidator>
                    </p>
                </li>
                <li class="two">
                    <h5>Şarkıcı Twitter ScreenName(örn;@IMDb için IMDb giriniz.) </h5>
                    <p>
                        <asp:TextBox ID="txtSarkiciTwitter" runat="server" MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "SarkiciTwitter") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Şarkıcı twitter screen name boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtSarkiciTwitter"></asp:RequiredFieldValidator>
                    </p>
                </li>
            </ItemTemplate>
        </asp:Repeater>
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

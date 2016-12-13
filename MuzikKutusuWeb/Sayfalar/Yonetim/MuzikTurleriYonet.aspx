<%@ Page Title="Yönetim - Müzik Türleri" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="MuzikTurleriYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.MuzikTurleriYonet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Müzik Türlerini Yönetin.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Müzik Türleri:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:Repeater ID="rptMuzikTurleri" runat="server">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/MuzikTuruYonet.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Düzenle</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/MuzikTurleriYonet.aspx?Sil=1&ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Sil</asp:HyperLink>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "TurAd") %></span></li>
                <li>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <hr />
        </li>
        <li>
            <h3>Müzik Türü Ekleme:</h3>
        </li>
        <li class="one">
            <h5>Müzik Türü</h5>
            <p>
                <asp:TextBox ID="txtMuzikTuru" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Müzik türü boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtMuzikTuru"></asp:RequiredFieldValidator>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnMuzikTuruEkle" runat="server" Text="Ekle" OnClick="btnMuzikTuruEkle_Click"  />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>

<%@ Page Title="Yönetim - Üye Listesi" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="UyeListesi.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.UyeListesi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Üye Listesi Ekranı</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Üye bilgileri:</h3>
    <ol class="round">
        <asp:Repeater ID="rptUyeler" runat="server">
            <ItemTemplate>
                <li>
                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/UyeYonet.aspx?uyeID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Düzenle</asp:HyperLink>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "Ad") %></span>&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "Soyad") %></span>&nbsp;&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "EPosta") %></span>&nbsp;&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "UyelikTuru") %></span></li>
            </ItemTemplate>
        </asp:Repeater>
    </ol>
</asp:Content>



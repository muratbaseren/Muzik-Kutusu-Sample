<%@ Page Title="Müzik Kutusu - Çıkış" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cikis.aspx.cs" Inherits="MuzikKutusuWeb.Cikis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Müzik Kutusundan çıkışınız yapılıyor..</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <ol class="round">
        <li>
            <p>
                Otomatik olarak ana sayfaya yönlendirileceksiniz..
            </p>
        </li>
    </ol>
</asp:Content>

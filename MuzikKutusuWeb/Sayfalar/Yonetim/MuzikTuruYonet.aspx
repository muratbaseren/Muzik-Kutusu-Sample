<%@ Page Title="Yönetim - Müzik Türü Yönet" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="MuzikTuruYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.MuzikTuruYonet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Müzik Türü Düzenleme Ekranı.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Müzik türü bilgisini değiştiriniz:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <li class="one">
            <h5>Müzik Türü</h5>
            <p>
                <asp:Repeater ID="rptMuzikTuru" runat="server">
                    <ItemTemplate>
                        <asp:TextBox ID="txtMuzikTuru" runat="server" MaxLength="20" Text='<%# DataBinder.Eval(Container.DataItem, "TurAd") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Müzik Türü boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtMuzikTuru"></asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:Repeater>
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

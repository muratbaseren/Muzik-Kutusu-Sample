<%@ Page Title="Yönetim - Şarkıları Yönet" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="SarkilariYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.SarkilariYonet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Şarkıları Yönetin.</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Şarkılar:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:Repeater ID="rptSarkilar" runat="server">
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/SarkiYonet.aspx?ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Düzenle</asp:HyperLink>&nbsp;&nbsp;<asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/Sayfalar/Yonetim/SarkilariYonet.aspx?Sil=1&ID=" + DataBinder.Eval(Container.DataItem, "ID") %>'>Sil</asp:HyperLink>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "SarkiAd") %></span>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "SarkiciAd") %></span>&nbsp;&nbsp;<span><%# DataBinder.Eval(Container.DataItem, "TurAd") %></span></li>
                <li>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <hr />
        </li>
        <li>
            <h3>Şarkı Ekle:</h3>
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
                <asp:Button ID="btnSarkiEkle" runat="server" Text="Ekle" OnClick="btnSarkiEkle_Click" />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>

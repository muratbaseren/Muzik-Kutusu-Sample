<%@ Page Title="Müzik Kutusu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MuzikKutusuWeb._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Müzik Kutusu ile Kendi Favori Şarkı Listenizi Oluşturun.</h2>
            </hgroup>
            <p>
                Şarkıları istediğiniz gibi filtreleyebilir ve beğendiğiniz şarkıları favori listenize kaydedebilirsiniz. Ayrıca şarkıcılara ait twitter hesabında yer alan tweet'leri görebilmek için şarkıcı isimlerine tıklayarak takip edebilirsiniz.
            </p>
            <p>
                Favori listenize şarkı eklemek ve için lütfen <a href="Sayfalar/UyeOl.aspx">kaydolun</a> ve <a href="Sayfalar/Giris.aspx">giriş</a> yapınız.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Şarkıları filitreleyebilir, favori listenize ekleyebilirsiniz:</h3>
    <ol class="round" style="height: 600px;">
        <li>
            <p>
                <asp:DropDownList ID="cmbSarkicilar1" runat="server"></asp:DropDownList>&nbsp;&nbsp;<asp:Button ID="btnFiltrele1" runat="server" Text="Filtrele" OnClick="btnFiltrele1_Click" />&nbsp;&nbsp;<asp:DropDownList ID="cmbMuzikTuru1" runat="server"></asp:DropDownList>&nbsp;&nbsp;<asp:Button ID="btnFiltrele2" runat="server" Text="Filtrele" OnClick="btnFiltrele2_Click" />&nbsp;&nbsp;<asp:TextBox ID="txtFiltre3" runat="server" MaxLength="50" />&nbsp;&nbsp;<asp:Button ID="btnFiltrele3" runat="server" Text="Filtrele" OnClick="btnFiltrele3_Click" />
            </p>
        </li>
        <asp:Repeater ID="rptSonuclar" runat="server" OnItemCreated="rptSonuclar_ItemCreated">
            <HeaderTemplate>
                <span>
                    <h5>Filtreleme Sonuçları</h5>
                </span>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lnkFavorilerimeEkle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' Visible='<%# Session["UyeID"] != null ? true : false %>'>Favorilerime Ekle</asp:LinkButton>&nbsp;&nbsp;
                    <asp:HyperLink ID="lnkSarkici" runat="server" NavigateUrl='<%# "~/Sayfalar/Sarkici.aspx?ID=" + DataBinder.Eval(Container.DataItem, "SarkiciID") %>'>
                    <span><%# DataBinder.Eval(Container.DataItem, "SarkiciAd") %></span></asp:HyperLink>&nbsp;&nbsp;
                    <span><%# DataBinder.Eval(Container.DataItem, "TurAd") %></span>&nbsp;&nbsp;
                    <span><%# DataBinder.Eval(Container.DataItem, "SarkiAd") %></span>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li>
            <hr />
            <h5>Favori Listem</h5>
            <p>
                <asp:Label ID="lblFavoriUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:UpdatePanel ID="updFavoriler" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rptFavoriler" runat="server" OnItemCreated="rptFavoriler_ItemCreated">
                    <ItemTemplate>
                        <li>
                            <p>
                                <asp:LinkButton ID="lnkFavoriSil" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                    <img src="Images/cancel16.png" alt="sil" />
                                </asp:LinkButton>&nbsp;&nbsp;
                                <asp:HyperLink ID="lnkSarkici" runat="server" NavigateUrl='<%# "~/Sayfalar/Sarkici.aspx?ID=" + DataBinder.Eval(Container.DataItem, "SarkiciID") %>'>
                                <span><%# DataBinder.Eval(Container.DataItem, "SarkiciAd") %></span></asp:HyperLink>&nbsp;&nbsp;
                                <span><%# DataBinder.Eval(Container.DataItem, "TurAd") %></span>&nbsp;&nbsp;
                                <span><%# DataBinder.Eval(Container.DataItem, "SarkiAd") %></span>
                            </p>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </ol>
</asp:Content>

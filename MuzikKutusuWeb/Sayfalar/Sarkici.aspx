<%@ Page Title="Şarkıcı Twitter Görüntüleme" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sarkici.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Sarkici" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Beğendiğiniz şarkıcının tweet'lerini görüntüleyin.</h2>
            </hgroup>
            <p>
                Bu sayfada şarkıcıya ait tweet'ler listelenmektedir. 2 sn aralıklarla liste otomatik olarak güncellenmektedir.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Timer ID="timer" runat="server" Interval="2000" Enabled="true" OnTick="timer_Tick"></asp:Timer>
    <h3>
        <asp:Label ID="lblBaslik" runat="server"></asp:Label></h3>
    <ol class="round">
        <li>
            <p>
                Şarkıcının Twitter sayfasına git :&nbsp;<asp:HyperLink ID="lnkSarkiciTwitter" runat="server"></asp:HyperLink>
            </p>
        </li>
        <asp:UpdatePanel ID="updTwitter" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="rptTwitter" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="../Images/twitter-bird-light-bgs.png" width="16" height="16" />&nbsp;&nbsp;
                        <%# DataBinder.Eval(Container.DataItem,"tweet") %>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </ol>
</asp:Content>

<%@ Page Title="Yönetim - Üye Yönet" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="UyeYonet.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.UyeYonet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Üye Yönetim Ekranı</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Üye bilgilerini değiştirin:</h3>
    <ol class="round">
        <li>
            <p>
                <asp:Label ID="lblUyari" runat="server" Visible="false"></asp:Label>
            </p>
        </li>
        <asp:Repeater ID="rptUye" runat="server">
            <ItemTemplate>
                <li class="one">
                    <h5>Ad</h5>
                    <p>
                        <asp:TextBox ID="txtAdiniz" runat="server" MaxLength="20" Text='<%# DataBinder.Eval(Container.DataItem, "Ad") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorEPosta" runat="server" ErrorMessage="Ad boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtAdiniz"></asp:RequiredFieldValidator>
                    </p>
                </li>
                <li class="two">
                    <h5>Soyad</h5>
                    <p>
                        <asp:TextBox ID="txtSoyadiniz" runat="server" MaxLength="20" Text='<%# DataBinder.Eval(Container.DataItem, "Soyad") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorSifre" runat="server" ErrorMessage="Soyad boş geçilemez." ControlToValidate="txtSoyadiniz" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
                    </p>
                </li>
                <li class="three">
                    <h5>E-Posta Adresi</h5>
                    <p>
                        <asp:TextBox ID="txtEPosta" runat="server" MaxLength="50" Text='<%# DataBinder.Eval(Container.DataItem, "EPosta") %>'></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="E-Posta boş geçilemez." Display="Dynamic" Text="*" SetFocusOnError="True" ControlToValidate="txtEPosta"></asp:RequiredFieldValidator>
                    </p>
                </li>
                <li class="four">
                    <h5>Şifre</h5>
                    <p>
                        <asp:TextBox ID="txtSifre" runat="server" MaxLength="10" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "Sifre") %>' TextMode="SingleLine"></asp:TextBox>
                    </p>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <li class="five">
            <h5>Üyelik Türü</h5>
            <p>
                <asp:DropDownList ID="cmbUyelikTuru" runat="server">
                    <asp:ListItem Selected="True">üye</asp:ListItem>
                    <asp:ListItem>yönetici</asp:ListItem>
                </asp:DropDownList>
            </p>
        </li>
        <li>
            <p>
                <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" />
            </p>
        </li>
        <li>
            <p>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </li>
    </ol>
</asp:Content>


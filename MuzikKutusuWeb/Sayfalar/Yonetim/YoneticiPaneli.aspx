<%@ Page Title="Yönetim - Yönetici Paneli" Language="C#" MasterPageFile="~/Sayfalar/Yonetim/SiteYonetim.Master" AutoEventWireup="true" CodeBehind="YoneticiPaneli.aspx.cs" Inherits="MuzikKutusuWeb.Sayfalar.Yonetim.YoneticiPaneli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Yönetim Paneli</h2>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Yönetim Paneli ile bilgileri yönetin:</h3>
    <ol class="round">
        <li>
            <p>Sağ üst köşedeki link'leri kullanarak site verilerini düzenleyebilir, yeni veri ekleyebilir, verileri listeleyebilir veya silebilirsiniz.</p>
        </li>
        <li class="one">
            <h5>Müzik Kutusu</h5>
            <p>
                Müzik kutusu link'i ile site ana sayfasına gidebilirsiniz.
            </p>
        </li>
        <li class="two">
            <h5>Yönetim Paneli</h5>
            <p>
                Yönetim paneli link'i ile bu sayfaya geri dönebilirsiniz.
            </p>
        </li>
        <li class="three">
            <h5>Üyeler</h5>
            <p>
                Üyeler link'i ile üye listesine ulaşabilir. Üyelerin bilgilerini düzenleyerek istediğiniz üye yi 'yönetici' olarak değiştirebilirsiniz. Üye silebilir. Bilgilerini görüntüleyebilirsiniz.
            </p>
        </li>
        <li class="four">
            <h5>Müzik Türleri</h5>
            <p>
                Müzik Türleri link'i ile müzik türleri listesine ulaşabilir. Müzik tür bilgilerini düzenleyerek değiştirebilirsiniz. Müzik türü ekleyip, silebilirsiniz.
            </p>
        </li>
        <li class="five">
            <h5>Şarkıcılar</h5>
            <p>
                Şarkıcılar link'i ile şarkıcıların listesine ulaşabilir. Şarkıcı bilgilerini düzenleyerek değiştirebilirsiniz. Şarkıcı ekleyip, silebilirsiniz.
            </p>
        </li>
        <li class="six">
            <h5>Şarkılar</h5>
            <p>
                Şarkılar link'i ile Şarkıların listesine ulaşabilir. Şarkı bilgilerini düzenleyerek değiştirebilirsiniz. Şarkı ekleyip, silebilirsiniz.
            </p>
        </li>
    </ol>
</asp:Content>

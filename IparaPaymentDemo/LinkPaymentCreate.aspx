<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkPaymentCreate.aspx.cs" Inherits="IparaPaymentDemo.LinkPaymentCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">

    <fieldset>

        <!-- Form Name -->
        <legend>Ödeme Linki Oluştur</legend>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Adı (*):</label>
            <div class="col-md-4">
                <input id="name" runat="server" type="text" class="form-control input-md" required="">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Soyadı (*):</label>
            <div class="col-md-4">
                <input id="surname" runat="server" class="form-control input-md" required="">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri TCKN (Opsiyonel):</label>
            <div class="col-md-4">
                <input id="tcCertificate" runat="server" class="form-control input-md">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Vergi No (Opsiyonel):</label>
            <div class="col-md-4">
                <input  runat="server" id="taxNumber"  class="form-control input-md">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Email (*):</label>
            <div class="col-md-4">
                <input id="email" runat="server"  class="form-control input-md" required="">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Cep Telefonu (*):</label>
            <div class="col-md-4">
                <input id="gsm" runat="server"  class="form-control input-md" required="">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Tahsil Edilecek Tutar (TL) (**):</label>
            <div class="col-md-4">
                <input id="amount" runat="server"  class="form-control input-md" required="">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">3D Secure (*):</label>
            <div class="col-md-4">
                <select id="threeD" runat="server" class="form-control">
                    <option value="true">Evet</option>
                    <option value="false">Hayır</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Link Geçerlilik Süresi (Gün/Ay/Yıl) (*):</label>
            <div class="col-md-4 form-inline">
                <input id="day" runat="server" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2" required="required">
                <input id="month" runat="server" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2" required="required">
                <input id="year" runat="server" class="form-control input-md" style="width: 112px; text-align: center;" maxlength="4" required="required">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteriye Bilgilendirme Mailli Gönder (*):</label>
            <div class="col-md-4">
                <select id="sendEmail" runat="server" class="form-control">
                    <option value="true">Evet</option>
                    <option value="false">Hayır</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Komisyon Kime Yansıtılacak (Opsiyonel):</label>
            <div class="col-md-4">
                <select id="commissionType" runat="server" class="form-control">
                    <option value="1">Satıcı (Varsayılan)</option>
                    <option value="2">Müşteri</option>
                </select>
            </div>
        </div>

        <!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnCreateLinkPayment" runat="server" Text="Ödeme Linki Oluştur" class="btn btn-success" OnClick="BtnCreateLinkPayment_Click" />
			</div>
		</div>
        <p>** Sipariş tutarı kuruş ayracı olmadan gönderilmelidir. Örneğin; 1 TL 100, 12 1200, 130 13000, 1.05 105, 1.2 120 olarak gönderilmelidir.</p>
    </fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NonThreeDPayment.aspx.cs" Inherits="IparaPaymentDemo.NonThreeDPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
<fieldset>
	<legend>
		<label style="font-weight: bold; width: 250px;">Sepet Bilgileri</label>
	</legend>
	<table class="table">
		<thead>
			<tr>
				<th>Ürün</th>
				<th>Kod</th>
				<th>Adet</th>
				<th>Birim Fiyat</th>
			</tr>
		</thead>
		<tbody>
			<tr>
				<td>Telefon</td>
				<td>TLF0001</td>
				<td>1</td>
				<td>50.00 TL</td>
			</tr>
			<tr>
				<td>Bilgisayar</td>
				<td>BLG0001</td>
				<td>1</td>
				<td>50.00 TL</td>
			</tr>

			<tr>
				<td colspan="3">Toplam Tutar</td>

				<td>100.00 TL</td>
			</tr>
		</tbody>
	</table>
</fieldset>
<br />
<fieldset>
	<legend>
		<label style="font-weight: bold; width: 250px;">Kargo Adresi Bilgileri</label>
	</legend>
	<label style="font-weight: bold;">Ad :</label> Murat<br> <label
		style="font-weight: bold;">Soyad :</label> Kaya <br> <label
		style="font-weight: bold;">Adres :</label> Mevlüt Pehlivan Mah.
	Multinet Plaza Şişli <br> <label style="font-weight: bold;">Posta Kodu
		:</label> 34782 <br> <label style="font-weight: bold;">Şehir :</label>
	İstanbul <br> <label style="font-weight: bold;">Ülke :</label> Türkiye
	<br> <label style="font-weight: bold;">Telefon Numarası:</label>
	2123886600 <br>
</fieldset>
<br />
<br />
<fieldset>
	<legend>
		<label style="font-weight: bold; width: 250px;">Fatura Adresi
			Bilgileri</label>
	</legend>
	<label style="font-weight: bold;">Ad :</label> Murat<br> <label
		style="font-weight: bold;">Soyad :</label> Kaya<br> <label
		style="font-weight: bold;">Adres :</label> Mevlüt Pehlivan Mah.
	Multinet Plaza Şişli<br> <label style="font-weight: bold;">Posta Kodu :</label>
	34782<br> <label style="font-weight: bold;">Şehir :</label> İstanbul<br>
	<label style="font-weight: bold;">Ülke :</label> Türkiye<br> <label
		style="font-weight: bold;">TC Kimlik Numarası :</label> 12345678901<br>
	<label style="font-weight: bold;">Telefon Numarası:</label> 2123886600<br>
	<label style="font-weight: bold;">Vergi Numarası :</label> 123456<br> <label
		style="font-weight: bold;">Vergi Dairesi Adı :</label> Kozyatağı<br> <label
		style="font-weight: bold;">Firma Adı:</label> iPara
</fieldset>
<br />
<br />
<form action="" method="post" class="form-horizontal">
	<fieldset>

		<!-- Form Name -->
		<legend>
			<label style="font-weight: bold; width: 250px;">Kart Bilgileriyle
				Ödeme</label>
		</legend>


		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="">Kart Sahibi Adı Soyadı (*):</label>
			<div class="col-md-4">
				<input id="cardOwnerName" class="form-control input-md" required="" runat="server">
			</div>
		</div>
		<div class="form-group">
			<label class="col-md-4 control-label" for=""> Kart Numarası (*):</label>
			<div class="col-md-4">
				<input id="cardNumber" class="form-control input-md" required="" runat="server">
			</div>
		</div>
		<div class="form-group">
			<label class="col-md-4 control-label" for=""> Son Kullanma Tarihi Ay/Yıl (*):</label>
			<div class="col-md-1">
                <input id="cardExpireMonth" type="text" value="12" class="form-control input-md" runat="server" required="" />
            </div>
            <div class="col-md-1">
                <input id="cardExpireYear" type="text" value="24" class="form-control input-md" runat="server" required="" />
            </div>
		</div>
		<div class="form-group">
			<label class="col-md-4 control-label" for="">CVC (*):</label>
			<div class="col-md-4">
				<input id="cardCvc" class="form-control input-md" required="" runat="server">
			</div>
		</div>
		<div class="form-group">
            <label class="col-md-4 control-label" for="">Tutar (**):</label>
            <div class="col-md-4">
                <input value="10000" id="amount" class="form-control input-md" runat="server" required="">
            </div>
        </div>
		<div class="form-group">
            <label class="col-md-4 control-label" for="">Taksit (Opsiyonel):</label>
            <div class="col-md-4">
                <select class="form-control input-md" id="installment" runat="server">
                    <option value="">Seçiniz</option>
                    <option value="1">1</option>
                    <option value="2">2</option>
                    <option value="3">3</option>
                    <option value="4">4</option>
                    <option value="5">5</option>
                    <option value="6">6</option>
                    <option value="7">7</option>
                    <option value="8">8</option>
                    <option value="9">9</option>
                    <option value="10">10</option>
                    <option value="11">11</option>
                    <option value="12">12</option>
                </select>
            </div>
        </div>
	</fieldset>

	<!-- Button -->
	<div class="form-group">
		<label class="col-md-4 control-label" for=""></label>
		<div class="col-md-4">
			<asp:Button ID="BtnApiPayment" runat="server" Text="(Non-3D) Ödeme" class="btn btn-success" OnClick="BtnApiPayment_Click" />
		</div>
	</div>
	<p>** Sipariş tutarı kuruş ayracı olmadan gönderilmelidir. Örneğin; 1 TL 100, 12 1200, 130 13000, 1.05 105, 1.2 120 olarak gönderilmelidir.</p>
</form>
	<div id="result" runat="server"></div>
</asp:Content>

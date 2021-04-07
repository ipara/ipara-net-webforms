<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IparaPaymentDemo.Default" %>
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
		style="font-weight: bold;">TC Kimlik Numarası :</label> 1234567890<br>
	<label style="font-weight: bold;">Telefon Numarası:</label> 2123886600<br>
	<label style="font-weight: bold;">Vergi Numarası :</label> 123456<br> <label
		style="font-weight: bold;">Vergi Dairesi Adı :</label> Kozyatağı<br> <label
		style="font-weight: bold;">Firma Adı:</label> iPara
</fieldset>
<form action="" method="post" class="form-horizontal">
	<fieldset>

		<!-- Form Name -->
		<legend>
			<label style="font-weight: bold; width: 250px;">Kart Bilgileriyle
				Ödeme</label>
		</legend>


		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="">Kart Sahibi Adı Soyadı:</label>
			<div class="col-md-4">
				<input id="nameSurname" class="form-control input-md" runat="server">

			</div>
		</div>
		<div class="form-group">
			<label class="col-md-4 control-label" for=""> Kart Numarası:</label>
			<div class="col-md-4">
				<input id="cardNumber" class="form-control input-md" runat="server">

			</div>
		</div>

		<div class="form-group">
			<label class="col-md-4 control-label" for=""> Son Kullanma Tarihi
				Ay/Yıl: </label>
			<div class="col-md-4">
				<input id="month" class="form-control input-md" width="50px" runat="server"> 
				<input id="year" class="form-control input-md" width="50px" runat="server">

			</div>
		</div>

		<div class="form-group">
			<label class="col-md-4 control-label" for=""> CVC: </label>
			<div class="col-md-4">
				<input id="cvc" class="form-control input-md" runat="server">

			</div>
		</div>


	</fieldset>

	Taksit Sayısı <select id="installment" runat="server">
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

	<!-- Button -->
	<div class="form-group">
		<label class="col-md-4 control-label" for=""></label>
		<div class="col-md-4">
			<asp:Button ID="BtnPay3D" runat="server" Text="3D ile Ödeme" class="btn btn-success" OnClick="BtnPay3D_Click" />
		</div>
	</div>
</form>

</asp:Content>

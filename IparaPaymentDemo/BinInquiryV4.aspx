<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BinInquiryV4.aspx.cs" Inherits="IparaPaymentDemo.BinInquiryV4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    
        <fieldset>

		<!-- Form Name -->
		<legend>Bin Sorgulama V4</legend>

		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="binNumber">Bin Numarası (*):</label>
			<div class="col-md-4">
				<input id="binNumber" type="text" placeholder=""  runat="server" class="form-control input-md" required="">
			</div>
		</div>

		<div class="form-group">
			<label class="col-md-4 control-label" for="binNumber">Tutar (**):</label>
			<div class="col-md-4">
				<input id="amount" type="text" placeholder="" runat="server" class="form-control input-md" required="">
			</div>
		</div>

		<div class="form-group">
			<label class="col-md-4 control-label" for="binNumber">3D / (Non-Secure) (*):</label>
			<div class="col-md-4">
				<select id="threeD" type="text" placeholder="" runat="server" class="form-control" >
					<option value="true">3D</option>
					<option value="false">Non-Secure</option>
				</select>
			</div>
		</div>

		<!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnInquiry" runat="server" Text="Sorgula" class="btn btn-success" OnClick="BtnInquiry_Click" />
			</div>
		</div>
		<p>** Sipariş tutarı kuruş ayracı olmadan gönderilmelidir. Örneğin; 1 TL 100, 12 1200, 130 13000, 1.05 105, 1.2 120 olarak gönderilmelidir.</p>
	</fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentRefundInquiry.aspx.cs" Inherits="IparaPaymentDemo.PaymentRefundInquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    
        <fieldset>

		<!-- Form Name -->
		<legend>İade Sorgulama</legend>

		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="binNumber">Sipariş Numarası (*):</label>
			<div class="col-md-4">
				<input id="OrderId" type="text" placeholder="" runat="server" class="form-control input-md" required="">
			</div>
		</div>

		<div class="form-group">
			<label class="col-md-4 control-label" for="amount">Tutar (**):</label>
			<div class="col-md-4">
				<input id="Amount" type="text" placeholder="" runat="server" class="form-control input-md" required="">
			</div>
		</div>

		<!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnRefundInquiry" runat="server" Text="Sorgula" class="btn btn-success" OnClick="BtnRefundInquiry_Click" />
			</div>
		</div>
		<p>** Sipariş tutarı kuruş ayracı olmadan gönderilmelidir. Örneğin; 1 TL 100, 12 1200, 130 13000, 1.05 105, 1.2 120 olarak gönderilmelidir.</p>
	</fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

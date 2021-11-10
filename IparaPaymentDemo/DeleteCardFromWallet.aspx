<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteCardFromWallet.aspx.cs" Inherits="IparaPaymentDemo.DeleteCardFromWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <fieldset>

		<!-- Form Name -->
		<legend>Cüzdandan Kart Sil</legend>

		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="">Kullanıcı Id (*):</label>
			<div class="col-md-4">
				<input id="userId" runat="server" type="text" 
					class="form-control input-md" required="">
			</div>
		</div>
		<div class="form-group">
			<label class="col-md-4 control-label" for=""> Kart Id (Opsiyonel):</label>
			<div class="col-md-4">
				<input id="cardId" runat="server" class="form-control input-md">
			</div>
		</div>
		
		<!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnDeleteCard" runat="server" Text="Sorgula" class="btn btn-success" OnClick="BtnDeleteCard_Click" />
			</div>
		</div>

	</fieldset>

	<div id="result" runat="server"></div>
</asp:Content>

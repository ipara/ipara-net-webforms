<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BinInquiry.aspx.cs" Inherits="IparaPaymentDemo.BinInquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    
        <fieldset>

		<!-- Form Name -->
		<legend>Bin Sorgulama</legend>

		<!-- Text input-->
		<div class="form-group">
			<label class="col-md-4 control-label" for="binNumber">Bin Numarası</label>
			<div class="col-md-4">
				
				<input id="BinNumber" type="text" placeholder=""  runat="server" class="form-control input-md" required="">

			</div>
		</div>

		<!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnInquiry" runat="server" Text="Sorgula" class="btn btn-success" OnClick="BtnInquiry_Click" />
			</div>
		</div>

	</fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

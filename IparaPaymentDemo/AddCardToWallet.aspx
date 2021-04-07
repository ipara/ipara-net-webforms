<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCardToWallet.aspx.cs" Inherits="IparaPaymentDemo.AddCardToWallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">


	<fieldset>

        <!-- Form Name -->
        <legend>Cüzdana Kart Ekleme</legend>

        <!-- Text input-->
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Kullanıcı Id:</label>
            <div class="col-md-4">
                <input id="userId" type="text" runat="server" class="form-control input-md" required="">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Kart Sahibi Adı Soyadı:</label>
            <div class="col-md-4">
                <input  id="nameSurname" class="form-control input-md" required="" runat="server">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">  Kart Numarası:</label>
            <div class="col-md-4">
                <input id="cardNumber"  class="form-control input-md" required="" runat="server">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">  Kart Kısa Adı: </label>
            <div class="col-md-4">
                <input  value="" id="cardAlias"  class="form-control input-md" required="" runat="server">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">  Son Kullanma Tarihi Ay/Yıl: </label>
            <div class="col-md-4">
                <input id="month"  class="form-control input-md" required="" style="width:50px" runat="server">
                <input id="year"  class="form-control input-md" required="" style="width:50px" runat="server">

            </div>
        </div>
       

		<!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnAddCardToWallet" runat="server" Text="Kart Ekle" class="btn btn-success" OnClick="BtnAddCardToWallet_Click" />
			</div>
		</div>

	</fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

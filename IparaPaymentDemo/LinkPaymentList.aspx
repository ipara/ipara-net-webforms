<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinkPaymentList.aspx.cs" Inherits="IparaPaymentDemo.LinkPaymentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SiteContent" runat="server">
    <fieldset>

        <!-- Form Name -->
        <legend>Ödeme Linklerini Listele</legend>

        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Email (Opsiyonel):</label>
            <div class="col-md-4">
                <input id="email" class="form-control input-md" runat="server">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Müşteri Cep Telefonu (Opsiyonel):</label>
            <div class="col-md-4">
                <input  id="gsm"  runat="server" class="form-control input-md">
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Başlangıç Tarihi (Opsiyonel) (**):</label>
            <div class="col-md-4 form-inline">
                <input runat="server" id="start_day" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2">
                <input runat="server" id="start_month" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2">
                <input runat="server" id="start_year" class="form-control input-md" style="width: 112px; text-align: center;" maxlength="4">

            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Bitiş Tarihi (Opsiyonel) (**):</label>
            <div class="col-md-4 form-inline">
                <input runat="server" id="end_day" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2">
                <input runat="server" id="end_month" class="form-control input-md" style="width: 80px; text-align: center;" maxlength="2">
                <input runat="server" id="end_year" class="form-control input-md" style="width: 112px; text-align: center;" maxlength="4">
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="">Ödeme Durum Bilgisi (Opsiyonel):</label>
            <div class="col-md-4">
                <select runat="server" id="linkState" class="form-control">
                    <option value="-1">Seçiniz</option>
                    <option value="0">Link İsteği Alındı</option>
                    <option value="1">Link URL’i yaratıldı</option>
                    <option value="2">Link Gönderildi, Ödeme Bekleniyor</option>
                    <option value="3">Link ile Ödeme Başarılı</option>
                    <option value="98">Link Zaman Aşımına Uğradı</option>
                    <option value="99">Link Silindi</option>
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-md-4 control-label" for="">Sayfa Sayısı (5-15) (*):</label>
            <div class="col-md-4">
                    <select runat="server" id="pageSize" class="form-control">
                        <option value="5">5</option>
                        <option value="6">6</option>
                        <option value="7">7</option>
                        <option value="8">8</option>
                        <option value="9">9</option>
                        <option value="10">10</option>
                        <option value="11">11</option>
                        <option value="12">12</option>
                        <option value="13">13</option>
                        <option value="14">14</option>
                        <option value="15">15</option>
                    </select>
            </div>
        </div>

        <div class="form-group">
            <label class="col-md-4 control-label" for="">Sayfa Index (*):</label>
            <div class="col-md-4">
                <input runat="server" value="1" id="pageIndex"  class="form-control input-md" required="">
            </div>
        </div>
        <!-- Button -->
		<div class="form-group">
			<label class="col-md-4 control-label" for=""></label>
			<div class="col-md-4">
				<asp:Button ID="BtnListLinkPayment" runat="server" Text="Ödeme Linklerini Listele" class="btn btn-success" OnClick="BtnListLinkPayment_Click" />
			</div>
		</div>
        <p>** Başlangış ve Bitiş tarihi parametreleri bir çift olarak çalışmaktadır. Bu nedenle eğer biri istek içine eklenmiş ise, diğerinin de eklenmesi gerekmektedir.</p>
    </fieldset>

    <div id="result" runat="server"></div>
</asp:Content>

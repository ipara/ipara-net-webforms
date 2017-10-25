<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="IparaPaymentDemo.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblMessage" runat="server" Font-Size="14px" Font-Bold="true" BackColor="Maroon" ForeColor="White"></asp:Label>
            <table border="0" style="width: 100%; border-collapse: collapse; padding: 5px;">
                <tr>
                    <td>
                        <table border="0" style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td colspan="3">
                                    <span style="font-size: 18px; font-weight: bold;">Ödeme Bilgileri</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px;">Sipariş no</td>
                                <td style="width: 7px;">:</td>
                                <td>
                                    <asp:Label ID="lblOrderId" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Kart sahibi adı</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbCardOwnerName" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Kart numarası</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbCardNumber" runat="server" MaxLength="16" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Son kullanım (Ay/Yıl)</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbCardExpireMonth" runat="server"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="tbCardExpireYear" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Taksit</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbInstallment" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Cvc</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbCvc" runat="server" MaxLength="3"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td colspan="3">
                                    <span style="font-size: 18px; font-weight: bold;">Sipariş Veren Bilgileri</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px;">Adı</td>
                                <td style="width: 7px;">:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserName" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Soyadı</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserSurName" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Doğum tarihi (Yıl/Ay/Gün)</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserBirthDate" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Email</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserEmail" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Cep telefonu</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserGsmPhone" runat="server" Style="width: 250px;" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Tckimlik</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="tbPurchaserIdentityNumber" runat="server" Style="width: 250px;"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td style="width: 50%;">
                                    <table border="0" style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td colspan="3">
                                                <span style="font-size: 18px; font-weight: bold;">Fatura Bilgileri</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 200px;">Adı</td>
                                            <td style="width: 7px; font-weight: bold;">:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceName" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Soyadı</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceSurName" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Adresi</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceAddress" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Posta kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceZipCode" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Şehir kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceCityCode" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Tckimlik</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceIdentityNumber" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Ülke kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label ID="lblInvoiceCountryCode" runat="server" Style="width: 250px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Vergi numarası</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceTaxNumber" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Vergi dairesi</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceTaxOffice" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Şirket adı</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoiceCompanyName" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Fatura telefon</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbInvoicePhone" runat="server" Style="width: 250px;" MaxLength="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="vertical-align: top;">
                                    <table border="0" style="width: 100%; border-collapse: collapse;">
                                        <tr>
                                            <td colspan="3">
                                                <span style="font-size: 18px; font-weight: bold;">Teslimat Bilgileri</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 15%; font-weight: bold;">Adı</td>
                                            <td style="width: 1%; font-weight: bold;">:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingName" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Soyad</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingSurName" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Adresi</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingAddress" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Posta kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingZipCode" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Şehir kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingCityCode" runat="server" Style="width: 250px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Ülke kodu</td>
                                            <td>:</td>
                                            <td>
                                                <asp:Label ID="lblShippingCountryCode" runat="server" Style="width: 250px;"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Telefon</td>
                                            <td>:</td>
                                            <td>
                                                <asp:TextBox ID="tbShippingPhone" runat="server" Style="width: 250px;" MaxLength="10"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" style="width: 100%; border-collapse: collapse;">
                            <tr>
                                <td colspan="4">
                                    <span style="font-size: 18px; font-weight: bold;">Siparişteki Ürün Bilgileri</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Ürün Adı</td>
                                <td>Ürün Kodu</td>
                                <td>Fiyat</td>
                                <td>Adet</td>
                            </tr>
                            <tr>
                                <td><asp:TextBox ID="tbProductTitle1" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductCode1" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductPrice1" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductQuatity1" runat="server" Style="width: 250px;"></asp:TextBox></td>
                            </tr> 
                            <tr>
                                <td><asp:TextBox ID="tbProductTitle2" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductCode2" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductPrice2" runat="server" Style="width: 250px;"></asp:TextBox></td>
                                <td><asp:TextBox ID="tbProductQuatity2" runat="server" Style="width: 250px;"></asp:TextBox></td>
                            </tr>                              
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnPay" runat="server" OnClick="btnPay_Click" Text="Öde" />&nbsp;&nbsp;
        <asp:Button ID="btnThreeD" runat="server" Text="3D ile Öde" OnClick="btnThreeD_Click" />
    </form>
</body>
</html>
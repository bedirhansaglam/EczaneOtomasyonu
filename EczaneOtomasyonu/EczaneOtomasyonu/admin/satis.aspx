<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="satis.aspx.cs" Inherits="EczaneOtomasyonu.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 13%;
            height: 65px;
            text-align:center;
        }
        .auto-style3 {
            width: 1%;
            height: 65px;
        }
        .auto-style4 {
            width:86%;
            height: 65px;
        }
        .textbox {
            width:30%;
            height:60%;
            color:black;

        }
        .textbox1 {
            width:40%;
            height:50%;
            color:black;

        }
        .auto-style5 {
            width: 13%;
            height: 80px;
            text-align:center;
        }
        .auto-style6 {
             width: 1%;
            height: 80px;
        }
        .auto-syle7 {
            width:40%;
            height: 80px;
        }
        .auto-style8 {
            width: 56%;
            height: 80px;
            text-align:left;
        }
        .auto-style9 {
            width: 315px;
        }
        .label {
            color:white;
            font-size:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:100%; height:auto">
         <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_musteri" runat="server" ImageUrl="~/image/musteri.png" AlternateText="Göster" OnClick="ibtn_musteri_Click"/> &nbsp&nbsp
             <asp:Label ID="lbl_musteri_ekle" runat="server" Text="Müşteri Ekleme Paneli" Font-Size="20px"></asp:Label>
         </div>
        <asp:Panel ID="pnl_musteri_ekle" runat="server">
             <table class="auto-style1">
        <tr>
            <td class="auto-style2">TC NO</td>
            <td class="auto-style3">:</td>
            <td class="auto-style4">
                <asp:TextBox ID="tb_tcno" runat="server" CssClass="textbox"></asp:TextBox></td>
        </tr>
                  <tr>
            <td class="auto-style2">ADI</td>
            <td class="auto-style3">:</td>
            <td class="auto-style4"><asp:TextBox ID="tb_adi" runat="server" CssClass="textbox"></asp:TextBox></td>
        </tr>
                  <tr>
            <td class="auto-style2">SOYADI</td>
            <td class="auto-style3">:</td>
            <td class="auto-style4"><asp:TextBox ID="tb_soyadi" runat="server" CssClass="textbox"></asp:TextBox></td>
        </tr>
                  <tr>
            <td class="auto-style2">ADRES</td>
            <td class="auto-style3">:</td>
            <td class="auto-style4"><asp:TextBox ID="tb_adres" runat="server" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
                 <tr>
                     <td class="auto-style2">&nbsp;</td>
                     <td class="auto-style3">&nbsp;</td>
                     <td class="auto-style4" style="text-align:center">
                         <asp:ImageButton ID="ibtn_m_kaydet" runat="server" ImageUrl="~/image/save.png" AlternateText="Kaydet" ToolTip="Kaydet" OnClick="ibtn_m_kaydet_Click" /></td>
                 </tr>
    </table>
        </asp:Panel>
         <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_musteri_guncelle" runat="server" ImageUrl="~/image/musteri1.png" AlternateText="Göster" OnClick="ibtn_musteri_guncelle_Click" /> &nbsp&nbsp
             <asp:Label ID="lbl_musteri_guncelle" runat="server" Text="Müşteri Güncelleme Paneli" Font-Size="20px"></asp:Label>
         </div>
        <asp:Panel ID="pnl_musteri_duzenle" runat="server">
            <asp:GridView ID="gw_musteri_duzenle" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="TC_NO" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_musteri_duzenle_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="TC_NO" HeaderText="TC NO" />
                    <asp:BoundField DataField="adi" HeaderText="ADI" />
                    <asp:BoundField DataField="soyadi" HeaderText="SOYADI" />
                    <asp:BoundField DataField="adres" HeaderText="ADRES" />
                    <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="GÜNCELLE" ImageUrl="~/image/update.png" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_satis" runat="server"  ImageUrl="~/image/money.png" OnClick="ibtn_satis_Click" AlternateText="Göster"/>&nbsp&nbsp&nbsp<asp:Label ID="lbl_satis_ekle" runat="server" Text="Direkt Satış Yap"  Font-Size="20px"></asp:Label>
        </div>
        <asp:Panel ID="pnl_satis" runat="server">
            <table class="auto-style1">
        <tr>
            <td class="auto-style5">MÜŞTERİ ARA</td>
            <td class="auto-style6">:</td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddl_musteri_ara" runat="server" CssClass="textbox1" Height="40%">
                    <asp:ListItem Value="0">TC NO ile ara</asp:ListItem>
                    <asp:ListItem Value="1">İsim ile ara</asp:ListItem>
                </asp:DropDownList>&nbsp&nbsp&nbsp <asp:TextBox ID="tb_musteri_ara" runat="server" CssClass="textbox1"></asp:TextBox></td>
        <td class="auto-style8" ><asp:ImageButton ID="ibtn_musteri_ara" runat="server" ImageUrl="~/image/search.png" OnClick="ibtn_musteri_ara_Click" /></td>
        </tr>
                
    </table>
            <asp:GridView ID="gw_musteri" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="TC_NO">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="TC_NO" HeaderText="TC NO" />
                    <asp:BoundField DataField="adi" HeaderText="ADI" />
                    <asp:BoundField DataField="soyadi" HeaderText="SOYADI" />
                    <asp:BoundField DataField="adres" HeaderText="ADRES" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Tarih</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:Calendar ID="tarih" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                        &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="cb_tarih" runat="server" AutoPostBack="True" Text="Bugünün Tarihini Kullan" OnCheckedChanged="cb_tarih_CheckedChanged" /></td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" style="text-align:center">
                        <asp:ImageButton ID="ibtn_fis_ekle" runat="server" ImageUrl="~/image/fisolustur.png" AlternateText="FİŞ OLUŞTUR" ToolTip="FİŞ OLUŞTUR" OnClick="ibtn_fis_ekle_Click" />
                    </td>
                </tr>
            </table>
            </asp:Panel>

        
            <br />
        <asp:Panel ID="pnl_fis" runat="server">
            <table class="auto-style1">
                <tr>
                    <td style="background-color:#808080; height:60px;border:3px double #000; ">
                        <asp:Label ID="lbl_tarih" runat="server" Text="" CssClass="label"></asp:Label><asp:Label ID="lbl_fis_id" runat="server" Text="" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td style="background-color:#808080; height:60px;border:3px double #000;">
                        <asp:Label ID="lbl_musteri" runat="server" Text="" CssClass="label"></asp:Label>
                        <asp:Label ID="lbl_tc" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
              
            </table>
            <table class="auto-style1">
                <tr>
                    <td style="width:50%;background-color:#808080;"> 
                        <asp:Panel ID="pnl_ilac_ara" runat="server">
            <table class="auto-style1">
                 <tr>
                    <td class="auto-style5">İlaç Ara</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddl_ilac" runat="server" CssClass="textbox1" Width="40%">
                            <asp:ListItem Value="0">İsme göre ara</asp:ListItem>
                            <asp:ListItem Value="1">Kategoriye göre ara</asp:ListItem>
                        </asp:DropDownList><asp:TextBox ID="tb_ilac_ara" runat="server" CssClass="textbox1" Width="50%"></asp:TextBox></td>
                    <td class="auto-style8" style="width:20%;" ><asp:ImageButton ID="ibtn_ilac_ara" runat="server" ImageUrl="~/image/search.png" OnClick="ibtn_ilac_ara_Click" /></td>
                </tr>
            </table>
            <asp:GridView ID="gw_ilac" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" DataKeyNames="ilac_id">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="adi" HeaderText="İLAÇ ADI" />
                    <asp:BoundField DataField="kategori_adi" HeaderText="KATEGORİ" />
                    <asp:BoundField DataField="bfiyat" HeaderText="FİYAT" />
                    <asp:BoundField DataField="firma_adi" HeaderText="FİRMA" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </asp:Panel> 

                    </td>
                    <td style="width:50%; background-color:#808080; vertical-align: top;">
                         <asp:GridView ID="gw_fis_ilaclari" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="ilac_id" OnRowCommand="gw_fis_ilaclari_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                             <Columns>
                                 <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                                 <asp:BoundField DataField="kategori_adi" HeaderText="Kategori" />
                                 <asp:BoundField DataField="adi" HeaderText="İlaç Adı" />
                                 <asp:BoundField DataField="bfiyat" HeaderText="Birim Fiyat" />
                                 <asp:BoundField DataField="adet" HeaderText="Adet" />
                                 <asp:BoundField DataField="tutar" HeaderText="Tutar" />
                                 <asp:ButtonField ButtonType="Image" CommandName="ilacsil" HeaderText="İlaç Çıkar" ImageUrl="~/image/ilacsil.png" />
                             </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%; height:60px;">
                        <asp:Label ID="lbl_adet" runat="server" Text="Adet:" CssClass="label"></asp:Label><asp:TextBox ID="tb_adet" runat="server" CssClass="textbox1"></asp:TextBox><asp:ImageButton ID="ibtn_ilacekle" runat="server" ImageUrl="~/image/ilacekle.png" OnClick="ibtn_ilacekle_Click" /></td>
                    <td style="width:50%; height:60px; background-color:#808080; text-align:right;">
                        <asp:Label ID="lbl_tutar" runat="server" Text="Tutar:" CssClass="label"></asp:Label>&nbsp&nbsp&nbsp</td>
                </tr>
            </table>
            </asp:Panel>
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_fis" runat="server"  ImageUrl="~/image/fis.png" AlternateText="Göster" OnClick="ibtn_fis_Click"/>&nbsp&nbsp&nbsp<asp:Label ID="lbl_fis" runat="server" Text="Fişler"  Font-Size="20px"></asp:Label>
        </div>
        <asp:Panel ID="pnl_fisler" runat="server">
            <asp:GridView ID="gw_fis" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="fis_id" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_fis_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="tarih" HeaderText="Tarih" />
                    <asp:BoundField DataField="adi" HeaderText="Müşteri Adı" />
                    <asp:BoundField DataField="soyadi" HeaderText="Soyadı" />
                    <asp:BoundField DataField="adres" HeaderText="Adres" />
                    <asp:BoundField DataField="tutar" HeaderText="Fiş Tutarı" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Görüntüle" Text="Görüntüle" CommandName="goster" />
                    <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_recete_goster" runat="server"  ImageUrl="~/image/recete.png" AlternateText="Göster" OnClick="ibtn_recete_goster_Click" />&nbsp&nbsp&nbsp<asp:Label ID="lbl_recete" runat="server" Text="REÇETE EKLEME PANELİ"  Font-Size="20px"></asp:Label>
        </div>
        <asp:Panel ID="pnl_recete_ekle" runat="server">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">REÇETE TÜRÜ</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddl_receteturu" runat="server" CssClass="textbox1" DataTextField="tur_adi" DataValueField="tur_id"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td class="auto-style2">HASTANE</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:DropDownList ID="ddl_hastane" runat="server" CssClass="textbox1" AutoPostBack="True" DataTextField="hastane_adi" DataValueField="hastane_id" OnSelectedIndexChanged="ddl_hastane_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">DOKTOR</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:GridView ID="gw_doktorlar" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="doktor_id">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField HeaderText="SEÇ" ShowSelectButton="True" ButtonType="Button" />
                                <asp:BoundField DataField="adi" HeaderText="Doktor Adı" />
                                <asp:BoundField DataField="soyadi" HeaderText="Soyadı" />
                                <asp:BoundField DataField="tahsis" HeaderText="Uzmanlık" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">HASTA</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style4">
                        <asp:GridView ID="gw_hastalar" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="TC_NO">
                             <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="TC_NO" HeaderText="TC NO" />
                    <asp:BoundField DataField="adi" HeaderText="ADI" />
                    <asp:BoundField DataField="soyadi" HeaderText="SOYADI" />
                    <asp:BoundField DataField="adres" HeaderText="ADRES" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                  </td>
                </tr>

                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4" style="text-align:right;">
                        <asp:ImageButton ID="ibtn_kaydet" runat="server" ImageUrl="~/image/save.png" OnClick="ibtn_kaydet_Click"/>
                    </td>
                </tr>

            </table>
        </asp:Panel>
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_recete_ilac_ekle" runat="server"  ImageUrl="~/image/recete.png" AlternateText="Göster" OnClick="ibtn_recete_ilac_ekle_Click" />&nbsp&nbsp&nbsp<asp:Label ID="lbl_recete_ilac_ekl" runat="server" Text="REÇETE DÜZENLEME PANELİ"  Font-Size="20px"></asp:Label>
        </div>
        <asp:Panel ID="pnl_recete_ilac_ekle" runat="server">
            <table class="auto-style1">
                <tr>
                    <td style="width:100%;">
                        <asp:GridView ID="gw_receteler" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="recete_id" OnRowCommand="gw_receteler_RowCommand" OnSelectedIndexChanged="gw_receteler_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                                <asp:BoundField DataField="tarih" HeaderText="Tarih" />
                                <asp:BoundField DataField="hastane_adi" HeaderText="Hastane Adı" />
                                <asp:BoundField DataField="dadsoyad" HeaderText="Doktor Adı Soyadı" />
                                <asp:BoundField DataField="tahsis" HeaderText="Branş" />
                                <asp:BoundField DataField="musteri_id" HeaderText="Hasta TC" />
                                <asp:BoundField DataField="adsoyad" HeaderText="Hasta Adı Soyadı" />
                                <asp:ButtonField ButtonType="Image" CommandName="ilacekle" HeaderText="İlacekle" ImageUrl="~/image/ilacekle.png" />
                                <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="Sil" ImageUrl="~/image/delete.png" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <table class="auto-style1">
                <tr>
                    <td style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;">
                        <table class="auto-style1">
                            <tr>
                                <td style="width:20%;background-color:#808080; color:#fff; font-weight:bolder;">
                                    <asp:Label ID="lbl_recete_tarih" runat="server" Text=""></asp:Label><br/>
                                    <asp:Label ID="lbl_recete_turu" runat="server" Text=""></asp:Label>
                                </td>
                                <td style="width:20%;background-color:#808080; color:#fff; font-weight:bolder;">
                                    <asp:Label ID="lbl_hastane_adi" runat="server" Text=""></asp:Label></td>
                                <td style="width:20%;background-color:#808080; color:#fff; font-weight:bolder;">
                                    <asp:Label ID="lbl_doktor_adi" runat="server" Text=""></asp:Label></td>
                                <td style="width:20%;background-color:#808080; color:#fff; font-weight:bolder;">
                                    <asp:Label ID="lbl_doktor_brans" runat="server" Text=""></asp:Label></td>
                                <td style="width:20%;background-color:#808080; color:#fff; font-weight:bolder;">
                                    <asp:Label ID="lbl_hasta_adi" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
        <asp:Panel ID="pnl_gerekli" runat="server">
            <asp:GridView ID="gw_recete_ilaclari_goruntule" runat="server" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="ilac_id" OnRowCommand="gw_recete_ilaclari_goruntule_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="kategori_adi" HeaderText="KATEGORİ" />
                    <asp:BoundField DataField="adi" HeaderText="İLAÇ ADI" />
                    <asp:BoundField DataField="bfiyat" HeaderText="BİRİM FİYATI" />
                    <asp:BoundField DataField="adet" HeaderText="ADET" />
                    <asp:BoundField DataField="itutar" HeaderText="TUTAR" />
                    <asp:ButtonField ButtonType="Image" CommandName="ilacsil" ImageUrl="~/image/ilacsil.png" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>
        
        <table class="auto-style1">
                <tr>
                    <td style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:right; border:3px double #000;">
                        <asp:Label ID="lbl_r_tutar" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
        </table>
         <asp:Panel ID="recete_ilac_ekle_panel" runat="server">
            <table class="auto-style1">
                 <tr>
                    <td class="auto-style5">İlaç Ara</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style9">
                        <asp:DropDownList ID="ddl_ara" runat="server" CssClass="textbox1" Width="40%">
                            <asp:ListItem Value="0">İsme göre ara</asp:ListItem>
                            <asp:ListItem Value="1">Kategoriye göre ara</asp:ListItem>
                        </asp:DropDownList><asp:TextBox ID="TextBox1" runat="server" CssClass="textbox1" Width="50%"></asp:TextBox></td>
                    <td class="auto-style8" style="width:20%;" ><asp:ImageButton ID="ibtn_" runat="server" ImageUrl="~/image/search.png" OnClick="ibtn__Click"  /></td>
                </tr>
            </table>
            <asp:GridView ID="gw_" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%" DataKeyNames="ilac_id">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="adi" HeaderText="İLAÇ ADI" />
                    <asp:BoundField DataField="kategori_adi" HeaderText="KATEGORİ" />
                    <asp:BoundField DataField="bfiyat" HeaderText="FİYAT" />
                    <asp:BoundField DataField="firma_adi" HeaderText="FİRMA" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
             <table class="auto-style1">
                 <tr>
                    <td style="width:100%; height:60px;">
                        <asp:Label ID="Label1" runat="server" Text="Adet:" CssClass="label"></asp:Label><asp:TextBox ID="tb_r_adet" runat="server" CssClass="textbox1" Width="10%"></asp:TextBox><asp:ImageButton ID="ibtn_rilacekle" runat="server" ImageUrl="~/image/ilacekle.png"  ToolTip="Reçeteye ilaç ekle" OnClick="ibtn_rilacekle_Click" /></td>
                </tr>
             </table>
            </asp:Panel> 
    </div>
   
   
   
</asp:Content>

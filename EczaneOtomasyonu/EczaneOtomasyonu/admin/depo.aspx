<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="depo.aspx.cs" Inherits="EczaneOtomasyonu.admin.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 1%;
            height: 72px;
        }
        .auto-style3 {
            width:20%;
            height: 72px;
            text-align:center;
        }
        .auto-style4 {
            width:79%;
            height:72px
        }
        .gncl {
            width:30%;
            height:auto;
        }
        .gncl1 {
            width:70%;
            height:auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%; width:100%">
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_depo" runat="server" ImageUrl="~/image/depo.png"  ToolTip="Depo Ekle" OnClick="ibtn_depo_Click" AlternateText="Göster"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_dekle" runat="server" ForeColor="White" Font-Size="18px" Text="Depo Ekleme Paneli"></asp:Label></div>
    <asp:Panel ID="pnl_ekle" runat="server">
               <table class="auto-style1">
        <tr>
            <td class="auto-style3">Depo Adı</td>
            <td class="auto-style2">
                :</td>
            <td class="auto-style4">
                <asp:TextBox ID="tb_dadi" runat="server" Width="40%" Height="60%" ForeColor="Black"></asp:TextBox></td>
        </tr>
                    <tr>
            <td class="auto-style3"></td>
            <td class="auto-style2">
                </td>
            <td class="auto-style4" style="text-align:center">
                <asp:ImageButton ID="ibtn_dkaydet" runat="server" ImageUrl="~/image/save.png" ToolTip="Kaydet" OnClick="ibtn_dkaydet_Click" /></td>
        </tr>
    </table>
        </asp:Panel>

         <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_fatura" runat="server" ImageUrl="~/image/fatura.png" ToolTip="Fatura Ekle" OnClick="ibtn_fatura_Click" AlternateText="Göster" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_fekle" runat="server" ForeColor="White" Font-Size="18px" Text="Fatura Ekleme Paneli"></asp:Label></div>
         
    <asp:Panel ID="pnl_fekle" runat="server"> 
        <table class="auto-style1">
             <tr>
                 <td class="auto-style3">Depo Adı</td>
                 <td class="auto-style2">:</td>
                 <td class="auto-style4">
                     <asp:DropDownList ID="ddl_depo" runat="server" DataTextField="depo_adi" DataValueField="depo_id" ForeColor="Black"></asp:DropDownList></td>
             </tr>
           
             <tr>
                 <td class="auto-style3">Tarih</td>
                 <td class="auto-style2">:</td>
                 <td class="auto-style4">
                     <asp:Calendar ID="tarih" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="200px" ShowGridLines="True" Width="220px">
                         <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                         <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                         <OtherMonthDayStyle ForeColor="#CC9966" />
                         <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                         <SelectorStyle BackColor="#FFCC66" />
                         <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                         <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                     </asp:Calendar>
                     <asp:CheckBox ID="cb_tarih" runat="server"  ForeColor="White" Text="Bugünün Tarihini kullan" Width="30%" Height="60%" AutoPostBack="True" OnCheckedChanged="cb_tarih_CheckedChanged"/></td>
             </tr>
             <tr>
                 <td class="auto-style3">&nbsp;</td>
                 <td class="auto-style2">&nbsp;</td>
                 <td class="auto-style4" style="text-align:center;">
                     <asp:ImageButton ID="ibtn_fkaydet" runat="server" ImageUrl="~/image/save.png" ToolTip="Kaydet" OnClick="ibtn_fkaydet_Click" />
                 </td>
             </tr>
         </table></asp:Panel>

     <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
     <asp:ImageButton ID="ibtn_firma" runat="server" ToolTip="Firma Ekle" ImageUrl="~/image/sirket.png" OnClick="ibtn_firma_Click" AlternateText="Göster" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_sekle" runat="server" ForeColor="White" Font-Size="18px" Text="Firma Ekleme Paneli"></asp:Label> </div>
    <asp:Panel ID="pnl_sekle" runat="server">
         <table class="auto-style1">
             <tr>
                 <td class="auto-style3">Firma Adı</td>
                 <td class="auto-style2">:</td>
                 <td class="auto-style4">
                     <asp:TextBox ID="tb_sadi" runat="server" Width="40%" Height="60%"  ForeColor="Black"></asp:TextBox></td>
             </tr>
             <tr>
                 <td class="auto-style3">&nbsp;</td>
                 <td class="auto-style2">&nbsp;</td>
                 <td class="auto-style4" style="text-align:center">
                     <asp:ImageButton ID="ibtn_skaydet" runat="server" ImageUrl="~/image/save.png" ToolTip="Kaydet" OnClick="ibtn_skaydet_Click"/></td>
             </tr>
         </table>
    </asp:Panel>
        <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
 <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/depo.png"  ToolTip="Depo Ekle"  AlternateText="Göster" OnClick="ImageButton1_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="18px" Text="Depo/Fatura Güncelleme Paneli"></asp:Label></div>
        
      
    <asp:Panel ID="pnl_depo_guncelle" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="gncl" style="vertical-align: top">
                <asp:GridView ID="gw_depo" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="100%" AutoGenerateColumns="False" CellSpacing="2" DataKeyNames="depo_id" OnRowCommand="gw_depo_RowCommand">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="depo_adi" HeaderText="DEPO ADI" />
                        <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="DEPO SİL" ImageUrl="~/image/delete.png" />
                        <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="DEPO GÜNCELLE" ImageUrl="~/image/update.png" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </td>
            <td class="gncl1" style="vertical-align: top">
                <asp:GridView ID="gw_fatura" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="100%" AutoGenerateColumns="False" DataKeyNames="fatura_id" OnRowCommand="gw_fatura_RowCommand">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                        <asp:BoundField DataField="depo_adi" HeaderText="DEPO ADI" />
                        <asp:BoundField DataField="tarih" HeaderText="TARİH" />
                        <asp:BoundField DataField="tutar" HeaderText="TUTAR" />
                        <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="FATURA SİL" ImageUrl="~/image/delete.png" />
                        <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="FATURA GÜNCELLE" ImageUrl="~/image/update.png" />
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
        </tr>
    </table>
        </asp:Panel>
         <div style="height:80px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_firmaguncel" runat="server" AlternateText="Göster" ToolTip="Göster" ImageUrl="~/image/sirket.png" OnClick="ibtn_firmaguncel_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_firmaguncel" runat="server" ForeColor="White" Font-Size="18px" Text="Firma Güncelleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_fguncelle" runat="server">
            <asp:GridView ID="gw_firma" runat="server" Width="50%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" DataKeyNames="firma_id" OnRowCommand="gw_firma_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:BoundField DataField="firma_adi" HeaderText="FİRMA ADI" />
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
          </div>
</asp:Content>

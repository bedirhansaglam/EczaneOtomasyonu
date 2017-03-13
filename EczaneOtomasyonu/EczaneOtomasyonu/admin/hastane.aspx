<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="hastane.aspx.cs" Inherits="EczaneOtomasyonu.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 144px;
            height: 60px;
        }
        .auto-style4 {
            height: 60px;
        }
        .auto-style5 {
            width: 144px;
            height: 100px;
        }
        .auto-style6 {
            width: 10px;
            height: 100px;
        }
        .auto-style7 {
            height: 100px;
        }
        .auto-style10 {
            height: 75px;
        }
        .auto-style11 {
            height: 75px;
            width: 144px;
        }
        .auto-style12 {
            height: 75px;
            width: 10px;
        }
        .auto-style13 {
            width: 10px;
            height: 60px;
        }
        .auto-style14 {
            width: 50%;
            height:auto;
        }
        .yuzdeotuz {
            width:30%;
            height:auto;
        }
        .yuzdeyetmis {
            width:70%;
            height:auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%">
        <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_goster" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Hastane/Doktor Ekleme Paneli"></asp:Label></div>
       
        <asp:Panel ID="pnl_ekle" runat="server" >
                <table class="auto-style1">
                    <tr>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
            <td class="auto-style7">
               <asp:ImageButton ID="btn_hastane" runat="server" ImageUrl="~/image/hospital.png" AlternateText="HASTANE EKLE" ToolTip="HASTANE EKLE" OnClick="btn_hastane_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:ImageButton ID="btn_doktor" runat="server" ImageUrl="~/image/doctor.png"  AlternateText="DOKTOR EKLE" ToolTip="DOKTOR EKLE" OnClick="btn_doktor_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:ImageButton ID="ibtn_kaydet" runat="server" ImageUrl="~/image/save.png" ToolTip="KAYDET" OnClick="ibtn_kaydet_Click"/>
               </td>
            
        </tr>
                    <tr>
                        <td class="auto-style11"></td>
                        <td class="auto-style12"></td>
                        <td class="auto-style10">
                            <asp:Label ID="lbl_Baslik" runat="server" Text="HASTANE EKLEME PANELİ" Font-Size="18px" ToolTip="Doktor eklemek için lütfen üstteki doktor ekle butonuna tıklayınız"></asp:Label></td>
                    </tr>
        <tr>
            <td class="auto-style2" style="text-align:center">
                <asp:Label ID="lbl_1" runat="server" Text="Hastane Adı" Font-Size="14px"></asp:Label></td>
            <td class="auto-style13"></td>
            <td class="auto-style4"><asp:TextBox ID="tb_1" runat="server" Height="35px" Width="300px" ForeColor="Black"></asp:TextBox></td>
            
        </tr>
                    <tr>
            <td class="auto-style2" style="text-align:center">
                <asp:Label ID="lbl_2" runat="server" Text="Soyadı" Font-Size="14px"></asp:Label></td>
            <td class="auto-style13"></td>
            <td class="auto-style4"><asp:TextBox ID="tb_2" runat="server" Height="35px" Width="300px" ForeColor="Black"></asp:TextBox></td>
            
        </tr>
                    <tr>
            <td class="auto-style2" style="text-align:center">
                <asp:Label ID="lbl_3" runat="server" Text="Uzmanlık" Font-Size="14px"></asp:Label></td>
            <td class="auto-style13"></td>
            <td class="auto-style4"><asp:TextBox ID="tb_3" runat="server" Height="35px" Width="300px" ForeColor="Black"></asp:TextBox></td>
            
        </tr>
                     <tr>
            <td class="auto-style2" style="text-align:center">
                <asp:Label ID="lbl5" runat="server" Text="TC NO" Font-Size="14px"></asp:Label></td>
            <td class="auto-style13"></td>
            <td class="auto-style4"><asp:TextBox ID="tb_5" runat="server" Height="35px" Width="300px" ForeColor="Black"></asp:TextBox></td>
            
        </tr>
                    <tr>
            <td class="auto-style2" style="text-align:center">
                <asp:Label ID="lbl_4" runat="server" Text="Çalıştığı Hastane" Font-Size="14px"></asp:Label></td>
            <td class="auto-style13"></td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddl_hastane" runat="server" Height="35px" Width="300px" ForeColor="Black" DataTextField="hastane_adi" DataValueField="hastane_id"></asp:DropDownList></td>
            
        </tr>
                  
    </table>
        </asp:Panel>

         <div style="height:60px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
             <asp:ImageButton ID="ibtn_goster1" runat="server" ImageUrl="~/image/goster.png"  ToolTip="Göster/Gizle" OnClick="ibtn_goster1_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="White" Font-Size="18px" Text="Hastane/Doktor Güncelleme Paneli"></asp:Label></div>
        <asp:Panel ID="pnl_guncelle" runat="server">
              <table class="auto-style1">
        <tr>
            <td class="yuzdeotuz">
                <asp:Image ID="img_hastane" runat="server" ImageUrl="~/image/hospital.png" /> <asp:Label ID="lbl_hastane_guncelleme" runat="server" ForeColor="White" Font-Size="14px" Text="HASTANELER"></asp:Label></td>
            <td class="yuzdeyetmis"><asp:Image ID="img_doktor" runat="server"  ImageUrl="~/image/doctor.png"/> <asp:Label ID="lbl_doktor_guncelle" runat="server" ForeColor="White" Font-Size="14px" Text="DOKTORLAR"></asp:Label></td>
        </tr>
                  <tr>
                      <td class="yuzdeotuz" style="vertical-align: top">
                          <asp:GridView ID="gw_hastane" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataKeyNames="hastane_id" OnRowCommand="gw_hastane_RowCommand">
                              <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                  <asp:CommandField HeaderText="SEÇ" ShowSelectButton="True" ButtonType="Button" />
                                  <asp:BoundField DataField="hastane_adi" HeaderText="Hastane Adı" />
                                  <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                                  <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="Güncelle" ImageUrl="~/image/update.png" />
                              </Columns>
                              <EditRowStyle BackColor="#7C6F57" />
                              <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                              <RowStyle BackColor="#E3EAEB" />
                              <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                              <SortedAscendingCellStyle BackColor="#F8FAFA" />
                              <SortedAscendingHeaderStyle BackColor="#246B61" />
                              <SortedDescendingCellStyle BackColor="#D4DFE1" />
                              <SortedDescendingHeaderStyle BackColor="#15524A" />
                          </asp:GridView>
                      </td>
                      <td class="yuzdeyetmis" style="vertical-align: top">
                          <asp:GridView ID="gw_doktor" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="doktor_id" OnRowCommand="gw_doktor_RowCommand">
                              <AlternatingRowStyle BackColor="White" />
                              <Columns>
                                  <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                                  <asp:BoundField DataField="hastane_adi" HeaderText="Hastane Adı" />
                                  <asp:BoundField DataField="adi" HeaderText="Doktor Adı" />
                                  <asp:BoundField DataField="soyadi" HeaderText="Doktor Soyadı" />
                                  <asp:BoundField DataField="tahsis" HeaderText="Uzmanlık Alanı" />
                                  <asp:ButtonField ButtonType="Image" CommandName="sil" HeaderText="SİL" ImageUrl="~/image/delete.png" />
                                  <asp:ButtonField ButtonType="Image" CommandName="guncelle" HeaderText="Güncelle" ImageUrl="~/image/update.png" />
                              </Columns>
                              <EditRowStyle BackColor="#2461BF" />
                              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                              <RowStyle BackColor="#EFF3FB" />
                              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                              <SortedAscendingCellStyle BackColor="#F5F7FB" />
                              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                              <SortedDescendingCellStyle BackColor="#E9EBEF" />
                              <SortedDescendingHeaderStyle BackColor="#4870BE" />
                          </asp:GridView>
                      </td>
                  </tr>
    </table>
        </asp:Panel>
    </div>

  

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="ilac.aspx.cs" Inherits="EczaneOtomasyonu.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 155px;
            height:70px;
            text-align:center;
        }
        .auto-style3 {
            width: 13px;
            height: 70px;
        }

        .auto-style4 {
            height: 70px;
        }
        .textbox {
            width:30%;
            height:60%;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%">
        <div style="height:75px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:ImageButton ID="ibtn_fatura" runat="server"  ImageUrl="~/image/fatura.png" OnClick="ibtn_fatura_Click" AlternateText="Göster"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl_ekle" runat="server" ForeColor="White" Font-Size="18px" Text="Faturalar"></asp:Label></div>
        <asp:Panel ID="pnl_fatura" runat="server">
            <asp:GridView ID="gw_fatura" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="fatura_id" ForeColor="Black" GridLines="Vertical" OnRowCommand="gw_fatura_RowCommand">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:CommandField ButtonType="Button" HeaderText="SEÇ" ShowSelectButton="True" />
                    <asp:BoundField DataField="depo_adi" HeaderText="Depo Adı" />
                    <asp:BoundField DataField="tarih" HeaderText="Tarih" />
                    <asp:ButtonField ButtonType="Image" CommandName="ilacekle" HeaderText="İLAÇ EKLE" ImageUrl="~/image/ilacekle.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="faturagoster" HeaderText="Fatura Göster" ImageUrl="~/image/faturagoster.png" />
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
        <div style="height:50px; background-color:#808080; color:#fff; font-weight:bolder; text-align:left; border:3px double #000;" >
            <asp:Label ID="lbl_depo_adi" runat="server" Text="" Font-Size="20px"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="lbl_tarih" runat="server" Text="" Font-Size="20px"></asp:Label></div>
        <asp:Panel ID="pnl_faturagoster" runat="server">
            <asp:GridView ID="gw_faturagoster" runat="server" Width="100%" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" DataKeyNames="ilac_id" ForeColor="Black" OnRowCommand="gw_faturagoster_RowCommand">
                <Columns>
                    <asp:CommandField HeaderText="SEÇ" ShowSelectButton="True" ButtonType="Button" />
                    <asp:BoundField DataField="kategori_adi" HeaderText="Kategori" />
                    <asp:BoundField DataField="firma_adi" HeaderText="Üretici Firma" />
                    <asp:BoundField DataField="adi" HeaderText="İlaç Adı" />
                    <asp:BoundField DataField="adet" HeaderText="Adet" />
                    <asp:BoundField DataField="bfiyat" HeaderText="Birim Fiyat" />
                    <asp:ButtonField ButtonType="Image" CommandName="ilacsil" HeaderText="İlaç Sil" ImageUrl="~/image/ilacsil.png" />
                    <asp:ButtonField ButtonType="Image" CommandName="ilacguncelle" HeaderText="İlaç Güncelle" ImageUrl="~/image/ilacguncelle.png" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </asp:Panel>
        <div style="height:30px; background-color:#808080; color:#fff; font-weight:bolder; text-align:right; border:3px double #000;" >
            <asp:Label ID="lbl_fiyat" runat="server" Text="" Font-Size="20px"></asp:Label>&nbsp&nbsp&nbsp&nbsp</div>
        <asp:Panel ID="pnl_ekle" runat="server">
            <table class="auto-style1">
                 <tr>
                     <td class="auto-style2">İLAÇ ADI</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="tb_ilacadi" runat="server" CssClass="textbox" ForeColor="Black"></asp:TextBox>
                       </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">İLAÇ ADETİ</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="tb_adet" runat="server" CssClass="textbox" ForeColor="Black"></asp:TextBox>
                       </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">BİRİM FİYAT</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:TextBox ID="tb_bfiyat" runat="server" CssClass="textbox" ForeColor="Black"></asp:TextBox>
                       </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">KATEGORİ</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4">
                         <asp:DropDownList ID="ddl_kategori" runat="server"  Width="30%" Height="60%" DataTextField="kategori_adi" DataValueField="kategori_id" ForeColor="Black"></asp:DropDownList>
                       </td>
                 </tr>
                  <tr>
                     <td class="auto-style2">FİRMA</td>
                     <td class="auto-style3">:</td>
                     <td class="auto-style4"> <asp:DropDownList ID="ddl_firma" runat="server"  Width="30%" Height="60%" ForeColor="Black" DataTextField="firma_adi" DataValueField="firma_id" ></asp:DropDownList>
                       </td>
                 </tr>
                 <tr>
                     <td class="auto-style2">&nbsp;</td>
                     <td class="auto-style3">&nbsp;</td>
                     <td class="auto-style4" style="text-align:center">
                         <asp:ImageButton ID="ibtn_ilackaydet" runat="server" ImageUrl="~/image/save.png" OnClick="ibtn_ilackaydet_Click" /></td>
                 </tr>
             </table>
        </asp:Panel>
       </div>
</asp:Content>

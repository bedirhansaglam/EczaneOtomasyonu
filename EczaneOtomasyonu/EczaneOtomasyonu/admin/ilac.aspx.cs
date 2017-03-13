using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace EczaneOtomasyonu.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    { sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                kategori_cek();
                firma_cek();
                gw_fatura_doldur();
                pnl_ekle.Visible = false;
                pnl_fatura.Visible = false;
            }
        }
          
        
        void kategori_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Kategori", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            ddl_kategori.DataSource = dr;
            ddl_kategori.DataBind();
        }
        void firma_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Firma", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            ddl_firma.DataSource = dr;
            ddl_firma.DataBind();
        }
        void gw_fatura_doldur()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT depo_adi,* FROM Depo,Fatura WHERE Depo.depo_id=Fatura.depo_id ORDER BY tarih DESC", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_fatura.DataSource = dr;
            gw_fatura.DataBind();
        }
        void gw_fatura_goster_doldur()
        {
            SqlCommand cmd = new SqlCommand("SELECT firma_adi,kategori_adi,* FROM Firma,Kategori,Ilac WHERE Firma.firma_id=Ilac.firma AND Kategori.kategori_id=Ilac.kategori AND Ilac.fatura_id=@1 ", baglan.baglan());
            cmd.Parameters.AddWithValue("@1", gw_fatura.SelectedValue);
            SqlDataReader dr = cmd.ExecuteReader();
            gw_faturagoster.DataSource = dr;
            gw_faturagoster.DataBind();
        }
        void fatura_goster_panel_doldur()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT depo_adi,* FROM Depo,Fatura WHERE Depo.depo_id=Fatura.depo_id AND fatura_id=@1", baglan.baglan());
            cmdcek.Parameters.AddWithValue("@1", gw_fatura.SelectedValue);
            SqlDataReader dr = cmdcek.ExecuteReader();
            DataTable dt = new DataTable("Tablo");
            dt.Load(dr);
            lbl_depo_adi.Text ="DEPO ADI : "+ dt.Rows[0]["depo_adi"].ToString();
            lbl_tarih.Text = "FATURA TARİHİ : "+dt.Rows[0]["tarih"].ToString();
            lbl_fiyat.Text = "FATURA TUTARI : " + dt.Rows[0]["tutar"].ToString() + " ₺";
        }
        protected void gw_fatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ilacekle")
            {
                if (gw_fatura.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Faturaya ilaç ekleyebilmek için öncelikle fatura seçilmelidir.');</script>"); }
                else if (gw_fatura.SelectedIndex >= 0)
                {
                    pnl_ekle.Visible = true;
                }
            }
            else if (e.CommandName == "faturagoster")
            { if (gw_fatura.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Faturayı Görüntüleyebilmek için öncelikle fatura seçilmelidir.');</script>"); }
            else if (gw_fatura.SelectedIndex >= 0)
            {

                gw_fatura_goster_doldur();
                fatura_goster_panel_doldur();
                
            }
            }
        }

        protected void ibtn_ilackaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_ilackaydet.ImageUrl == "~/image/save.png")
            {
                double fiyat = double.Parse(tb_bfiyat.Text, CultureInfo.InvariantCulture.NumberFormat) * double.Parse(tb_adet.Text, CultureInfo.InvariantCulture.NumberFormat);
                SqlCommand cmdekle = new SqlCommand("INSERT INTO Ilac(adi,fiyat,kategori,fatura_id,firma,bfiyat,adet) VALUES(@1,@2,@3,@4,@5,@6,@7)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1",tb_ilacadi.Text);
                cmdekle.Parameters.AddWithValue("@2", fiyat);
                cmdekle.Parameters.AddWithValue("@3",int.Parse(ddl_kategori.Text));
                cmdekle.Parameters.AddWithValue("@4",gw_fatura.SelectedValue);
                cmdekle.Parameters.AddWithValue("@5",int.Parse(ddl_firma.Text));
                cmdekle.Parameters.AddWithValue("@6",tb_bfiyat.Text);
                cmdekle.Parameters.AddWithValue("@7", tb_adet.Text);
                cmdekle.ExecuteNonQuery();
                SqlCommand cmdcek = new SqlCommand("SELECT * FROM Fatura WHERE fatura_id=@1", baglan.baglan());
                cmdcek.Parameters.AddWithValue("@1", gw_fatura.SelectedValue);
                SqlDataReader dr = cmdcek.ExecuteReader();
                DataTable dt = new DataTable("Tablo");
                dt.Load(dr);
           
                double tutar=double.Parse(dt.Rows[0]["tutar"].ToString());
                double faturatutaryeni = fiyat + tutar;
                SqlCommand cmdfatura = new SqlCommand("UPDATE Fatura SET tutar=@1 WHERE fatura_id=@2", baglan.baglan());
                cmdfatura.Parameters.AddWithValue("@1", faturatutaryeni);
                cmdfatura.Parameters.AddWithValue("@2", gw_fatura.SelectedValue);
                cmdfatura.ExecuteNonQuery();
                gw_fatura_goster_doldur();
                fatura_goster_panel_doldur();
                tb_adet.Text = "";
                tb_bfiyat.Text = "";
                tb_ilacadi.Text = "";
                pnl_ekle.Visible = false;
               
            }
            else if (ibtn_ilackaydet.ImageUrl == "~/image/update1.png")
            {
                double fiyat = double.Parse(tb_bfiyat.Text, CultureInfo.InvariantCulture.NumberFormat) * double.Parse(tb_adet.Text, CultureInfo.InvariantCulture.NumberFormat);
                SqlCommand cek = new SqlCommand("SELECT fiyat,tutar, tutar-fiyat AS yeni_tutar FROM Ilac,Fatura WHERE ILac.ilac_id=@1 AND Fatura.fatura_id=@2", baglan.baglan());
                cek.Parameters.AddWithValue("@1", gw_faturagoster.SelectedValue);
                cek.Parameters.AddWithValue("@2", gw_fatura.SelectedValue);
                SqlDataReader dr = cek.ExecuteReader();
                DataTable dt = new DataTable("Tablo");
                dt.Load(dr);
                double tutar = double.Parse(dt.Rows[0]["yeni_tutar"].ToString()) + fiyat;

                SqlCommand cmdfatura = new SqlCommand("UPDATE Fatura SET tutar=@1 WHERE fatura_id=@2", baglan.baglan());
                cmdfatura.Parameters.AddWithValue("@1", tutar);
                cmdfatura.Parameters.AddWithValue("@2", gw_fatura.SelectedValue);
                cmdfatura.ExecuteNonQuery();

                SqlCommand cmdguncelle = new SqlCommand("UPDATE Ilac SET adi=@1 ,fiyat=@2,kategori=@3,firma=@4,bfiyat=@5,adet=@6  WHERE ilac_id=@ilac_id", baglan.baglan());
                cmdguncelle.Parameters.AddWithValue("@ilac_id", gw_faturagoster.SelectedValue);
                cmdguncelle.Parameters.AddWithValue("@1", tb_ilacadi.Text);
                cmdguncelle.Parameters.AddWithValue("@2", fiyat);
                cmdguncelle.Parameters.AddWithValue("@3", int.Parse(ddl_kategori.Text));
                cmdguncelle.Parameters.AddWithValue("@4", int.Parse(ddl_firma.Text));
                cmdguncelle.Parameters.AddWithValue("@6", tb_adet.Text);
                cmdguncelle.Parameters.AddWithValue("@5", tb_bfiyat.Text);
                cmdguncelle.ExecuteNonQuery();
                gw_fatura_goster_doldur();
                fatura_goster_panel_doldur();
                tb_adet.Text = "";
                tb_bfiyat.Text = "";
                tb_ilacadi.Text = "";
                pnl_ekle.Visible = false;


            }
        }

        protected void gw_faturagoster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ilacsil")
            {
                if (gw_faturagoster.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Lütfen Silmek için bir ilaç seçin');</script>"); }
                else if (gw_faturagoster.SelectedIndex >= 0)
                {
                    SqlCommand cek = new SqlCommand("SELECT fiyat,tutar, tutar-fiyat AS yeni_tutar FROM Ilac,Fatura WHERE ILac.ilac_id=@1 AND Fatura.fatura_id=@2", baglan.baglan());
                    cek.Parameters.AddWithValue("@1", gw_faturagoster.SelectedValue);
                    cek.Parameters.AddWithValue("@2", gw_fatura.SelectedValue);
                    SqlDataReader dr = cek.ExecuteReader();
                    DataTable dt = new DataTable("Tablo");
                    dt.Load(dr);
                    double tutar = double.Parse(dt.Rows[0]["yeni_tutar"].ToString());

                    SqlCommand cmdfatura = new SqlCommand("UPDATE Fatura SET tutar=@1 WHERE fatura_id=@2", baglan.baglan());
                    cmdfatura.Parameters.AddWithValue("@1", tutar);
                    cmdfatura.Parameters.AddWithValue("@2", gw_fatura.SelectedValue);
                    cmdfatura.ExecuteNonQuery();

                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Ilac WHERE ilac_id=@1 ", baglan.baglan());
                    cmdsil.Parameters.AddWithValue("@1", gw_faturagoster.SelectedValue);
                    cmdsil.ExecuteNonQuery();
                    gw_fatura_goster_doldur();
                    fatura_goster_panel_doldur();
                }
            }
            else if (e.CommandName == "ilacguncelle")
            {
                if (gw_faturagoster.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('ilaç güncellemek için ilaç seçiniz');</script>"); }
                else if (gw_faturagoster.SelectedIndex >= 0)
                {
                    pnl_ekle.Visible = true;
                    ibtn_ilackaydet.ImageUrl = "~/image/update1.png";
                    ibtn_ilackaydet.ToolTip = "GÜNCELLE";
                    ibtn_ilackaydet.AlternateText = "İLAÇ GÜNCELLE";
                    SqlCommand cmdcek=new SqlCommand("SELECT * FROM Ilac WHERE ilac_id=@1",baglan.baglan());
                    cmdcek.Parameters.AddWithValue("@1", gw_faturagoster.SelectedValue);
                    SqlDataReader dr = cmdcek.ExecuteReader();
                    DataTable dt = new DataTable("Tablo");
                    dt.Load(dr);
                    tb_adet.Text=dt.Rows[0]["adet"].ToString();
                    tb_bfiyat.Text=dt.Rows[0]["bfiyat"].ToString();
                    tb_ilacadi.Text=dt.Rows[0]["adi"].ToString();
                    ddl_firma.SelectedValue=dt.Rows[0]["firma"].ToString();
                    ddl_kategori.SelectedValue=dt.Rows[0]["kategori"].ToString();

                }
            }
        }

        protected void ibtn_fatura_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_fatura.AlternateText == "Göster")
            {
                pnl_fatura.Visible = false;
                ibtn_fatura.AlternateText = "Gizle";

            }
            else if (ibtn_fatura.AlternateText == "Gizle")
            {
                pnl_fatura.Visible = true;
                ibtn_fatura.AlternateText = "Göster";
            }
        }
    }
}
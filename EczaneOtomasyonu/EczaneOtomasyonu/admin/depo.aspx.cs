using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EczaneOtomasyonu.admin
{
    public partial class WebForm4 : System.Web.UI.Page
    {  sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                pnl_ekle.Visible = false;
                pnl_fekle.Visible = false;
                pnl_sekle.Visible = false;
                pnl_depo_guncelle.Visible = false;
                pnl_fguncelle.Visible = false;
                depo_cek();
                doldur_gw_depo();
                doldur_gw_fatura();
                doldur_gw_firma();
            }
        }

        protected void ibtn_depo_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_depo.AlternateText == "Göster")
            {
                pnl_ekle.Visible = true;
                ibtn_depo.AlternateText = "Gizle";
            }
            else if (ibtn_depo.AlternateText == "Gizle")
            {
                pnl_ekle.Visible = false;
                ibtn_depo.AlternateText = "Göster";
            }
        }

        protected void ibtn_fatura_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_fatura.AlternateText == "Göster")
            {
                pnl_fekle.Visible = true;
                ibtn_fatura.AlternateText = "Gizle";

            }
            else if (ibtn_fatura.AlternateText == "Gizle")
            {
                pnl_fekle.Visible = false;
                ibtn_fatura.AlternateText = "Göster";
            }
        }

        protected void ibtn_firma_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_firma.AlternateText == "Göster")
            {
                pnl_sekle.Visible = true;
                ibtn_firma.AlternateText = "Gizle";
            }
            else if (ibtn_firma.AlternateText == "Gizle")
            {
                pnl_sekle.Visible = false;
                ibtn_firma.AlternateText = "Göster";

            }
        }

        protected void cb_tarih_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_tarih.Checked)
            { tarih.Enabled = false; }
            else
            {
                tarih.Enabled = true;
            }

        }
        void depo_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * From Depo", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            ddl_depo.DataSource = dr;
            ddl_depo.DataBind();
        }
        void doldur_gw_depo()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * From Depo", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_depo.DataSource = dr;
            gw_depo.DataBind();
        }
        void doldur_gw_fatura()
        { SqlCommand cmdcek=new SqlCommand("SELECT depo_adi,* FROM Depo,Fatura WHERE Depo.depo_id=Fatura.depo_id ORDER BY tarih DESC",baglan.baglan());
          SqlDataReader dr = cmdcek.ExecuteReader();
          gw_fatura.DataSource = dr;
          gw_fatura.DataBind();
        }
        void doldur_gw_firma()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Firma", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_firma.DataSource = dr;
            gw_firma.DataBind();
        }

        protected void ibtn_dkaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_dkaydet.ImageUrl == "~/image/save.png")
            {
                SqlCommand cmdekle = new SqlCommand("INSERT INTO Depo(depo_adi) VALUES(@depo_adi)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@depo_adi", tb_dadi.Text);
                cmdekle.ExecuteNonQuery();
                doldur_gw_depo();
              //  Response.Redirect("depo.aspx");
            }
            else if (ibtn_dkaydet.ImageUrl == "~/image/update1.png")
            {
                SqlCommand cmdupdate = new SqlCommand("UPDATE Depo SET depo_adi=@1 WHERE depo_id=@depo_id", baglan.baglan());
                cmdupdate.Parameters.AddWithValue("@1", tb_dadi.Text);
                cmdupdate.Parameters.AddWithValue("@depo_id", gw_depo.SelectedValue);
                cmdupdate.ExecuteNonQuery();
                Response.Redirect("depo.aspx");

            }
        }

        protected void ibtn_fkaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_fkaydet.ImageUrl == "~/image/save.png")
            {
                if (cb_tarih.Checked)
                {
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO Fatura(depo_id) VALUES(@1) ", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@1", int.Parse(ddl_depo.Text));
                    cmdekle.ExecuteNonQuery();
                    Response.Redirect("depo.aspx");
                }
                else
                {
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO Fatura(depo_id,tarih) VALUES(@1,@3) ", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@1", int.Parse(ddl_depo.Text));
                  
                    cmdekle.Parameters.AddWithValue("@3", tarih.SelectedDate);
                    cmdekle.ExecuteNonQuery();
                    Response.Redirect("depo.aspx");
                }
            }
            else if(ibtn_fkaydet.ImageUrl == "~/image/update1.png")
            {
                if (cb_tarih.Checked)
                {
                    SqlCommand cmdupdate = new SqlCommand("UPDATE Fatura SET depo_id=@1,tarih=@3 WHERE fatura_id=@4 ", baglan.baglan());
                    cmdupdate.Parameters.AddWithValue("@4", gw_fatura.SelectedValue);
                    cmdupdate.Parameters.AddWithValue("@3", DateTime.Now);
                    
                    cmdupdate.Parameters.AddWithValue("@1", int.Parse(ddl_depo.Text));
                    cmdupdate.ExecuteNonQuery();
                    Response.Redirect("depo.aspx");
                }
                else
                {
                    SqlCommand cmdupdate = new SqlCommand("UPDATE Fatura SET depo_id=@1,tarih=@3 WHERE fatura_id=@4 ", baglan.baglan());
                    cmdupdate.Parameters.AddWithValue("@4", gw_fatura.SelectedValue);
                    cmdupdate.Parameters.AddWithValue("@3", tarih.SelectedDate);
                   
                    cmdupdate.Parameters.AddWithValue("@1", int.Parse(ddl_depo.Text));
                    cmdupdate.ExecuteNonQuery();
                    Response.Redirect("depo.aspx");
                }
            }
        }

        protected void ibtn_skaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_skaydet.ImageUrl == "~/image/save.png")
            {
                SqlCommand cmdekle = new SqlCommand("INSERT INTO Firma(firma_adi) VALUES(@1)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1", tb_sadi.Text);
                cmdekle.ExecuteNonQuery();
                doldur_gw_firma();
                Response.Redirect("depo.aspx");
            
            }
            else if (ibtn_skaydet.ImageUrl == "~/image/update1.png")
            {
                SqlCommand cmdupdate = new SqlCommand("UPDATE Firma SET firma_adi=@1 WHERE firma_id=@2", baglan.baglan());
                cmdupdate.Parameters.AddWithValue("@1", tb_sadi.Text);
                cmdupdate.Parameters.AddWithValue("@2", gw_firma.SelectedValue);
                cmdupdate.ExecuteNonQuery();
                Response.Redirect("depo.aspx");
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (ImageButton1.AlternateText == "Göster")
            {
                pnl_depo_guncelle.Visible = true;
                ImageButton1.AlternateText = "Gizle";
            }
            else if (ImageButton1.AlternateText == "Gizle")
            {
                pnl_depo_guncelle.Visible = false;
                ImageButton1.AlternateText = "Göster";
            }

        }

        protected void gw_depo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            { if (gw_depo.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
            else if (gw_depo.SelectedIndex >= 0)
            {
                SqlCommand cmdsil = new SqlCommand("DELETE FROM Depo WHERE depo_id=@depo_id", baglan.baglan());
                cmdsil.Parameters.AddWithValue("@depo_id", gw_depo.SelectedValue);
                cmdsil.ExecuteNonQuery();
                doldur_gw_depo();
                doldur_gw_fatura();
            }
            }
            else if (e.CommandName == "guncelle")
            {if (gw_depo.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
            else if (gw_depo.SelectedIndex >= 0)
            {
                SqlCommand cmdcek = new SqlCommand("SELECT * FROM Depo WHERE depo_id=@depo_id", baglan.baglan());
                cmdcek.Parameters.AddWithValue("@depo_id", gw_depo.SelectedValue);
                lbl_dekle.Text = "DEPO GÜNCELLEME PANELİ";
                pnl_ekle.Visible = true;
                SqlDataReader dr = cmdcek.ExecuteReader();
                DataTable dt = new DataTable("Tablo");
                dt.Load(dr);
                ibtn_dkaydet.ImageUrl = "~/image/update1.png";
                ibtn_dkaydet.ToolTip = "Güncelle";
                tb_dadi.Text = dt.Rows[0]["depo_adi"].ToString();
            }
            }
        }

        protected void gw_fatura_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_fatura.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_fatura.SelectedIndex >= 0)
                {
                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Fatura WHERE fatura_id=@fatura_id", baglan.baglan());
                    cmdsil.Parameters.AddWithValue("@fatura_id", gw_fatura.SelectedValue);
                    cmdsil.ExecuteNonQuery();
                    doldur_gw_fatura();
                }
            }
            else if (e.CommandName == "guncelle")
            { 
                 if (gw_fatura.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                 else if (gw_fatura.SelectedIndex >= 0)
                 {
                     SqlCommand cmdcek = new SqlCommand("SELECT * FROM Fatura WHERE fatura_id=@fatura_id", baglan.baglan());
                     cmdcek.Parameters.AddWithValue("@fatura_id", gw_fatura.SelectedValue);
                     SqlDataReader dr = cmdcek.ExecuteReader();
                     DataTable dt = new DataTable("Tablo");
                     dt.Load(dr);
                     lbl_fekle.Text = "Fatura Güncelleme Paneli";
                     pnl_fekle.Visible = true;
                     ibtn_fkaydet.ImageUrl = "~/image/update1.png";
                     ibtn_fkaydet.ToolTip = "Güncelle";
                     ddl_depo.SelectedValue = dt.Rows[0]["depo_id"].ToString();              
                     tarih.SelectedDate =DateTime.Parse(dt.Rows[0]["tarih"].ToString());
                     
                 }
            }
        }

        protected void ibtn_firmaguncel_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_firmaguncel.AlternateText == "Göster")
            {
                pnl_fguncelle.Visible = true;
                ibtn_firmaguncel.AlternateText = "Gizle";
            }
            else if (ibtn_firmaguncel.AlternateText == "Gizle")
            {
                pnl_fguncelle.Visible = false;
                ibtn_firmaguncel.AlternateText = "Göster";
            }
        }

        protected void gw_firma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_firma.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_firma.SelectedIndex >= 0)
                {
                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Firma WHERE firma_id=@firma_id", baglan.baglan());
                    cmdsil.Parameters.AddWithValue("@firma_id", gw_firma.SelectedValue);
                    cmdsil.ExecuteNonQuery();
                    doldur_gw_firma();
                }
            }
            else if (e.CommandName == "guncelle")
            { 
                if (gw_firma.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_firma.SelectedIndex >= 0)
                {
                    SqlCommand cmdupdate = new SqlCommand("SELECT * FROM Firma WHERE firma_id=@1", baglan.baglan());
                    cmdupdate.Parameters.AddWithValue("@1", gw_firma.SelectedValue);
                    SqlDataReader dr = cmdupdate.ExecuteReader();
                    DataTable dt = new DataTable("Tablo");
                    dt.Load(dr);
                    pnl_sekle.Visible = true;
                    lbl_sekle.Text = "Firma Güncelleme Paneli";
                    ibtn_skaydet.ImageUrl = "~/image/update1.png";
                    ibtn_skaydet.ToolTip = "Güncelle";
                    tb_sadi.Text = dt.Rows[0]["firma_adi"].ToString();
                
                }
            }
        }


        
    }
}
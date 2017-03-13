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
    public partial class WebForm1 : System.Web.UI.Page
    { sqlbaglantisi baglan = new sqlbaglantisi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gw_hastane_cek();
                gw_doktor_cek();
                hastane_cek();
                pnl_ekle.Visible = false;
                pnl_guncelle.Visible = false;
                btn_hastane.Enabled = false;
                lbl_2.Visible = false;
                lbl_3.Visible = false;
                lbl_4.Visible = false;
                lbl5.Visible = false;
                tb_2.Visible = false;
                tb_3.Visible = false;
                tb_5.Visible = false;
                ddl_hastane.Visible = false;
            }
        }

        protected void btn_doktor_Click(object sender, ImageClickEventArgs e)
        {
            btn_doktor.Enabled = false;
            btn_hastane.Enabled = true;
            lbl_2.Visible = true;
            lbl_3.Visible = true;
            lbl_4.Visible = true;
            lbl5.Visible = true;
            tb_5.Visible = true;
            tb_2.Visible = true;
            tb_3.Visible = true;
            ddl_hastane.Visible = true;
            lbl_1.Text = "Adı";
            lbl_Baslik.Text = "DOKTOR EKLEME PANELİ";
        }

        protected void btn_hastane_Click(object sender, ImageClickEventArgs e)
        {
            btn_doktor.Enabled = true;
            btn_hastane.Enabled = false;
            lbl_2.Visible = false;
            lbl_3.Visible = false;
            lbl_4.Visible = false;
            lbl5.Visible = false;
            tb_2.Visible = false;
            tb_3.Visible = false;
            tb_5.Visible = false;
            ddl_hastane.Visible = false;
            lbl_1.Text = "Hastane Adı";
            lbl_Baslik.Text = "HASTANE EKLEME PANELİ";
        }

        protected void ibtn_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster.ImageUrl == "~/image/goster.png")
            {
                pnl_ekle.Visible = true;
                ibtn_goster.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster.ImageUrl == "~/image/gizle.png")
            {
                pnl_ekle.Visible = false;
                ibtn_goster.ImageUrl = "~/image/goster.png";

            }
        }
        void hastane_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Hastane",baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            ddl_hastane.DataSource = dr;
            ddl_hastane.DataBind();
        }
        void gw_hastane_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Hastane", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_hastane.DataSource = dr;
            gw_hastane.DataBind();
        }
        void gw_doktor_cek()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT Hastane.hastane_adi,* FROM Hastane ,Doktor WHERE Hastane.hastane_id=Doktor.hastane_id", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_doktor.DataSource = dr;
            gw_doktor.DataBind();
        }

        protected void ibtn_kaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_kaydet.ImageUrl=="~/image/save.png")//panel kayıt etmek için kullanılacaksa
            {
                if (lbl_Baslik.Text == "DOKTOR EKLEME PANELİ")//doktor kaydetmek için
                {
                    SqlCommand cmdekle = new SqlCommand("INSERT INTO Doktor(doktor_id,adi,soyadi,tahsis,hastane_id) VALUES(@1,@2,@3,@4,@5)", baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@1", tb_5.Text);
                    cmdekle.Parameters.AddWithValue("@2", tb_1.Text);
                    cmdekle.Parameters.AddWithValue("@3", tb_2.Text);
                    cmdekle.Parameters.AddWithValue("@4", tb_3.Text);
                    cmdekle.Parameters.AddWithValue("@5", int.Parse(ddl_hastane.Text));
                    cmdekle.ExecuteNonQuery();
                    Response.Redirect("hastane.aspx");


                }
                else if (lbl_Baslik.Text == "HASTANE EKLEME PANELİ")//hastane kaydetmek için
                { 
                    SqlCommand cmdekle=new SqlCommand("INSERT INTO Hastane(hastane_adi) VALUES(@hastane_adi)",baglan.baglan());
                    cmdekle.Parameters.AddWithValue("@hastane_adi", tb_1.Text);
                    cmdekle.ExecuteNonQuery();
                    Response.Redirect("hastane.aspx");

                }
            }
            else if (ibtn_kaydet.ImageUrl == "~/image/update1.png")//panel güncellemek için kullanılacaksa
            {
                if (lbl_Baslik.Text == "DOKTOR GÜNCELLEME PANELİ")//doktor güncellemek için
                {
                    SqlCommand cmdguncel = new SqlCommand("UPDATE Doktor SET adi=@adi , soyadi=@soy,tahsis=@t ,hastane_id=@hastane_id WHERE doktor_id=@doktor_id", baglan.baglan());
                    cmdguncel.Parameters.AddWithValue("@adi", tb_1.Text);
                    cmdguncel.Parameters.AddWithValue("@soy",tb_2.Text);
                    cmdguncel.Parameters.AddWithValue("@t",tb_3.Text);
                    cmdguncel.Parameters.AddWithValue("@hastane_id",int.Parse(ddl_hastane.Text));
                    cmdguncel.Parameters.AddWithValue("@doktor_id", gw_doktor.SelectedValue);
                    cmdguncel.ExecuteNonQuery();
                    Response.Redirect("hastane.aspx");
                }
                else if (lbl_Baslik.Text == "HASTANE GÜNCELLEME PANELİ")//hastane güncellemek için
                {
                    SqlCommand cmdguncel=new SqlCommand("UPDATE Hastane SET hastane_adi=@hastane_adi WHERE hastane_id=@hastane_id",baglan.baglan());
                    cmdguncel.Parameters.AddWithValue("@hastane_adi", tb_1.Text);
                    cmdguncel.Parameters.AddWithValue("@hastane_id", gw_hastane.SelectedValue);
                    cmdguncel.ExecuteNonQuery();
                    Response.Redirect("hastane.aspx");
                }
            }
        }

        protected void ibtn_goster1_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_goster1.ImageUrl == "~/image/goster.png")
            {
                pnl_guncelle.Visible = true;
                ibtn_goster1.ImageUrl = "~/image/gizle.png";
            }
            else if (ibtn_goster1.ImageUrl == "~/image/gizle.png")
            {
                pnl_guncelle.Visible = false;
                ibtn_goster1.ImageUrl = "~/image/goster.png";

            }

        }

        protected void gw_hastane_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_hastane.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_hastane.SelectedIndex >= 0)
                {
                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Hastane WHERE hastane_id=@hastane_id", baglan.baglan());
                    cmdsil.Parameters.AddWithValue("@hastane_id", gw_hastane.SelectedValue);
                    cmdsil.ExecuteNonQuery();
                    gw_hastane_cek();
                    gw_doktor_cek();
                }
            
            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_hastane.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı güncellemek için lütfen satır seçiniz');</script>"); }
                else if (gw_hastane.SelectedIndex >= 0)
                {
                    SqlCommand cmdguncel = new SqlCommand("SELECT * FROM Hastane WHERE hastane_id=@hastane_id", baglan.baglan());
                    cmdguncel.Parameters.AddWithValue("@hastane_id", gw_hastane.SelectedValue);
                    SqlDataReader dr = cmdguncel.ExecuteReader();
                    DataTable dt = new DataTable("Tablo");
                    dt.Load(dr);
                    
                    pnl_ekle.Visible = true;
                    ibtn_kaydet.ImageUrl = "~/image/update1.png";
                    ibtn_kaydet.ToolTip = "Güncelle";
                    btn_doktor.Enabled = true;
                    btn_hastane.Enabled = false;
                    lbl_2.Visible = false;
                    lbl_3.Visible = false;
                    lbl_4.Visible = false;
                    lbl5.Visible = false;
                    tb_2.Visible = false;
                    tb_3.Visible = false;
                    tb_5.Visible = false;
                    ddl_hastane.Visible = false;
                    lbl_1.Text = "Hastane Adı";
                    lbl_Baslik.Text = "HASTANE GÜNCELLEME PANELİ";
                    tb_1.Text = dt.Rows[0]["hastane_adi"].ToString();
                   
                   
                }
            }
        }

        protected void gw_doktor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_doktor.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı güncellemek için lütfen satır seçiniz');</script>"); }
                else if(gw_doktor.SelectedIndex>=0)
                {
                
                SqlCommand cmdsil = new SqlCommand("DELETE FROM Doktor WHERE doktor_id=@doktor_id", baglan.baglan());
                cmdsil.Parameters.AddWithValue("@doktor_id", gw_doktor.SelectedValue);
                cmdsil.ExecuteNonQuery();
                gw_doktor_cek();
                }

            }
            else if (e.CommandName == "guncelle")
            {
                if (gw_doktor.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı güncellemek için lütfen satır seçiniz');</script>"); }
                 else if(gw_doktor.SelectedIndex>=0)
                {
                SqlCommand cmdcek = new SqlCommand("SELECT * FROM Doktor WHERE doktor_id=@doktor_id", baglan.baglan());
                cmdcek.Parameters.AddWithValue("@doktor_id", gw_doktor.SelectedValue);
                SqlDataReader dr = cmdcek.ExecuteReader();
                DataTable dt = new DataTable("tb");
                dt.Load(dr);

                pnl_ekle.Visible = true;
                ibtn_kaydet.ImageUrl = "~/image/update1.png";
                ibtn_kaydet.ToolTip = "Güncelle";
                btn_doktor.Enabled = false;
                btn_hastane.Enabled = true;
                lbl_2.Visible = true;
                lbl_3.Visible = true;
                lbl_4.Visible = true;
                lbl5.Visible = true;
                tb_5.Visible = true;
                tb_2.Visible = true;
                tb_3.Visible = true;
                ddl_hastane.Visible = true;
                lbl_1.Text = "Adı";
                lbl_Baslik.Text = "DOKTOR GÜNCELLEME PANELİ";
                tb_1.Text = dt.Rows[0]["adi"].ToString();
                tb_2.Text = dt.Rows[0]["soyadi"].ToString();
                tb_3.Text = dt.Rows[0]["tahsis"].ToString();
                tb_5.Text = dt.Rows[0]["doktor_id"].ToString(); tb_5.Enabled = false;
                hastane_cek();
                }
            }
        }
    }
}
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
    public partial class WebForm3 : System.Web.UI.Page
    {   sqlbaglantisi baglan = new sqlbaglantisi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnl_musteri_ekle.Visible = false;
                pnl_musteri_duzenle.Visible = false;
                pnl_satis.Visible = false;
                pnl_fis.Visible = false;
                pnl_fisler.Visible = false;
                gw_musteri_doldur();
                satiscek();

                pnl_recete_ilac_ekle.Visible = false;
                pnl_recete_ekle.Visible = false;
                recete_ilac_ekle_panel.Visible = false;
                gw_hasta_doldur();
                gw_recetedoldur();
                recete_turu_cek();
                hastane_cek();

            }

        }

        protected void ibtn_musteri_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_musteri.AlternateText == "Göster")
            {
                pnl_musteri_ekle.Visible = true;
                ibtn_musteri.AlternateText = "Gizle";
            }
            else if (ibtn_musteri.AlternateText == "Gizle")
            {
                pnl_musteri_ekle.Visible = false;
                ibtn_musteri.AlternateText = "Göster";
            }
        }
        void gw_musteri_doldur()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Musteri", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_musteri_duzenle.DataSource = dr;
            gw_musteri_duzenle.DataBind();
        }
        void gw_hasta_doldur()
        {
            SqlCommand cmdcek = new SqlCommand("SELECT * FROM Musteri", baglan.baglan());
            SqlDataReader dr = cmdcek.ExecuteReader();
            gw_hastalar.DataSource = dr;
            gw_hastalar.DataBind();
        }
        protected void ibtn_m_kaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_m_kaydet.ImageUrl == "~/image/save.png")
            {
                SqlCommand cmdekle = new SqlCommand("INSERT INTO Musteri(TC_NO,adi,soyadi,adres) VALUES(@1,@2,@3,@4)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1",tb_tcno.Text);
                cmdekle.Parameters.AddWithValue("@2",tb_adi.Text);
                cmdekle.Parameters.AddWithValue("@3",tb_soyadi.Text);
                cmdekle.Parameters.AddWithValue("@4", tb_adres.Text);
                cmdekle.ExecuteNonQuery();
                Response.Redirect("satis.aspx");

            }
            else if(ibtn_m_kaydet.ImageUrl == "~/image/update1.png")
            {
                SqlCommand cmdguncel = new SqlCommand("UPDATE Musteri SET TC_NO=@1, adi=@2 ,soyadi=@3 ,adres=@4 WHERE TC_NO=@5", baglan.baglan());
                cmdguncel.Parameters.AddWithValue("@1",tb_tcno.Text);
                cmdguncel.Parameters.AddWithValue("@2",tb_adi.Text);
                cmdguncel.Parameters.AddWithValue("@3",tb_soyadi.Text);
                cmdguncel.Parameters.AddWithValue("@4",tb_adres.Text);
                cmdguncel.Parameters.AddWithValue("@5", gw_musteri_duzenle.SelectedValue);
                cmdguncel.ExecuteNonQuery();
                Response.Redirect("satis.aspx");

            }
        }

        protected void ibtn_musteri_guncelle_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_musteri_guncelle.AlternateText == "Göster")
            {
                pnl_musteri_duzenle.Visible = true;
                ibtn_musteri_guncelle.AlternateText = "Gizle"; }
            else if (ibtn_musteri_guncelle.AlternateText == "Gizle")
            {
                pnl_musteri_duzenle.Visible = false;
                ibtn_musteri_guncelle.AlternateText = "Göster"; }
        }

        protected void gw_musteri_duzenle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_musteri_duzenle.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Müşteriyi Silmek İçin ilk önce onu Seçiniz');</script>"); }
                else if (gw_musteri_duzenle.SelectedIndex >= 0)
                {
                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Musteri WHERE TC_NO=@1", baglan.baglan());
                    cmdsil.Parameters.AddWithValue("@1", gw_musteri_duzenle.SelectedValue);
                    cmdsil.ExecuteNonQuery();
                    gw_musteri_doldur(); 
                }
            }
            else if (e.CommandName == "guncelle")
            {
                 if (gw_musteri_duzenle.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Müşteriyi Güncellemek İçin ilk önce onu Seçiniz');</script>"); }
                 else if (gw_musteri_duzenle.SelectedIndex >= 0)
                 {
                     SqlCommand cmdcek = new SqlCommand("SELECT * FROM Musteri WHERE TC_NO=@1", baglan.baglan());
                     cmdcek.Parameters.AddWithValue("@1", gw_musteri_duzenle.SelectedValue);
                     SqlDataReader dr = cmdcek.ExecuteReader();
                     DataTable dt = new DataTable("Tablo");
                     dt.Load(dr);
                     pnl_musteri_ekle.Visible = true;
                     lbl_musteri_ekle.Text = "Müşteri Güncelleme Paneli";
                     ibtn_m_kaydet.ImageUrl = "~/image/update1.png";
                     ibtn_m_kaydet.ToolTip = "Güncelle";
                     ibtn_m_kaydet.AlternateText = "Güncelle";
                     tb_tcno.Text = dt.Rows[0]["TC_NO"].ToString();
                     tb_adi.Text = dt.Rows[0]["adi"].ToString();
                     tb_soyadi.Text = dt.Rows[0]["soyadi"].ToString();
                     tb_adres.Text = dt.Rows[0]["adres"].ToString();
                 }
            }
        }

        protected void ibtn_musteri_ara_Click(object sender, ImageClickEventArgs e)
        {
            if (ddl_musteri_ara.SelectedIndex == 0)//TCile ara
            {
                gw_musteri.SelectedIndex = -1;
            SqlCommand mustericek=new SqlCommand("SELECT * FROM Musteri WHERE TC_NO LIKE '%"+tb_musteri_ara.Text+"%'",baglan.baglan());
            SqlDataReader dr = mustericek.ExecuteReader();
            gw_musteri.DataSource = dr;
            gw_musteri.DataBind();
            }
            else if (ddl_musteri_ara.SelectedIndex == 1)// isim ile ara
            {
                gw_musteri.SelectedIndex = -1;
                SqlCommand mustericek = new SqlCommand("SELECT * FROM Musteri WHERE adi LIKE '%" + tb_musteri_ara.Text + "%'", baglan.baglan());
                SqlDataReader dr = mustericek.ExecuteReader();
                gw_musteri.DataSource = dr;
                gw_musteri.DataBind();
            }
        }

        protected void ibtn_ilac_ara_Click(object sender, ImageClickEventArgs e)
        {
            if (ddl_ilac.SelectedIndex == 0)//isme göre ara
            {
                gw_ilac.SelectedIndex = -1;
                SqlCommand ilaccek=new SqlCommand("SELECT *,kategori_adi,firma_adi FROM Ilac,Kategori,Firma WHERE adi LIKE '%"+tb_ilac_ara.Text+"%' AND Kategori.kategori_id=Ilac.kategori AND Firma.firma_id=Ilac.firma",baglan.baglan());
                SqlDataReader dr=ilaccek.ExecuteReader();
                gw_ilac.DataSource=dr;
                gw_ilac.DataBind();
            }
            else if (ddl_ilac.SelectedIndex == 1)//kategoriye göre ara
            {
                gw_ilac.SelectedIndex = -1; SqlCommand ilaccek = new SqlCommand("SELECT Ilac.*,kategori_adi,firma_adi FROM Ilac,Kategori,Firma WHERE kategori_adi LIKE '%" + tb_ilac_ara.Text + "%' AND Kategori.kategori_id=Ilac.kategori AND Firma.firma_id=Ilac.firma", baglan.baglan());
                SqlDataReader dr=ilaccek.ExecuteReader();
                gw_ilac.DataSource=dr;
                gw_ilac.DataBind(); 
            }
        }

        protected void ibtn_satis_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_satis.AlternateText == "Göster")
            {
                pnl_satis.Visible = true;
                ibtn_satis.AlternateText = "Gizle";
            }
            else if (ibtn_satis.AlternateText == "Gizle")
            {
                pnl_satis.Visible = false;
                ibtn_satis.AlternateText = "Göster";
            }
        }

        protected void ibtn_fis_ekle_Click(object sender, ImageClickEventArgs e)
        {
            pnl_fis.Visible = true;
            pnl_satis.Visible = false;
            if (cb_tarih.Checked)
            {
                lbl_tarih.Text = DateTime.Now.ToString();
                SqlCommand fisekle = new SqlCommand("INSERT INTO Satis(tarih,musteri_id) VALUES(@1,@2)", baglan.baglan());
                fisekle.Parameters.AddWithValue("@1", DateTime.Now);
                fisekle.Parameters.AddWithValue("@2", gw_musteri.SelectedValue);
                fisekle.ExecuteNonQuery();
            }
            else
            {
                SqlCommand fisekle = new SqlCommand("INSERT INTO Satis(tarih,musteri_id) VALUES(@1,@2)", baglan.baglan());
                fisekle.Parameters.AddWithValue("@1", tarih.SelectedDate);
                fisekle.Parameters.AddWithValue("@2", gw_musteri.SelectedValue);
                fisekle.ExecuteNonQuery();
                lbl_tarih.Text = tarih.SelectedDate.ToShortDateString();
            }

            SqlCommand mustericek = new SqlCommand("SELECT * FROM Musteri WHERE TC_NO=@1", baglan.baglan());
            mustericek.Parameters.AddWithValue("@1", gw_musteri.SelectedValue);
            SqlDataReader dr = mustericek.ExecuteReader();
            DataTable dt = new DataTable("Tablo");
            dt.Load(dr);
            lbl_musteri.Text = dt.Rows[0]["adi"].ToString() + " " + dt.Rows[0]["soyadi"].ToString() + "   " + dt.Rows[0]["adres"].ToString();

            if (cb_tarih.Checked)
            {
                SqlCommand cek=new SqlCommand("SELECT * FROM Satis",baglan.baglan());
                SqlDataReader dtr = cek.ExecuteReader();
                DataTable dtble = new DataTable("1");
                dtble.Load(dtr);
                lbl_tutar.Text = "TUTAR:" + dtble.Rows[dtble.Rows.Count-1]["tutar"].ToString();
                lbl_fis_id.Text = dtble.Rows[dtble.Rows.Count - 1]["fis_id"].ToString();
            }
            else
            {
                SqlCommand fiscek = new SqlCommand("SELECT * FROM Satis WHERE musteri_id=@1 AND tarih=@2", baglan.baglan());
                fiscek.Parameters.AddWithValue("@1", gw_musteri.SelectedValue);
                fiscek.Parameters.AddWithValue("@2", tarih.SelectedDate);
                SqlDataReader drfis = fiscek.ExecuteReader();
                DataTable dtfis = new DataTable("tbl");
                dtfis.Load(drfis);
                lbl_tutar.Text ="TUTAR:" + dtfis.Rows[0]["tutar"].ToString();
                lbl_fis_id.Text = dtfis.Rows[0]["fis_id"].ToString();
            }
        }

        protected void cb_tarih_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_tarih.Checked)
                tarih.Enabled = false;
            else tarih.Enabled = true;
        }

      

        protected void ibtn_ilacekle_Click(object sender, ImageClickEventArgs e)
        {
            if (cb_tarih.Checked)
            {
                SqlCommand cek = new SqlCommand("SELECT * FROM Satis", baglan.baglan());
                SqlDataReader dtr = cek.ExecuteReader();
                DataTable dtble = new DataTable("1");
                dtble.Load(dtr);
             

                SqlCommand cmdekle = new SqlCommand("INSERT INTO Direksatis_Ilaclari(fis_id,ilac_id,adet) VALUES(@1,@2,@3)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1", int.Parse(dtble.Rows[dtble.Rows.Count-1]["fis_id"].ToString()));
                cmdekle.Parameters.AddWithValue("@2", gw_ilac.SelectedValue);
                cmdekle.Parameters.AddWithValue("@3", tb_adet.Text);
                cmdekle.ExecuteNonQuery();

                SqlCommand doldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat," + tb_adet.Text + "AS adet,bfiyat*" + tb_adet.Text + " AS tutar FROM Kategori,Ilac WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=" + gw_ilac.SelectedValue + "", baglan.baglan());
                SqlDataReader dr = doldur.ExecuteReader();
                DataTable dt = new DataTable("tb");
                dt.Load(dr);

                SqlCommand denedoldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat, Direksatis_Ilaclari.adet,Direksatis_Ilaclari.ilac_id,bfiyat*Direksatis_Ilaclari.adet AS tutar FROM Kategori,Ilac,Direksatis_Ilaclari WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=Direksatis_Ilaclari.ilac_id AND Direksatis_Ilaclari.fis_id=@1", baglan.baglan());
                denedoldur.Parameters.AddWithValue("@1", int.Parse(dtble.Rows[dtble.Rows.Count - 1]["fis_id"].ToString()));
                SqlDataReader dene = denedoldur.ExecuteReader();
                gw_fis_ilaclari.DataSource = dene;
                gw_fis_ilaclari.DataBind();

                double yenitutar = double.Parse(dtble.Rows[dtble.Rows.Count - 1]["tutar"].ToString()) + double.Parse(dt.Rows[0]["tutar"].ToString());
                lbl_tutar.Text = "TUTAR : " + yenitutar.ToString();
                SqlCommand fisguncelle = new SqlCommand("UPDATE Satis SET tutar=@1 WHERE fis_id=@2", baglan.baglan());
                fisguncelle.Parameters.AddWithValue("@1", yenitutar);
                fisguncelle.Parameters.AddWithValue("@2", int.Parse(dtble.Rows[dtble.Rows.Count - 1]["fis_id"].ToString()));
                fisguncelle.ExecuteNonQuery();
                satiscek();
            }
            else if (lbl_tarih.Text != "")
            {
                SqlCommand fiscek = new SqlCommand("SELECT * FROM Satis WHERE fis_id="+int.Parse(lbl_fis_id.Text)+"", baglan.baglan());
                
                SqlDataReader drfis = fiscek.ExecuteReader();
                DataTable dtfis = new DataTable("tbl");
                dtfis.Load(drfis);


                SqlCommand cmdekle = new SqlCommand("INSERT INTO Direksatis_Ilaclari(fis_id,ilac_id,adet) VALUES(@1,@2,@3)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1", int.Parse(lbl_fis_id.Text));
                cmdekle.Parameters.AddWithValue("@2", gw_ilac.SelectedValue);
                cmdekle.Parameters.AddWithValue("@3", tb_adet.Text);
                cmdekle.ExecuteNonQuery();

                SqlCommand doldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat," + tb_adet.Text + "AS adet,bfiyat*" + tb_adet.Text + " AS tutar FROM Kategori,Ilac WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=" + gw_ilac.SelectedValue + "", baglan.baglan());
                SqlDataReader dr = doldur.ExecuteReader();
                DataTable dt = new DataTable("tb");
                dt.Load(dr);
                SqlCommand denedoldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat, Direksatis_Ilaclari.adet,Direksatis_Ilaclari.ilac_id,bfiyat*Direksatis_Ilaclari.adet AS tutar FROM Kategori,Ilac,Direksatis_Ilaclari WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=Direksatis_Ilaclari.ilac_id AND Direksatis_Ilaclari.fis_id=@1", baglan.baglan());
                denedoldur.Parameters.AddWithValue("@1", int.Parse(lbl_fis_id.Text));
                SqlDataReader dene = denedoldur.ExecuteReader();
                gw_fis_ilaclari.DataSource = dene;
                gw_fis_ilaclari.DataBind();

                double yenitutar = double.Parse(dtfis.Rows[0]["tutar"].ToString()) + double.Parse(dt.Rows[0]["tutar"].ToString());
                lbl_tutar.Text = "TUTAR : " + yenitutar.ToString();
                SqlCommand fisguncelle = new SqlCommand("UPDATE Satis SET tutar=@1 WHERE fis_id=@2", baglan.baglan());
                fisguncelle.Parameters.AddWithValue("@1", yenitutar);
                fisguncelle.Parameters.AddWithValue("@2", int.Parse(lbl_fis_id.Text));
                fisguncelle.ExecuteNonQuery();
                satiscek();
            }
            else 
            {
                SqlCommand fiscek = new SqlCommand("SELECT * FROM Satis WHERE musteri_id=@1 AND tarih=@2", baglan.baglan());
                fiscek.Parameters.AddWithValue("@1", gw_musteri.SelectedValue);
                fiscek.Parameters.AddWithValue("@2", tarih.SelectedDate);
                SqlDataReader drfis = fiscek.ExecuteReader();
                DataTable dtfis = new DataTable("tbl");
                dtfis.Load(drfis);


                SqlCommand cmdekle = new SqlCommand("INSERT INTO Direksatis_Ilaclari(fis_id,ilac_id,adet) VALUES(@1,@2,@3)", baglan.baglan());
                cmdekle.Parameters.AddWithValue("@1", int.Parse(dtfis.Rows[0]["fis_id"].ToString()));
                cmdekle.Parameters.AddWithValue("@2", gw_ilac.SelectedValue);
                cmdekle.Parameters.AddWithValue("@3", tb_adet.Text);
                cmdekle.ExecuteNonQuery();

                SqlCommand doldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat," + tb_adet.Text + "AS adet,bfiyat*" + tb_adet.Text + " AS tutar FROM Kategori,Ilac WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=" + gw_ilac.SelectedValue + "", baglan.baglan());
                SqlDataReader dr = doldur.ExecuteReader();
                DataTable dt = new DataTable("tb");
                dt.Load(dr);
                SqlCommand denedoldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat, Direksatis_Ilaclari.adet,Direksatis_Ilaclari.ilac_id,bfiyat*Direksatis_Ilaclari.adet AS tutar FROM Kategori,Ilac,Direksatis_Ilaclari WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=Direksatis_Ilaclari.ilac_id AND Direksatis_Ilaclari.fis_id=@1", baglan.baglan());
                denedoldur.Parameters.AddWithValue("@1", int.Parse(dtfis.Rows[0]["fis_id"].ToString()));
                SqlDataReader dene = denedoldur.ExecuteReader();
                gw_fis_ilaclari.DataSource = dene;
                gw_fis_ilaclari.DataBind();

                double yenitutar = double.Parse(dtfis.Rows[0]["tutar"].ToString()) + double.Parse(dt.Rows[0]["tutar"].ToString());
                lbl_tutar.Text = "TUTAR : " + yenitutar.ToString();
                SqlCommand fisguncelle = new SqlCommand("UPDATE Satis SET tutar=@1 WHERE fis_id=@2", baglan.baglan());
                fisguncelle.Parameters.AddWithValue("@1", yenitutar);
                fisguncelle.Parameters.AddWithValue("@2", int.Parse(dtfis.Rows[0]["fis_id"].ToString()));
                fisguncelle.ExecuteNonQuery();
                satiscek();
            }
            
        }
        void fis_ilaclari_doldur()
        {
            SqlCommand denedoldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat, Direksatis_Ilaclari.adet,Direksatis_Ilaclari.ilac_id,bfiyat*Direksatis_Ilaclari.adet AS tutar FROM Kategori,Ilac,Direksatis_Ilaclari WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=Direksatis_Ilaclari.ilac_id AND Direksatis_Ilaclari.fis_id=@1", baglan.baglan());
            denedoldur.Parameters.AddWithValue("@1", int.Parse(lbl_fis_id.Text));
            SqlDataReader dene = denedoldur.ExecuteReader();
            gw_fis_ilaclari.DataSource = dene;
            gw_fis_ilaclari.DataBind();
        }
        void satiscek()
        {
            SqlCommand cek = new SqlCommand("SELECT Satis.*,Musteri.* FROM Musteri,Satis WHERE Satis.musteri_id=Musteri.TC_NO ORDER BY fis_id ", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            gw_fis.DataSource = dr;
            gw_fis.DataBind();

        }

        protected void gw_fis_ilaclari_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ilacsil")
            {
                if (gw_fis_ilaclari.SelectedIndex == -1)
                {
                    Response.Write("<script lang='JavaScript'>alert ('İlaç silmek için lütfen önce ilaç seçiniz');</script>");
                }
                else if (gw_fis_ilaclari.SelectedIndex >= 0)
                {
                    SqlCommand tutarcek = new SqlCommand("SELECT Satis.tutar,Ilac.bfiyat*Direksatis_Ilaclari.adet AS ilactutar FROM Satis,Direksatis_Ilaclari,Ilac WHERE Satis.fis_id=@1 AND Direksatis_Ilaclari.fis_id=Satis.fis_id AND Direksatis_Ilaclari.ilac_id=Ilac.ilac_id AND Ilac.ilac_id=@2 ", baglan.baglan());
                    tutarcek.Parameters.AddWithValue("@1",int.Parse(lbl_fis_id.Text));
                    tutarcek.Parameters.AddWithValue("@2",gw_fis_ilaclari.SelectedValue);
                    SqlDataReader dr = tutarcek.ExecuteReader();
                    DataTable dt = new DataTable("tbl");
                    dt.Load(dr);

                    double yenitutar = double.Parse(dt.Rows[0]["tutar"].ToString()) - double.Parse(dt.Rows[0]["ilactutar"].ToString());
                    lbl_tutar.Text = "TUTAR : " + yenitutar.ToString();

                    SqlCommand satisguncel = new SqlCommand("UPDATE Satis SET tutar=@1 WHERE fis_id=@2", baglan.baglan());
                    satisguncel.Parameters.AddWithValue("@1", yenitutar);
                    satisguncel.Parameters.AddWithValue("@2", int.Parse(lbl_fis_id.Text));
                    satisguncel.ExecuteNonQuery();

                    SqlCommand ilacsil = new SqlCommand("DELETE FROM Direksatis_Ilaclari WHERE Direksatis_Ilaclari.ilac_id=@1", baglan.baglan());
                    ilacsil.Parameters.AddWithValue("@1", gw_fis_ilaclari.SelectedValue);
                    ilacsil.ExecuteNonQuery();
                    fis_ilaclari_doldur();
                    satiscek();

                }
            }
        }

        protected void gw_fis_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                if (gw_fis.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_fis.SelectedIndex >= 0)
                {
                    SqlCommand cmdsil = new SqlCommand("DELETE FROM Satis WHERE fis_id=" + gw_fis.SelectedValue + "", baglan.baglan());
                    cmdsil.ExecuteNonQuery();
                    satiscek();
                }
            }
            else if (e.CommandName == "goster")
            {
                if (gw_fis.SelectedIndex == -1)
                { Response.Write("<script lang='JavaScript'>alert ('Seçilen satırı silmek için lütfen satır seçiniz');</script>"); }
                else if (gw_fis.SelectedIndex >= 0)
                {
                    pnl_fis.Visible = true;
                    SqlCommand denedoldur = new SqlCommand("SELECT kategori_adi,adi,bfiyat, Direksatis_Ilaclari.adet,Direksatis_Ilaclari.ilac_id,bfiyat*Direksatis_Ilaclari.adet AS tutar FROM Kategori,Ilac,Direksatis_Ilaclari WHERE Ilac.kategori=Kategori.kategori_id AND Ilac.ilac_id=Direksatis_Ilaclari.ilac_id AND Direksatis_Ilaclari.fis_id=@1", baglan.baglan());
                    denedoldur.Parameters.AddWithValue("@1", gw_fis.SelectedValue);
                    SqlDataReader dene = denedoldur.ExecuteReader();
                    gw_fis_ilaclari.DataSource = dene;
                    gw_fis_ilaclari.DataBind();

                    SqlCommand cek = new SqlCommand("SELECT Satis.*,Musteri.* FROM Musteri,Satis WHERE Satis.musteri_id=Musteri.TC_NO AND Satis.fis_id="+gw_fis.SelectedValue+" ORDER BY fis_id ", baglan.baglan());
                    SqlDataReader dr = cek.ExecuteReader();
                    DataTable dt = new DataTable("tbl");
                    dt.Load(dr);
                    lbl_tarih.Text = dt.Rows[0]["tarih"].ToString();
                    lbl_musteri.Text = "MÜŞTERİ ADI SOYADI:"+dt.Rows[0]["adi"].ToString() + "  " + dt.Rows[0]["soyadi"].ToString() + "     ADRESİ:" + dt.Rows[0]["adres"].ToString();
                    lbl_fis_id.Text = gw_fis.SelectedValue.ToString();
                    lbl_tutar.Text = "TUTAR : " + dt.Rows[0]["tutar"].ToString();
                    lbl_tc.Text = dt.Rows[0]["TC_NO"].ToString();
                }
            }
        }

        protected void ibtn_fis_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_fis.AlternateText == "Göster")
            {
                pnl_fisler.Visible = true;
                ibtn_fis.AlternateText = "Gizle";
            }
            else if (ibtn_fis.AlternateText == "Gizle")
            {
                pnl_fisler.Visible = false;
                ibtn_fis.AlternateText = "Göster"; }
        }

        void recete_turu_cek()
        {
            SqlCommand cek = new SqlCommand("SELECT * From Recete_Turu", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            ddl_receteturu.DataSource = dr;
            ddl_receteturu.DataBind();
        }
        void hastane_cek()
        {
            SqlCommand cek = new SqlCommand("SELECT * From Hastane", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            ddl_hastane.DataSource = dr;
            ddl_hastane.DataBind();
        }
        void gw_recetedoldur()
        {
            SqlCommand doldur = new SqlCommand("SELECT R.*,H.hastane_adi,D.adi+'  '+D.soyadi AS dadsoyad,D.tahsis,M.adi+' '+M.soyadi AS adsoyad FROM Recete AS R, Hastane As H,Doktor AS D, Musteri AS M WHERE H.hastane_id=R.hastane_id AND H.hastane_id=D.hastane_id AND R.musteri_id=M.TC_NO AND R.doktor_id=D.doktor_id ORDER BY tarih", baglan.baglan());
            SqlDataReader dr = doldur.ExecuteReader();
            gw_receteler.DataSource = dr;
            gw_receteler.DataBind();
        }

        protected void ddl_hastane_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cek = new SqlCommand("SELECT * FROM Doktor WHERE Doktor.hastane_id="+ddl_hastane.SelectedValue+"", baglan.baglan());
            SqlDataReader dr = cek.ExecuteReader();
            gw_doktorlar.DataSource = dr;
            gw_doktorlar.DataBind();
        }

        protected void ibtn_kaydet_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_kaydet.ImageUrl == "~/image/save.png")
            {
                SqlCommand kaydet = new SqlCommand("INSERT INTO Recete(tur_id,hastane_id,doktor_id,musteri_id,tarih) VALUES(@1,@2,@3,@4,@5)", baglan.baglan());
                kaydet.Parameters.AddWithValue("@1",ddl_receteturu.SelectedValue);
                kaydet.Parameters.AddWithValue("@2",ddl_hastane.SelectedValue);
                kaydet.Parameters.AddWithValue("@3",gw_doktorlar.SelectedValue);
                kaydet.Parameters.AddWithValue("@4", gw_hastalar.SelectedValue);
                kaydet.Parameters.AddWithValue("@5",DateTime.Now);
                kaydet.ExecuteNonQuery();
                pnl_recete_ekle.Visible = false;
                gw_hastalar.SelectedIndex = -1;
                gw_doktorlar.SelectedIndex = -1;
                gw_recetedoldur();

            }
            
        }

        protected void ibtn_recete_goster_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_recete_goster.AlternateText == "Göster")
            {
                pnl_recete_ekle.Visible = true;
                ibtn_recete_goster.AlternateText = "Gizle";
            }
            else if (ibtn_recete_goster.AlternateText == "Gizle")
            {
                pnl_recete_ekle.Visible = false;
                ibtn_recete_goster.AlternateText = "Göster";
            }
        }

        protected void ibtn_recete_ilac_ekle_Click(object sender, ImageClickEventArgs e)
        {
            if (ibtn_recete_ilac_ekle.AlternateText == "Göster")
            {
                pnl_recete_ilac_ekle.Visible = true;
                ibtn_recete_ilac_ekle.AlternateText = "Gizle";
            }
            else if (ibtn_recete_ilac_ekle.AlternateText == "Gizle")
            {
                pnl_recete_ilac_ekle.Visible = false;
                ibtn_recete_ilac_ekle.AlternateText = "Göster";
            }
        }

        protected void ibtn__Click(object sender, ImageClickEventArgs e)
        {
            if (ddl_ara.SelectedIndex == 0)//isme göre ara
            {
                gw_.SelectedIndex = -1;
                SqlCommand ilaccek = new SqlCommand("SELECT *,kategori_adi,firma_adi FROM Ilac,Kategori,Firma WHERE adi LIKE '%" + TextBox1.Text + "%' AND Kategori.kategori_id=Ilac.kategori AND Firma.firma_id=Ilac.firma", baglan.baglan());
                SqlDataReader dr = ilaccek.ExecuteReader();
                gw_.DataSource = dr;
                gw_.DataBind();
            }
            else if (ddl_ara.SelectedIndex == 1)//kategoriye göre ara
            {
                gw_.SelectedIndex = -1;
                SqlCommand ilaccek = new SqlCommand("SELECT Ilac.*,kategori_adi,firma_adi FROM Ilac,Kategori,Firma WHERE kategori_adi LIKE '%" + TextBox1.Text + "%' AND Kategori.kategori_id=Ilac.kategori AND Firma.firma_id=Ilac.firma", baglan.baglan());
                SqlDataReader dr = ilaccek.ExecuteReader();
                gw_.DataSource = dr;
                gw_.DataBind();
            }
        }

        protected void gw_receteler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ilacekle")
            {
                if (gw_receteler.SelectedIndex >= 0)
                {
                    recete_ilac_ekle_panel.Visible = true;
                }
            }
            else if (e.CommandName == "sil")
            {
                if (gw_receteler.SelectedIndex >= 0)
                {
                    SqlCommand sil = new SqlCommand("DELETE FROM Recete WHERE recete_id=@1", baglan.baglan());
                    sil.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
                    sil.ExecuteNonQuery();
                    Response.Redirect("satis.aspx");
                    
                }
            }

        }

        void goster()
        {
            SqlCommand cek = new SqlCommand("SELECT RT.tur_adi,H.hastane_adi,D.adi+' '+D.soyadi AS dadsoyad,D.tahsis,R.*,M.adi+' '+M.soyadi AS madsoyad FROM Recete_Turu AS RT, Hastane AS H,Doktor AS D,Recete AS R,Musteri AS M WHERE R.doktor_id=D.doktor_id AND R.hastane_id=H.hastane_id AND R.musteri_id=M.TC_NO AND R.tur_id=RT.tur_id  AND R.recete_id=@1", baglan.baglan());
            cek.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
            SqlDataReader dr = cek.ExecuteReader();
            DataTable dt = new DataTable("doldur");
            dt.Load(dr);

            lbl_recete_tarih.Text = "Tarih : " + dt.Rows[0]["tarih"].ToString();
            lbl_recete_turu.Text = " Recete Tür:" + dt.Rows[0]["tur_adi"].ToString();
            lbl_hastane_adi.Text = "Hastane: " + dt.Rows[0]["hastane_adi"].ToString();
            lbl_doktor_adi.Text = "Doktor :" + dt.Rows[0]["dadsoyad"].ToString();
            lbl_doktor_brans.Text = "Branş:" + dt.Rows[0]["tahsis"].ToString();
            lbl_hasta_adi.Text = "Hasta :" + dt.Rows[0]["madsoyad"].ToString();
            lbl_r_tutar.Text = "Tutar:" + dt.Rows[0]["tutar"].ToString();

            SqlCommand goster = new SqlCommand("SELECT i.adi,i.bfiyat,i.ilac_id,k.kategori_adi,r.adet*bfiyat AS itutar,r.adet FROM Ilac AS i,Kategori AS k,Recete_Ilacları As r WHERE k.kategori_id=i.kategori AND r.ilac_id=i.ilac_id AND r.recete_id=@1", baglan.baglan());
            goster.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
            SqlDataReader dr2 = goster.ExecuteReader();
            gw_recete_ilaclari_goruntule.DataSource = dr2;
            gw_recete_ilaclari_goruntule.DataBind();
        }

        protected void ibtn_rilacekle_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand ilacekle = new SqlCommand("INSERT INTO Recete_Ilacları(recete_id,ilac_id,adet) VALUES(@1,@2,@3)", baglan.baglan());
            ilacekle.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
            ilacekle.Parameters.AddWithValue("@2", gw_.SelectedValue);
            ilacekle.Parameters.AddWithValue("@3", tb_r_adet.Text);
            ilacekle.ExecuteNonQuery();

            SqlCommand tutarbul = new SqlCommand("SELECT R.tutar+(i.bfiyat*ri.adet) AS recetetutar FROM Recete AS R,Ilac AS i,Recete_Ilacları AS ri WHERE ri.ilac_id=i.ilac_id AND R.recete_id=ri.recete_id AND ri.recete_id=@1 AND ri.ilac_id=@2", baglan.baglan());
            tutarbul.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
            tutarbul.Parameters.AddWithValue("@2", gw_.SelectedValue);
            SqlDataReader dr = tutarbul.ExecuteReader();
            DataTable dt = new DataTable("doldur");
            dt.Load(dr);

            double yenitutar=double.Parse(dt.Rows[0]["recetetutar"].ToString());

            SqlCommand tutarguncelle = new SqlCommand("UPDATE Recete SET tutar=@1 WHERE recete_id=@2 ", baglan.baglan());
            tutarguncelle.Parameters.AddWithValue("@1", yenitutar);
            tutarguncelle.Parameters.AddWithValue("@2", gw_receteler.SelectedValue);
            tutarguncelle.ExecuteNonQuery();
            goster();
        }

        protected void gw_recete_ilaclari_goruntule_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ilacsil")
            {
                SqlCommand tutarbul = new SqlCommand("SELECT R.tutar-(i.bfiyat*ri.adet) AS recetetutar FROM Recete AS R,Ilac AS i,Recete_Ilacları AS ri WHERE ri.ilac_id=i.ilac_id AND R.recete_id=ri.recete_id AND ri.recete_id=@1 AND ri.ilac_id=@2", baglan.baglan());
                tutarbul.Parameters.AddWithValue("@1", gw_receteler.SelectedValue);
                tutarbul.Parameters.AddWithValue("@2", gw_recete_ilaclari_goruntule.SelectedValue);
                SqlDataReader dr = tutarbul.ExecuteReader();
                DataTable dt = new DataTable("doldur");
                dt.Load(dr);

                double yenitutar = double.Parse(dt.Rows[0]["recetetutar"].ToString());

                SqlCommand tutarguncelle = new SqlCommand("UPDATE Recete SET tutar=@1 WHERE recete_id=@2 ", baglan.baglan());
                tutarguncelle.Parameters.AddWithValue("@1", yenitutar);
                tutarguncelle.Parameters.AddWithValue("@2", gw_receteler.SelectedValue);
                tutarguncelle.ExecuteNonQuery();

                SqlCommand sil = new SqlCommand("DELETE FROM Recete_Ilacları WHERE ilac_id=@1", baglan.baglan());
                sil.Parameters.AddWithValue("@1", gw_recete_ilaclari_goruntule.SelectedValue);
                sil.ExecuteNonQuery();
                goster();
            }
        }

        protected void gw_receteler_SelectedIndexChanged(object sender, EventArgs e)
        {
            goster();
        }
       
    }
}
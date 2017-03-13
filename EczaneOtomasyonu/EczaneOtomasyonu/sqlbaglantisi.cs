using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EczaneOtomasyonu
{
    public class sqlbaglantisi
    {
        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=eczane_veritabani;Integrated Security=true");
            baglanti.Open();
            //bağlantı hatalarının şişmesini engellemek için
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();
            return (baglanti);
        }
    }
}
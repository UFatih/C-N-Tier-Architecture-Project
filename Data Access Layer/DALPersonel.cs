using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer;
using System.Data.SqlClient;
using System.Data;


namespace Data_Access_Layer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand kmt1 = new SqlCommand("Select * from TBLBILGI",Baglanti.bgl);
            if (kmt1.Connection.State != System.Data.ConnectionState.Open)
            {
                kmt1.Connection.Open();
            }
            SqlDataReader dr = kmt1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel per = new EntityPersonel();
                per.Id = int.Parse(dr["ID"].ToString());
                per.Ad = dr["AD"].ToString();
                per.Soyad = dr["SOYAD"].ToString();
                per.Gorev = dr["GOREV"].ToString();
                per.Sehir = dr["SEHIR"].ToString();
                per.Maas = int.Parse(dr["MAAS"].ToString());
                per.Ad = dr["AD"].ToString();
                degerler.Add(per);
             
            }
            dr.Close();
            return degerler;

            
        }

        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand kmt2 = new SqlCommand("insert into TBLBILGI (AD, SOYAD, GOREV, SEHIR, MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)",Baglanti.bgl);
            if (kmt2.Connection.State != ConnectionState.Open)
            {
                kmt2.Connection.Open();
            }
            kmt2.Parameters.AddWithValue("@P1", p.Ad);
            kmt2.Parameters.AddWithValue("@P2", p.Soyad);
            kmt2.Parameters.AddWithValue("@P3", p.Gorev);
            kmt2.Parameters.AddWithValue("@P4", p.Sehir);
            kmt2.Parameters.AddWithValue("@P5", p.Maas);
            return kmt2.ExecuteNonQuery();
            
        }

        public static bool PersonelSil(int p)
        {
            SqlCommand kmt3 = new SqlCommand("delete from TBLBILGI where ID=@P1", Baglanti.bgl);
            if (kmt3.Connection.State != ConnectionState.Open)
            {
                kmt3.Connection.Open();
            }
            kmt3.Parameters.AddWithValue("@P1", p);
            return kmt3.ExecuteNonQuery() > 0 ;
        }

        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand kmt4 = new SqlCommand("update TBLBILGI set AD=@P1, SOYAD=@P2, MAAS=@P3, SEHIR=@P4, GOREV=@P5 where ID=@P6", Baglanti.bgl);
            if (kmt4.Connection.State != ConnectionState.Open)
            {
                kmt4.Connection.Open();
            }
            kmt4.Parameters.AddWithValue("@P1", ent.Ad);
            kmt4.Parameters.AddWithValue("@P2", ent.Soyad);
            kmt4.Parameters.AddWithValue("@P3", ent.Maas);
            kmt4.Parameters.AddWithValue("@P4", ent.Sehir);
            kmt4.Parameters.AddWithValue("@P5", ent.Gorev);
            kmt4.Parameters.AddWithValue("@P6", ent.Id);
            return kmt4.ExecuteNonQuery() > 0;
        }
    }
}

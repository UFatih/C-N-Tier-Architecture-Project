﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entity_Layer;
using Data_Access_Layer;


namespace Logic_Layer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }

        public static int LLPersonelEkle(EntityPersonel p)
        {
            if (p.Ad != " " && p.Soyad != " " && p.Maas > 3000 && p.Ad.Length > 2)
            {
                return DALPersonel.PersonelEkle(p);
            }

            else
                return -1;
        }
        public static bool LLPersonelSil(int per)
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
                return false;
                
        }

        public static bool LLPersonelGuncelle(EntityPersonel ent)
        {
            if (ent.Ad.Length > 3 && ent.Ad != " " && ent.Maas > 4000)
            {
                return DALPersonel.PersonelGuncelle(ent);
            }
            else
                return false;
        }
    }
}

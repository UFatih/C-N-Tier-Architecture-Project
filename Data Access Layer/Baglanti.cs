using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class Baglanti
    {
        public static SqlConnection bgl = new SqlConnection(@"Data Source=MSI-GL65-LEOPAR\SQLEXPRESS;Initial Catalog=Personeldb;Integrated Security=True");
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity_Layer;
using Data_Access_Layer;
using Logic_Layer;

namespace Nkatmanlımimariprojesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            List<EntityPersonel> Perlist = LogicPersonel.LLPersonelListesi();
            dataGridView1.DataSource = Perlist;
        }

        private void btncıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            EntityPersonel ent = new EntityPersonel();
            ent.Ad = txtad.Text;
            ent.Soyad = txtsoyad.Text;
            ent.Sehir = txtsehir.Text;
            ent.Maas = int.Parse(txtmaas.Text);
            ent.Gorev = txtgorev.Text;
            LogicPersonel.LLPersonelEkle(ent);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            EntityPersonel entt = new EntityPersonel();
            entt.Id = Convert.ToInt32(txtid.Text);
            LogicPersonel.LLPersonelSil(entt.Id);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            EntityPersonel enttt = new EntityPersonel();
            enttt.Id = Convert.ToInt32(txtid.Text);
            enttt.Ad = txtad.Text;
            enttt.Soyad = txtsoyad.Text;
            enttt.Sehir = txtsehir.Text;
            enttt.Gorev = txtgorev.Text;
            enttt.Maas = Convert.ToInt32 (txtmaas.Text);
            LogicPersonel.LLPersonelGuncelle(enttt);
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = " ";
            txtad.Text = " ";
            txtgorev.Text = " ";
            txtmaas.Text = " ";
            txtsehir.Text = " ";
            txtsoyad.Text = " ";
        }
    }
}

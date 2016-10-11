using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace sở_thú_sài_gòn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void lstdanhsanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mmuend_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void form1_load(object sender, EventArgs e)
        {
            timer1.Enabled=true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbltime.Text = string.Format("bay gio la {0}:{1}:{2} ngay {3} thang {4} nam {5}.",
                                        DateTime.Now.Hour,
                                        DateTime.Now.Minute,
                                        DateTime.Now.Second,
                                        DateTime.Now.Day,
                                        DateTime.Now.Month,
                                        DateTime.Now.Year);
        }

        private void mmutai_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("thumoi.txt");

            if (reader == null) return;
            string input = null;
            while ((input = reader.ReadLine()) !=null )
            {   
                lstThumoi.Items.Add(input);
            }
            reader.Close();
            using ( StreamReader rs= new StreamReader("danhsachthu.txt"))
            {
                input = null;
                while(( input= rs.ReadLine())!=null)
                {
                    lstdanhsanh.Items.Add(input);
                }
            }
        }

        private void save(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("danhsachthu.txt");
            if (writer == null) return;
            foreach (var Item in lstdanhsanh.Items)
                writer.WriteLine(Item.ToString());
            writer.Close();
        }
        private void Listbox_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            int index = lb.IndexFromPoint(e.X,e.Y);
            lb.DoDragDrop(lb.Items[index].ToString(),
                DragDropEffects.Copy);
        }
        private void Listbox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.Move;
        }
        private void lstdanhsachthu_DragDrop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(DataFormats.Text))
            {
                ListBox lb=(ListBox) sender;
                lb.Items.Add(e.Data.GetData(DataFormats.Text));
            }

        }
    }
}

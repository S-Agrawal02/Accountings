using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Project_Registry
{
    public partial class Form1 : Form
    {
        RegistryKey rk;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Controls.Clear();
            int c = 0, d = 0;
            rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Project", true);
            if (rk == null)
                rk = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Project");
            //rk.SetValue("First", "100");
            foreach (var v in rk.GetSubKeyNames())      //Inside Project
            {
                
                RegistryKey productKey = rk.OpenSubKey(v);
                foreach (var value in productKey.GetValueNames())
                {
                    //MessageBox.Show(value + " : " + productKey.GetValue(value));
                    table.Controls.Add(new Label() { Text = value });
                    if (v == "Credit")
                    {
                        table.Controls.Add(new Label() { Text = "Credit" });
                        c += Convert.ToInt32(productKey.GetValue(value));
                    }
                    else
                    {
                        table.Controls.Add(new Label() { Text = "Debit" });
                        d += Convert.ToInt32(productKey.GetValue(value));
                    }
                    string ans = Convert.ToString(productKey.GetValue(value));
                    table.Controls.Add(new Label() { Text = ans });
                }
            }
            cred.Text = Convert.ToString(c);
            deb.Text = Convert.ToString(d);
            table.Controls.Add(new Label() { Text = "TOTAL" });
            table.Controls.Add(new Label() { Text = "" });
            table.Controls.Add(new Label() { Text = Convert.ToString(c+d) });
            if (c > d)
                susp.Text = Convert.ToString(c - d);
            else
                susp.Text = Convert.ToString(d - c);

            rk.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }
    }
}

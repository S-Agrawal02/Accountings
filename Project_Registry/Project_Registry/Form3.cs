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
    public partial class Form3 : Form
    {
        int a;
        public static string credit1, debit1;
        TextBox[] tb;
        ComboBox[] cb;
        NumericUpDown[] amt;
        RegistryKey rk, rk1, rk2;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Label l1 = new Label();
            l1.Text = "PARTICULARS";
            l1.Font = new Font(l1.Font, FontStyle.Bold);
            Label l2 = new Label();
            l2.Text = "TYPE";
            l2.Font = new Font(l2.Font, FontStyle.Bold);
            Label l3 = new Label();
            l3.Text = "AMOUNT";
            l3.Font = new Font(l3.Font, FontStyle.Bold);

            this.Controls.Add(l1);
            this.Controls.Add(l2);
            this.Controls.Add(l3);

            l1.Location = new Point(55, 90);
            l2.Location = new Point(240, 90);
            l3.Location = new Point(400, 90);

            a = int.Parse(textBox1.Text);
            tb = new TextBox[a];
            cb = new ComboBox[a];
            amt = new NumericUpDown[a];


            for (int i = 0; i < a; i++)
            {
                tb[i] = new TextBox();
                cb[i] = new ComboBox();
                amt[i] = new NumericUpDown();
                amt[i].Maximum = 10000000;
            }

            int j = 30;
            for (int i = 0; i < a; i++)
            {
                this.Controls.Add(tb[i]);
                this.Controls.Add(cb[i]);
                this.Controls.Add(amt[i]);
                cb[i].Items.Add("CREDIT");
                cb[i].Items.Add("DEBIT");
                cb[i].SelectedIndex = cb[i].Items.IndexOf("CREDIT");
                cb[i].DropDownStyle = ComboBoxStyle.DropDownList;
                tb[i].Location = new Point(50, 90 + j);
                cb[i].Location = new Point(200, 90 + j);
                amt[i].Location = new Point(370, 90 + j);
                j += 30;
            }
            submit.Show();
            submit.Location = new Point(230, 105 + j);
        }

        private void submit_Click(object sender, EventArgs e)
        {
            rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Project", true);
            rk1 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Project\\Credit", true);
            rk2 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Project\\Debit", true);
            for (int i = 0; i < a; i++)
            {
                this.Controls.Add(tb[i]);
                this.Controls.Add(cb[i]);
                this.Controls.Add(amt[i]);
                if (cb[i].Text == "CREDIT")
                    rk1.SetValue(tb[i].Text,amt[i].Value);
                else
                    rk2.SetValue(tb[i].Text, amt[i].Value);
                rk.SetValue(tb[i].Text+"-"+cb[i].Text,amt[i].Value);
            }
            rk1.Close();
            rk2.Close();
            MessageBox.Show("Added Successfully");
        }
    }
}

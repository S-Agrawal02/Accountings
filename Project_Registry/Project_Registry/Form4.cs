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
    public partial class Form4 : Form
    {
        RegistryKey rk;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            table.Controls.Clear();
            int c = 0, d = 0;
            rk = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Project", true);
            
            RegistryKey productKey = rk;
              foreach (var value in rk.GetValueNames())
                {
                    //MessageBox.Show(value + " : " + productKey.GetValue(value));
                   
                    string s = value.ToString();
                    //MessageBox.Show(s);
                    
                    table.Controls.Add(new Label() { Text = value.Substring(0, s.IndexOf('-')) });
                    s = s.Substring(s.IndexOf('-')+1, 5);
                    string ans = Convert.ToString(productKey.GetValue(value));
                    if (s == "CREDI")
                    {
                        table.Controls.Add(new Label() { Text = Convert.ToString(productKey.GetValue(value)) });
                        table.Controls.Add(new Label() { Text = "--" });
                        c += Convert.ToInt32(productKey.GetValue(value));
                    }
                    else
                    {
                        table.Controls.Add(new Label() { Text = "--" });
                        table.Controls.Add(new Label() { Text = Convert.ToString(productKey.GetValue(value))});
                        d += Convert.ToInt32(productKey.GetValue(value));
                    }
                    
                    //table.Controls.Add(new Label() { Text = ans });
                }
            //cred.Text = Convert.ToString(c);
            //deb.Text = Convert.ToString(d);
            table.Controls.Add(new Label() { Text = "TOTAL" });
            table.Controls.Add(new Label() { Text = Convert.ToString(c) });
            table.Controls.Add(new Label() { Text = Convert.ToString(d) });
        }
    }
}

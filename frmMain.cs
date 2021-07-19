using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzhansHavapeimaii
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            clsKarbaran k = new clsKarbaran();

            k.password_sg = txtPassword.Text;
            k.username_sg = txtUsername.Text;

            DataTable dt = k.searchtype();

            if (dt.Rows.Count == 0)
                MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
            else if (dt.Rows[0]["typeKarbari"].ToString() == "paziresh")
            {
                FrmPaziresh f = new FrmPaziresh(txtUsername.Text);
                f.Show();
            }
            else if (dt.Rows[0]["typeKarbari"].ToString() == "modir")
            {
                frmModir f = new frmModir();
                f.Show();
            }

              

        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }
    }
}

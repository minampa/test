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
    public partial class FrmPaziresh : Form
    {
        string usernameSarasari;
        public FrmPaziresh()
        {
            InitializeComponent();
        }

        public FrmPaziresh(string usernameDaryafti)
        {
            InitializeComponent();
            usernameSarasari = usernameDaryafti;
        }

        private void FrmPaziresh_Load(object sender, EventArgs e)
        {
            clsEtelaatKarmandan et = new clsEtelaatKarmandan();

            et.username_sg = usernameSarasari;

            DataTable dt = et.searchbyusername();

            if (dt.Rows[0]["jensiyat"].ToString() == "مرد")
                this.Text = "آقای " + dt.Rows[0]["firstname"].ToString() + " " +
                    dt.Rows[0]["lastname"].ToString() + " خوش آمدید";
            else if (dt.Rows[0]["jensiyat"].ToString() == "زن")
                this.Text = "خانم " + dt.Rows[0]["firstname"].ToString() + " " +
                    dt.Rows[0]["lastname"].ToString() + " خوش آمدید";
        }


        private void BtnDarj_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();

            a.codeMelli_sg = tbxCodeMelli.Text;
            a.firstName_sg = tbxFirstName.Text;
            a.lastName_sg = tbxLastName.Text;

            if (rdbtnZan.Checked == true)
                a.jensiat_sg = "زن";
            else if (rdbtnMard.Checked == true)
                a.jensiat_sg = "مرد";

            if (rdbtnMojarad.Checked == true)
                a.taahol_sg = "مجرد";
            else if (rdbtnMoteahel.Checked == true)
                a.taahol_sg = "متاهل";

            a.tarikh_tavalod_sg = tbxYear.Text + "/" + tbxMonth.Text + "/" + tbxDay.Text;
            a.city_sg = txtCity.Text;
            a.fatherName_sg = txtFatherName.Text;
            a.phoneNumber_sg = txtPhoneNumber.Text;
            a.darj();
        }

        private void BtnSearch_tb2_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();
            a.codeMelli_sg = txtCodeMelli_tb2.Text;
            DataTable dt = a.search_by_codemelli();
            if (dt.Rows.Count == 0)
                MessageBox.Show("این کد ملی وجود ندارد");
            else
            {
                panel1.Enabled = true;
                txtFirstName_tb2.Text = dt.Rows[0]["FirstName"].ToString();
                txtLastName_tb2.Text = dt.Rows[0]["LastName"].ToString();

                if (dt.Rows[0]["Jensiat"].ToString() == "زن")
                    rdbtnZan_tb2.Checked = true;
                else if (dt.Rows[0]["Jensiat"].ToString() == "مرد")
                    rdbtnMard_tb2.Checked = true;

                if (dt.Rows[0]["Taahol"].ToString() == "مجرد")
                    rdbtnMojarad_tb2.Checked = true;
                else if (dt.Rows[0]["Taahol"].ToString() == "متاهل")
                    rdbtnMoteahel_tb2.Checked = true;

                string[] tt = dt.Rows[0]["tarikh_tavalod"].ToString().Split('/');
                txtYear_tb2.Text = tt[0];
                txtMonth_tb2.Text = tt[1];
                txtDay_tb2.Text = tt[2];

                txtFatherName_tb2.Text = dt.Rows[0]["fatherName"].ToString();
                txtCity_tb2.Text = dt.Rows[0]["city"].ToString();
                txtPhoneNumber_tb2.Text = dt.Rows[0]["phoneNumber"].ToString();
            }
        }



        private void BtnEdit_tb2_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();
            a.firstName_sg = txtFirstName_tb2.Text;
            a.lastName_sg = txtLastName_tb2.Text;

            if (rdbtnMard_tb2.Checked == true)
                a.jensiat_sg = "مرد";
            else if (rdbtnZan_tb2.Checked == true)
                a.jensiat_sg = "زن";

            if (rdbtnMojarad_tb2.Checked == true)
                a.taahol_sg = "مجرد";
            else if (rdbtnMoteahel_tb2.Checked == true)
                a.taahol_sg = "متاهل";
            a.tarikh_tavalod_sg = txtYear_tb2.Text + "/" + txtMonth_tb2.Text + "/" + txtDay_tb2.Text;
            a.fatherName_sg = txtFatherName_tb2.Text;
            a.city_sg = txtCity_tb2.Text;
            a.phoneNumber_sg = txtPhoneNumber_tb2.Text;
            a.codeMelli_sg = txtCodeMelli_tb2.Text;
            a.edit(); 

        }








        private void BtnDelete_tb2_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();
            a.codeMelli_sg = txtCodeMelli_tb2.Text;
            a.delet();
        }

        private void BtnDarjParvaz_Click(object sender, EventArgs e)
        {
            clsParvaz p = new clsParvaz();
            p.CodeParvaz_sg = txtCodeParvazDarjeParvaz.Text;
            p.Mabda_sg = txtMabdaDarjeParvaz.Text;
            p.Maghsad_sg = txtMaghsadDarjeParvaz.Text;
            p.Zarfiat_sg = txtZarfiyatDarjeParvaz.Text;

            p.Tarikh_sg = txtYearDarjParvaz.Text + "/" + txtMonthDarjParvaz.Text + "/" + txtDayDarjeParvaz.Text;

            p.Saat_sg = txtHourDarjParvaz.Text + ":" + txtMinuteDarjParvaz.Text;
            p.TypeOfAirPlane_sg = txtTypeDarjeParvaz.Text;
            p.ModelOfAirPlane_sg = txtModelDarjeParvaz.Text;
            p.DarjeParvaz();
        }

        private void BtnSearchByName_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();
            a.firstName_sg = txtName_3.Text;
            a.lastName_sg = txtLastName_3.Text;

            DataSet ds = a.SearchByName();

            dataGridView1.AutoGenerateColumns = true;
            // dataGridView1.DataSource = ds.Tables["SearchFardByName"];
            
            dataGridView1.DataSource = ds.Tables["tbl_afrad_search"];
        }

        private void BtnSearchParvaz_Click(object sender, EventArgs e)
        {
            clsParvaz a = new clsParvaz();
            a.CodeParvaz_sg = txtCodeParvazSearch.Text;
            DataTable dt = a.SearchByCodeParvaz();
            if (dt.Rows.Count == 0)
                MessageBox.Show("این کد پرواز وجود ندارد");
            else
            {
                panel2.Enabled = true;
                txtMabdaSearch.Text = dt.Rows[0]["Mabda"].ToString();
                txtMaghsadSearch.Text = dt.Rows[0]["Maghsad"].ToString();
                txtZarfiatSearch.Text = dt.Rows[0]["Zarfiyat"].ToString();
                string[] t = dt.Rows[0]["Tarikh"].ToString().Split('/');
                txtYearSerchParvaz.Text = t[0];
                txtMonthSearchParvaz.Text = t[1];
                txtDaySearchParvaz.Text = t[2];

                string[] s = dt.Rows[0]["Saat"].ToString().Split(':');
                txtMinSearchParvaz.Text = s[0];
                txtHourSearchParvaz.Text = s[1];

                txtTypeOfAirPlaneSearch.Text = dt.Rows[0]["TypeOfAirPlane"].ToString();
                txtModelOfAirPlainSearch.Text = dt.Rows[0]["ModelOfAirPlane"].ToString();
            }

        }


        private void BtnEditParvaz_Click(object sender, EventArgs e)
        {
            clsParvaz a = new clsParvaz();
            a.CodeParvaz_sg = txtCodeParvazSearch.Text;
            a.Mabda_sg = txtMabdaSearch.Text;
            a.Maghsad_sg = txtMaghsadSearch.Text;
            a.Zarfiat_sg = txtZarfiatSearch.Text;
            a.Tarikh_sg = txtYearSerchParvaz.Text + '/' + txtMonthSearchParvaz.Text + '/' + txtDaySearchParvaz.Text;
            a.Saat_sg = txtHourSearchParvaz.Text + ':' + txtMinSearchParvaz.Text;
            a.TypeOfAirPlane_sg = txtTypeOfAirPlaneSearch.Text;
            a.ModelOfAirPlane_sg = txtModelOfAirPlainSearch.Text;
            a.ParvazEdit();

        }


        private void BtnDeleteParvaz_Click(object sender, EventArgs e)
        {
            clsParvaz a = new clsParvaz();
            a.CodeParvaz_sg = txtCodeParvazSearch.Text;
            a.ParvazDelete();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtTavalodSearchName.Text = dataGridView1.Rows[i].Cells["tarikh_tavalod"].Value.ToString();

            if (dataGridView1.Rows[i].Cells["jensiyat"].Value.ToString() == "زن")
                rdbtnZan_3.Checked = true;
            else if (dataGridView1.Rows[i].Cells["jensiyat"].Value.ToString() == "مرد")
                rdbtnMard_3.Checked = true;

        }

        private void BtnEditName_Click(object sender, EventArgs e)
        {
            cls_afrad a = new cls_afrad();

            int i = dataGridView1.CurrentRow.Index;

            a.codeMelli_sg = dataGridView1.Rows[i].Cells["CodeMeli"].Value.ToString();
            a.firstName_sg = dataGridView1.Rows[i].Cells["firstName"].Value.ToString();
            a.lastName_sg = dataGridView1.Rows[i].Cells["lastName"].Value.ToString();
            a.jensiat_sg = dataGridView1.Rows[i].Cells["Jensiyat"].Value.ToString();
            a.taahol_sg = dataGridView1.Rows[i].Cells["taahol"].Value.ToString();
            a.tarikh_tavalod_sg = dataGridView1.Rows[i].Cells["tarikh_tavalod"].Value.ToString();
            a.fatherName_sg = dataGridView1.Rows[i].Cells["fatherName"].Value.ToString();
            a.city_sg = dataGridView1.Rows[i].Cells["city"].Value.ToString();
            a.phoneNumber_sg = dataGridView1.Rows[i].Cells["phoneNumber"].Value.ToString();

            a.edit();

        }

        private void BtnKharid_Click(object sender, EventArgs e)
        {
            clsParvaz p = new clsParvaz();
            p.CodeParvaz_sg = txtKharidCodeParvaz.Text;
            DataTable dt = p.SearchByCodeParvaz();
            int z = Convert.ToInt32(dt.Rows[0]["Zarfiyat"].ToString());
            int t = Convert.ToInt32(txtKharidTedad.Text);
            if (z < t)
                MessageBox.Show("ظرفیت کافی نمی باشد");
            else
            {
                clsBlit b = new clsBlit();
                b.CodeParvaz_sg = txtKharidCodeParvaz.Text;
                b.CodeMelli_sg = txtKharidCodeMelli.Text;
                b.tedad_sg = txtKharidTedad.Text;
                b.darjBlit();

                p.Zarfiat_sg = Convert.ToString(z - t);
                p.CodeParvaz_sg = txtKharidCodeParvaz.Text;
                p.editZarfiyat();

            }
        }

       
    }
}

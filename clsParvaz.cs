
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AzhansHavapeimaii
{
    class clsParvaz
    {
        string CodeParvaz = "", Mabda = "", Maghsad = "", Zarfiyat = "", Tarikh = "", Saat = "", TypeOfAirPlane = "", ModelOfAirPlane = "";
        public string CodeParvaz_sg
        {
            set { CodeParvaz = value; }
            get { return CodeParvaz; }
        }
        public string Maghsad_sg
        {
            set { Maghsad = value; }
            get { return Maghsad; }
        }
        public string Mabda_sg
        {
            set { Mabda = value; }
            get { return Mabda; }
        }
        public string Zarfiat_sg
        {
            set { Zarfiyat = value; }
            get { return Zarfiyat; }
        }
        public string Tarikh_sg
        {
            set { Tarikh = value; }
            get { return Tarikh; }
        }
        public string Saat_sg
        {
            set { Saat = value; }
            get { return Saat; }
        }
        public string TypeOfAirPlane_sg
        {
            set { TypeOfAirPlane = value; }
            get { return TypeOfAirPlane; }
        }
        public string ModelOfAirPlane_sg
        {
            set { ModelOfAirPlane = value; }
            get { return ModelOfAirPlane; }
        }
        
        public void DarjeParvaz()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DarjParvaz", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);
            cmd.Parameters.AddWithValue("@Mabda", Mabda);
            cmd.Parameters.AddWithValue("@Maghsad", Maghsad);
            cmd.Parameters.AddWithValue("@Zarfiyat", Zarfiyat);
            cmd.Parameters.AddWithValue("@Tarikh", Tarikh);
            cmd.Parameters.AddWithValue("@Saat", Saat);
            cmd.Parameters.AddWithValue("TypeOfAirPlane", TypeOfAirPlane);
            cmd.Parameters.AddWithValue("ModelOfAirPlane", ModelOfAirPlane);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت ثبت شد");
            }
            catch(SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public DataTable SearchByCodeParvaz()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlDataAdapter da = new SqlDataAdapter("SearchByCodeParvaz", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

   

        public void ParvazEdit()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("ParvazEdit" , con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);
            cmd.Parameters.AddWithValue("@Mabda", Mabda);
            cmd.Parameters.AddWithValue("@Maghsad", Maghsad);
            cmd.Parameters.AddWithValue("@Zarfiyat", Zarfiyat);
            cmd.Parameters.AddWithValue("@Tarikh", Tarikh);
            cmd.Parameters.AddWithValue("@Saat", Saat);
            cmd.Parameters.AddWithValue("@TypeOfAirPlane", TypeOfAirPlane);
            cmd.Parameters.AddWithValue("@ModelOfAirPlane", ModelOfAirPlane);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        public void ParvazDelete()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("ParvazDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت حذف شد");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void editZarfiyat()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("editZarfiyat", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Zarfiyat", Zarfiyat);
            cmd.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("ظرفیت آپدیت شد");
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }

        
    }
}

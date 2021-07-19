using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AzhansHavapeimaii
{
    class cls_afrad
    {
        string codeMelli = "", firstName = "", lastName = "", jensiat = "", taahol = "", tarikh_tavalod = "" , fatherName = "" ,  city = "" , phoneNumber = "";
        public string codeMelli_sg
        {
            set { codeMelli = value; }
            get { return codeMelli; }
        }
        public string firstName_sg
        {
            set { firstName = value; }
            get { return firstName;  }
        }
        public string lastName_sg
        {
            set { lastName = value; }
            get { return lastName; }
        }
        public string jensiat_sg
        {
            set { jensiat = value; }
            get { return jensiat; }
        }
        public string taahol_sg
        {
            set { taahol = value; }
            get { return taahol; }
        }
        public string tarikh_tavalod_sg
        {
            set { tarikh_tavalod = value; }
            get { return tarikh_tavalod; }
        }  
        public string fatherName_sg
        {
            set { fatherName = value; }
            get { return fatherName; }
        }
        public string city_sg
        {
            set { city = value; }
            get { return city; }
        }
        public string phoneNumber_sg
        {
            set { phoneNumber = value; }
            get { return phoneNumber; }
        }

        public void darj()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);

            SqlCommand cmd = new SqlCommand("DarjeFard", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@codeMelli", codeMelli);
            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@jensiat", jensiat);
            cmd.Parameters.AddWithValue("@taahol", taahol);
            cmd.Parameters.AddWithValue("@tarikh_tavalod", tarikh_tavalod);
            cmd.Parameters.AddWithValue("@fatherName", fatherName);
            cmd.Parameters.AddWithValue("@city" , city);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);


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

        public DataTable search_by_codemelli()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlDataAdapter da = new SqlDataAdapter("search_fard_by_codemelli", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@CodeMelli", codeMelli);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataSet SearchByName()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlDataAdapter da = new SqlDataAdapter("SearchFardByName", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@FirstName", firstName);
            da.SelectCommand.Parameters.AddWithValue("@LastName", lastName);

            DataSet ds = new DataSet();
            da.Fill(ds, "tbl_afrad_search");
           // da.Fill(ds, "SearchFardByName");


            return ds;

        }


        public void edit()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("edit" , con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@firstName" , firstName);
            cmd.Parameters.AddWithValue("@LastName" , lastName);
            cmd.Parameters.AddWithValue("@Jensiat", jensiat);
            cmd.Parameters.AddWithValue("@Taahol" , taahol);
            cmd.Parameters.AddWithValue("@tarikh_tavalod", tarikh_tavalod);
            cmd.Parameters.AddWithValue("@fatherName", fatherName);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@CodeMelli", codeMelli);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقيت ويرايش شد");

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }




        public void delet()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("delet", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodeMelli", codeMelli);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقيت حذف شد");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

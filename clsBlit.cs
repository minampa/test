using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace AzhansHavapeimaii
{
    class clsBlit
    {
        string CodeMelli = "", CodeParvaz = "", tedad = "";
        public string CodeMelli_sg
        {
            set { CodeMelli = value; }
            get { return CodeMelli; }
        }
        public string CodeParvaz_sg
        {
            set { CodeParvaz = value; }
            get { return CodeParvaz; }
        }
        public string tedad_sg
        {
            set { tedad = value; }
            get { return tedad; }
        }
        public void darjBlit()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DarjBlit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CodeParvaz", CodeParvaz);
            cmd.Parameters.AddWithValue("@CodeMelli", CodeMelli);
            cmd.Parameters.AddWithValue("@tedad", tedad);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("اطلاعات با موفقیت ثبت شد");
            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        
    }
}

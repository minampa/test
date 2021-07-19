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
    class clsKarbaran
    {
        string username = "", password = "", typeKarbari = "";
        public string username_sg
        {
            set { username = value; }
            get { return username; }
        }
        public string password_sg
        {
            set { password = value; }
            get { return password; }
        }
        public string typeKarbari_sg
        {
            set { typeKarbari = value; }
            get { return typeKarbari; }
        }

        public DataTable searchtype()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlDataAdapter da = new SqlDataAdapter("searchbyuserpass", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@username", username);
            da.SelectCommand.Parameters.AddWithValue("@password", password);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}

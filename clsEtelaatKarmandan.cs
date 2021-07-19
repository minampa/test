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
    class clsEtelaatKarmandan
    {
        string username = "", firstname = "", lastname = "", jensiyat = "";
        
        public string username_sg
        {
            set { username = value; }
            get { return username; }
        }
        public string firstname_sg
        {
            set { firstname = value; }
            get { return firstname; }
        }
        public string lastname_sg
        {
            set { lastname = value; }
            get { return lastname; }
        }
        public string jensiyat_sg
        {
            set { jensiyat = value; }
            get { return jensiyat; }
        }

        public DataTable searchbyusername()
        {
            SqlConnection con = new SqlConnection(Constatns.CONNECTION_STRING);
            SqlDataAdapter da = new SqlDataAdapter("serchbyusername",con);

            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@username" , username);

            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

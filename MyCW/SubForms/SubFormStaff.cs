using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCW
{
    public partial class SubFormStaff : Form
    {
        public SubFormStaff()
        {
            InitializeComponent();
        }

        private DataTable dt = new DataTable();
        // закомментированная часть работает только с моей локальной бд
        // => буду использовать "затычку", создав datatable вручную
        private void SubFormStaff_Load(object sender, EventArgs e)
        {
            /*string sqlExpression = "select login_of,password_of from users_log";
            DataBase dataBase = new DataBase();

            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, dataBase.getConnection());

            adapter.Fill(dt);*/
            dt=GetTableManually();

            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row.ItemArray[0]);
            }
        }
        private DataTable GetTableManually()
        {

            DataTable table = new DataTable();
            //table.Columns.Add("id", typeof(int));
            table.Columns.Add("login", typeof(string));
            table.Columns.Add("password", typeof(string));


            table.Rows.Add("admin","admin");
            table.Rows.Add("test","test");

            return table;
        }
    }
}

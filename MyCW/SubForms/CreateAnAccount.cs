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
    public partial class CreateAnAccount : Form
    {
        public CreateAnAccount()
        {
            InitializeComponent();
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(192, 64, 0); 
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(214, 124, 69);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            DataBase database = new DataBase();

            string querystring = $"INSERT INTO users_log (login_of,password_of) VALUES ('{login}','{password}')";

            database.openConnection();

            //класс для установки команды
            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            //исполняю команду
            command.ExecuteNonQuery();

            //закрываю подключение
            database.closeConnection();

            MessageBox.Show("Account created!", "Success");
        }
    }
}

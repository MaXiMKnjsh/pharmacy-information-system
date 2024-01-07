using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCW.Resources
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(214, 124, 69);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(192, 64, 0); 
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            DataBase database = new DataBase();

            string querystring = $"select login_of,password_of from users_log where login_of = '{login}' and password_of= '{password}'";

            //класс для задания команды
            SqlCommand command = new SqlCommand(querystring,database.getConnection());

            //класс, который представляет из себя одну таблицу данных
            DataTable table = new DataTable();

            //класс который заполняет таблицу данными из бд
            SqlDataAdapter adapter = new SqlDataAdapter();

            //задаём команду адаптеру
            adapter.SelectCommand = command;

            //заполняю таблицу данными,котоыре вернёт адаптер с моим условием
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("You have successfully logged in!", "Success");
            }            
            else MessageBox.Show("You entered an incorrect username or password!","Unsuccess");
        }

    }
}

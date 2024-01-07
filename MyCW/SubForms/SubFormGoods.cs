using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCW
{
    public partial class SubFormGoods : Form
    {
        public SubFormGoods()
        {
            InitializeComponent();
            panel12.Height = 0;
            radioButton4.Checked = radioButton5.Checked = true;
        }

        private bool isSlidePanel = true;

        private DataTable dt = new DataTable();

        // закомментированная часть работает только с моей локальной бд
        // => буду использовать "затычку", создав datatable вручную
        private void SubFormGoods_Load(object sender, EventArgs e)
        {
            
            /*string sqlExpression = "SELECT * FROM goods";
            DataBase dataBase = new DataBase();

            dataBase.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, dataBase.getConnection());

            dt.Rows.Add(dt.NewRow());

            adapter.Fill(dt);*/

            dt = GetTableManually();

            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row.ItemArray[1]);
            }

        }

        private DataTable GetTableManually()
        {
            
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name_of", typeof(string));
            table.Columns.Add("release_form", typeof(string));
            table.Columns.Add("roducer", typeof(string));
            table.Columns.Add("price", typeof(int));
            table.Columns.Add("description_of", typeof(string));

       
            table.Rows.Add(1, "Гастерол", "Таблетки", "Беларусь",4,"Гастерол описание...");
            table.Rows.Add(2, "Анальгин", "Капсулы", "Беларусь",12,"Анальгин описание...");
            table.Rows.Add(3, "Ибупрофен", "Жидкость", "Беларусь",111,"Ибупрофен описание...");
            table.Rows.Add(4, "Витамин Е", "Капсулы", "Россия",2,"Витмаин Е описание...");
            table.Rows.Add(5, "Йод", "Раствор", "Венгрия",1,"Йод описание...");
            table.Rows.Add(52, "Авинар", "Неизвестно", "Неизвестно", 1000, "Неизвестное описание...");

            return table;
        }
        private Dictionary<string, int> idname = new Dictionary<string, int>();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            idname.Clear();
            if (textBox1.Text != String.Empty)
            {
                DataRow[] rows = dt.Select();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (rows[i][1].ToString().IndexOf(textBox1.Text) != -1)
                    {
                        idname.Add(rows[i][1].ToString(), i);
                    }
                }
                if (isBelarus) checkFilters(idname, isBelarus: true);
                if (isMax) checkFilters(idname, isMax: true);
                if (isMin) checkFilters(idname, isMin: true);
                listBox1.Items.Clear();
                foreach (var nameof in idname)
                {
                    listBox1.Items.Add(nameof.Key);
                }
            }
            else
            {
                DataRow[] rows = dt.Select();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    idname.Add(rows[i][1].ToString(), i);
                }
                if (isBelarus) checkFilters(idname, isBelarus: true);
                if (isMax) checkFilters(idname, isMax: true);
                if (isMin) checkFilters(idname, isMin: true);
                listBox1.Items.Clear();
                foreach (var nameof in idname)
                {
                    listBox1.Items.Add(nameof.Key);
                }
            }
        }

        private void checkFilters(Dictionary<string, int> idname, bool isBelarus = false, bool isMax = false, bool isMin = false)
        {
            List<string> lst = new List<string>();
            DataRow[] rows = dt.Select();
            foreach (var item in idname)
            {
                if (isBelarus)
                {
                    if (rows[item.Value][3].ToString().IndexOf("Беларусь") != -1) { }
                    else { lst.Add(rows[item.Value][1].ToString()); }
                }
                if (isMax && textBox5.Text != String.Empty)
                {
                    if (int.Parse(rows[item.Value][4].ToString()) > int.Parse(textBox5.Text))
                        lst.Add(rows[item.Value][1].ToString());
                }
                if (isMin && textBox4.Text != String.Empty)
                {
                    if (int.Parse(rows[item.Value][4].ToString()) < int.Parse(textBox4.Text))
                        lst.Add(rows[item.Value][1].ToString());
                }
            }
            foreach (var item in lst)
            {
                idname.Remove(item);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (toMin) label2_Click(listBox1, null);
            if (listBox1.SelectedIndex != -1)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = "Форма выпуска: " + dt.Rows[idname[textBox1.Text]][2].ToString() + Environment.NewLine + "Производитель: " + dt.Rows[idname[textBox1.Text]][3].ToString() + Environment.NewLine + "Цена: " + dt.Rows[idname[textBox1.Text]][4].ToString() + "$" + Environment.NewLine + "Описание: " + dt.Rows[idname[textBox1.Text]][5].ToString();
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.BackColor = Color.SteelBlue;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.FromArgb(64, 0, 44);
        }

        private bool toMax, toMin = false;

        private void label2_Click(object sender, EventArgs e)
        {
            isSlidePanel = true;
            slidingPanel.Start();
        }

        private bool isBelarus;
        private bool isMax;
        private bool isMin;

        private void radioButton4_CheckedChanged(object sender, EventArgs e) // no limit
        {
            isMax = isMin = false;
            textBox1_TextChanged(radioButton2, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) // min cost
        {
            isMin = true;
            isMax = false;
            textBox1_TextChanged(radioButton2, null);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) // max cost
        {
            isMax = true;
            isMin = false;
            textBox1_TextChanged(radioButton3, null);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e) // belarusian goods
        {
            if (radioButton6.Checked == true) isBelarus = true;
            else isBelarus = false;
            textBox1_TextChanged(radioButton5, null);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (isMax)
            radioButton3_CheckedChanged(null, null);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (isMin)
            radioButton2_CheckedChanged(null, null);
        }

        private void slidingPanel_Tick(object sender, EventArgs e)
        {
            if (isSlidePanel)
            {
                if (panel12.Size.Height == panel12.MinimumSize.Height || toMax)
                {
                    toMax = true;
                    panel12.Height += 10;
                    if (panel12.Height == 270)
                    {
                        toMax = false;
                        isSlidePanel = false;
                        slidingPanel.Stop();
                    }
                }
                if (panel12.Size.Height == 270 || toMin)
                {
                    toMin = true;
                    panel12.Height -= 10;
                    if (panel12.Height == panel12.MinimumSize.Height)
                    {
                        toMin = false;
                        isSlidePanel = false;
                        slidingPanel.Stop();
                    }
                }
            }
        }
    }
}
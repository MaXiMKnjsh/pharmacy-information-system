using Microsoft.Win32.SafeHandles;
using MyCW.Properties;
using MyCW.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCW
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            panel8_Click(panel8,null);
            panel12.Height = 0;
        }

        private Point p10p1p8 = new Point(27, 16);
        private Point p4 = new Point(23, 16);
        private Point p2 = new Point(28, 18);        

        private bool isClickHome,isClickOrders,isClickStaff,isClickSettings,isClickGoods = false;

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximazeminimaze_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            if (!isClickOrders)
            panel2.BackColor = Color.SteelBlue;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            if (!isClickOrders)
            panel2.BackColor = Color.Transparent;
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            if (!isClickGoods)
                panel3.BackColor = Color.SteelBlue;
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            if (!isClickGoods)
                panel3.BackColor = Color.Transparent;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            if (!isClickStaff)
                panel4.BackColor = Color.Transparent;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            if (!isClickSettings)
                panel5.BackColor = Color.Transparent;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            if (!isClickStaff)
            panel4.BackColor = Color.SteelBlue;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            if (!isClickSettings)
                panel5.BackColor = Color.SteelBlue;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible=true;
            pictureBox11.Visible = pictureBox3.Visible= pictureBox7.Visible= pictureBox9.Visible = false;
            pictureBox5.BackgroundImage = pictureBox1.BackgroundImage;  
            label5.Text = "Orders";
            label1.ForeColor = label3.ForeColor = label2.ForeColor = label4.ForeColor = label6.ForeColor = Color.Transparent;
            pictureBox1.Location = new Point(137, 16);
            pictureBox4.Location = p4;
            pictureBox2.Location = p2;
            pictureBox10.Location =pictureBox8.Location= p10p1p8;
            isClickOrders = true;
            panel2.BackColor = Color.DarkSlateBlue;
            isClickHome = isClickStaff = isClickSettings = isClickGoods = false;
            panel8.BackColor=panel4.BackColor=panel3.BackColor=panel5.BackColor = Color.Transparent;
            pictureBox12.Visible=time.Visible=date.Visible=false;
            closeChildForm();
            openChildForm(new SubFormOrders());
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox6.Visible = false;
            pictureBox11.Visible = false;
            pictureBox7.Visible = false;
            pictureBox9.Visible = false;
            pictureBox5.BackgroundImage = pictureBox2.BackgroundImage;
            label5.Text = "Goods";
            label2.ForeColor = Color.Orange;
            label6.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            pictureBox2.Location = new Point(137, 16);
            pictureBox4.Location = p4;
            panel3.BackColor = Color.DarkSlateBlue;
            isClickGoods = true;
            isClickHome = isClickHome = isClickOrders = isClickSettings = false;
            pictureBox10.Location = pictureBox1.Location = pictureBox8.Location = p10p1p8;
            panel2.BackColor = panel8.BackColor = panel4.BackColor = panel5.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new SubFormGoods());
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = true;
            pictureBox3.Visible = false;
            pictureBox11.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            pictureBox5.BackgroundImage = pictureBox4.BackgroundImage;
            label5.Text = "Staff";
            label3.ForeColor = Color.Fuchsia;
            label6.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            pictureBox4.Location = new Point(137,16);
            pictureBox2.Location = p2;
            panel4.BackColor = Color.DarkSlateBlue;
            pictureBox10.Location = pictureBox1.Location = pictureBox8.Location = p10p1p8;
            isClickStaff = true;
            isClickOrders = isClickHome = isClickSettings = isClickGoods = false;
            panel2.BackColor = panel8.BackColor =  panel3.BackColor = panel5.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new SubFormStaff());
        }

        private Dictionary<int, string> months = new Dictionary<int, string>()
            {
            {1,"January"},{2,"February" },{3,"March" },
            {4,"April" },{5,"May" },{6,"June" },
            {7,"July" },{8,"August" },{9,"September" },
            {10,"October" },{11,"November" },{12,"December" }
            };

        private void timeUpdater_Tick(object sender, EventArgs e)
        {
            string[] buf = DateTime.Now.ToString().Split(' ');
            time.Text = buf[1];
            string[] bufdate = buf[0].Split('.');
            //date.Text =months[int.Parse(bufdate[1])]+" " + bufdate[0] +", " + bufdate[2];
            
        }

        private bool isSlidePanel,toMax, toMin = false;

        private void panel13_MouseEnter(object sender, EventArgs e)
        {
                panel13.BackColor = Color.SteelBlue;
                panel14.BackColor = panel15.BackColor = Color.Transparent;
        }

        private void panel14_MouseEnter(object sender, EventArgs e)
        {

            panel14.BackColor = Color.SteelBlue;
        }

        private void panel15_MouseEnter(object sender, EventArgs e)
        {

            panel15.BackColor = Color.SteelBlue;
        }

        private void panel14_MouseLeave(object sender, EventArgs e)
        {
            panel14.BackColor = Color.Transparent;
        }

        private void panel15_MouseLeave(object sender, EventArgs e)
        {
            panel15.BackColor = Color.Transparent;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (label11.Text== "▲")
                label11.Text = "▼";
            else if (label11.Text == "▼")
                label11.Text = "▲";
            isSlidePanel = true;
            slidingPanel.Start();
        }


        private void slidingPanel_Tick(object sender, EventArgs e)
        {
            if (isSlidePanel)
            {
                if (panel12.Size.Height==panel12.MinimumSize.Height || toMax)
                {
                    toMax = true;
                    panel12.Height += 10;
                    if (panel12.Height == 210)
                    {
                        toMax = false;
                        isSlidePanel = false;
                        slidingPanel.Stop();
                    }
                }
                if (panel12.Size.Height == 210 || toMin)
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

        private void panel5_Click(object sender, EventArgs e)
        {
            pictureBox9.Visible = true;
            pictureBox6.Visible = false;
            pictureBox11.Visible = false;
            pictureBox3.Visible = false;
            pictureBox7.Visible = false;
            pictureBox5.BackgroundImage = pictureBox8.BackgroundImage;
            label5.Text = "Settings";
            label4.ForeColor = Color.RoyalBlue;
            label6.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            pictureBox8.Location = new Point(137, 16);
            pictureBox4.Location = p4;
            panel5.BackColor = Color.DarkSlateBlue;
            pictureBox2.Location = p2;
            pictureBox10.Location = pictureBox1.Location = p10p1p8;
            isClickSettings = true;
            isClickOrders = isClickStaff = isClickHome = isClickGoods = false;
            panel2.BackColor = panel8.BackColor = panel4.BackColor = panel3.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new SubFormSettings());
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Transparent;
        }

        private void panel13_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible=pictureBox9.Visible = pictureBox3.Visible= pictureBox11.Visible = pictureBox6.Visible= false;
            pictureBox5.BackgroundImage = pictureBox8.BackgroundImage;
            label5.Text = "Sign In";
            label1.ForeColor= label2.ForeColor= label3.ForeColor = label6.ForeColor = label4.ForeColor=Color.White;
            pictureBox4.Location = p4;
            panel5.BackColor = Color.Transparent;
            pictureBox2.Location = p2;
            pictureBox10.Location = pictureBox1.Location= pictureBox8.Location = p10p1p8;
            isClickOrders = isClickStaff = isClickHome = isClickGoods =isClickSettings=false;
            panel2.BackColor = panel8.BackColor = panel4.BackColor = panel3.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new SignIn());
        }

        private void label17_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = pictureBox9.Visible = pictureBox3.Visible = pictureBox11.Visible = pictureBox6.Visible = false;
            pictureBox5.BackgroundImage = pictureBox8.BackgroundImage;
            label5.Text = "Sign Up";
            label1.ForeColor = label2.ForeColor = label3.ForeColor = label6.ForeColor = label4.ForeColor = Color.White;
            pictureBox4.Location = p4;
            panel5.BackColor = Color.Transparent;
            pictureBox2.Location = p2;
            pictureBox10.Location = pictureBox1.Location = pictureBox8.Location = p10p1p8;
            isClickOrders = isClickStaff = isClickHome = isClickGoods = isClickSettings = false;
            panel2.BackColor = panel8.BackColor = panel4.BackColor = panel3.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new CreateAnAccount());
        }

        private void panel15_Click(object sender, EventArgs e)
        {
            pictureBox7.Visible = pictureBox9.Visible = pictureBox3.Visible = pictureBox11.Visible = pictureBox6.Visible = false;
            pictureBox5.BackgroundImage = pictureBox8.BackgroundImage;
            label5.Text = "Help Me";
            label1.ForeColor = label2.ForeColor = label3.ForeColor = label6.ForeColor = label4.ForeColor = Color.White;
            pictureBox4.Location = p4;
            panel5.BackColor = Color.Transparent;
            pictureBox2.Location = p2;
            pictureBox10.Location = pictureBox1.Location = pictureBox8.Location = p10p1p8;
            isClickOrders = isClickStaff = isClickHome = isClickGoods = isClickSettings = false;
            panel2.BackColor = panel8.BackColor = panel4.BackColor = panel3.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = false;
            closeChildForm();
            openChildForm(new HelpMe());
        }

        private Point lastPoint;
        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X,e.Y);
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = true; 
            pictureBox7.Visible = false;
            pictureBox3.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            pictureBox5.BackgroundImage = pictureBox10.BackgroundImage;
            label5.Text = "Home";
            label6.ForeColor = Color.Red;
            label4.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            pictureBox10.Location = new Point(137,16);
            pictureBox4.Location = p4;
            pictureBox2.Location = p2;
            pictureBox1.Location = pictureBox8.Location = p10p1p8;
            panel8.BackColor = Color.DarkSlateBlue;
            isClickHome = true;
            isClickOrders=isClickStaff=isClickSettings=isClickGoods = false;
            panel2.BackColor = panel4.BackColor = panel3.BackColor = panel5.BackColor = Color.Transparent;
            pictureBox12.Visible = time.Visible = date.Visible = true;
            closeChildForm();
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            if (!isClickHome)
                panel8.BackColor = Color.SteelBlue;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            if (!isClickHome)
            panel8.BackColor = Color.Transparent;             
        }

        private Form activeForm = null;

        private void openChildForm(Form childform)
        {
            if (activeForm!=null)
            {
                activeForm.Close();
            }
            activeForm = childform;
            childform.TopLevel = false;
            childform.Dock = DockStyle.Fill;
            ChangingPanel.Controls.Add(activeForm);
            ChangingPanel.Tag = childform;
            
            childform.BringToFront();
            childform.Show();

        }

        private void closeChildForm()
        {
            ChangingPanel.Controls.Remove(activeForm);
            if (activeForm!=null)
            activeForm.Close();
            activeForm = null;
        }
    }
}
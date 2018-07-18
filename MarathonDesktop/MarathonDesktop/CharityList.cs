﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace MarathonDesktop
{
    public partial class CharityList : Form
    {
        public CharityList()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection("server=DESKTOP-FHVMNUE;Trusted_Connection=yes;database=marathon;");
            conn.Open();
            SqlCommand comm = new SqlCommand("select * from [charity]",conn);
            SqlDataReader reader = comm.ExecuteReader();
            int i = 1;
            int[] top = new int[100];
            //Используй DataGridView или хотя бы ListView
            while (reader.Read())
            {
                
                string c_name = reader["CharityName"].ToString();
                string c_desc = reader["CharityDescription"].ToString();
                string logo = reader["CharityLogo"].ToString();
                top[0] = 50;
                top[i] = 160+top[i-1]+ c_desc.Length / 2;

                PictureBox pb = new PictureBox();
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromFile(logo);
                pb.Left = 25;
                pb.Top = top[i - 1]+80;
                pb.Width = 250;
                pb.Height = 150;
                this.Controls.Add(pb);
                this.AutoScroll = true;

                Label name = new Label();
                name.Font = new Font("Arial", 16);
                name.Left = 500;
                name.Top= top[i - 1] + 80;
                name.Text = c_name;
                this.Controls.Add(name);

                Label desc = new Label();
                desc.Font = new Font("Arial", 13);
                desc.Left = 380;
             
           
                desc.Top = top[i - 1] + 100;
                desc.Text = c_desc;
               desc.Height = c_desc.Length / 2 +120;
                this.Controls.Add(desc);
              
                desc.Width = 400;
                i++;
            }


            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }
        //Повторяется в нескольких окнах, можно избежать с помощью базовых форм
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dNow = DateTime.Now;
            DateTime dStart = new DateTime(2018, 11, 24);
            TimeSpan f = dStart - dNow;
            int days = f.Days;
            int hours = f.Hours;
            int min = f.Minutes;


            label1.Text = days.ToString() + " дней " + hours.ToString() + " часов " + min.ToString() + " минут до начала гонки";

        }
        //Повторяется в нескольких окнах, можно избежать с помощью базовых форм
        private void button3_Click(object sender, EventArgs e)
        {
            MoreInfo f = new MoreInfo();
            f.Show();
            this.Close();
        }
    }
}

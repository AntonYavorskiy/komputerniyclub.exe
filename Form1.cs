using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace vhod
{
    public partial class Form1 : Form
    {
        private SQLiteConnection DB;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = users.db; Version=3");
            DB.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (loginbox.Text == "" || passwordbox.Text == "")
            MessageBox.Show("Пожалуйста, заполните все поля");
            if (loginbox.Text != "" && passwordbox.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "select * from accounts where login like @login and password like  @password ";
                CMD.Parameters.Add("@login", System.Data.DbType.String).Value = loginbox.Text.ToUpper();
                CMD.Parameters.Add("@password", System.Data.DbType.String).Value = passwordbox.Text.ToUpper();
                SQLiteDataReader SQL = CMD.ExecuteReader();
                if (SQL.HasRows)
                {
                    while(SQL.Read())
                    {

                        MessageBox.Show(string.Format("Здравствуйте, {0} {1}", SQL["name"],SQL["fio"] ));
                        menu m = new menu();
                        this.Hide();
                        m.ShowDialog();
                        this.Show();

                    }
                }
                else MessageBox.Show("Вы ввели неверные данные");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            register f = new register();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}

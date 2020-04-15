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
    public partial class register : Form
    {
        private SQLiteConnection DB;
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rname.Text == "" || rfio.Text == "" || rhbd.Text == "" || rlogin.Text == "" || rpassword.Text == "")
                MessageBox.Show("Не все поля заполнены");
            if (rlogin.Text != "" && rpassword.Text != "" && rname.Text != "" && rfio.Text != "" && rhbd.Text != "")
            {
                SQLiteCommand CMD = DB.CreateCommand();
                CMD.CommandText = "insert into accounts(login,password,name,fio,hbd) values(@login,@password,@name,@fio,@hbd)";
                CMD.Parameters.Add("@login", System.Data.DbType.String).Value = rlogin.Text.ToUpper();
                CMD.Parameters.Add("@password", System.Data.DbType.String).Value = rpassword.Text.ToUpper();
                CMD.Parameters.Add("@name", System.Data.DbType.String).Value = rname.Text.ToUpper();
                CMD.Parameters.Add("@fio", System.Data.DbType.String).Value = rfio.Text.ToUpper();
                CMD.Parameters.Add("@hbd", System.Data.DbType.String).Value = rhbd.Text.ToUpper();
                CMD.ExecuteNonQuery();
                MessageBox.Show("Вы успешно зарегистрировались, теперь вы можете авторизироваться");
            }
            
        }

        private void register_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection("Data Source = users.db; Version=3");
            DB.Open();
        }

        private void register_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

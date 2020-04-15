using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace vhod
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            timer2.Interval = 660;
            timer.Interval = 1000;
            timer.Elapsed += timer1_Tick;
            timer.Enabled = true;
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
           
            if (pc1.Enabled == true)
            {
                pc1.Enabled = false;
                pc1.BackColor = Color.Silver;

            }
            else

               if (pc1.Enabled == false)
            {
               
                pc1.Enabled = true;
                pc1.BackColor = Color.Chartreuse;
            }

        }
 System.Timers.Timer timer = new System.Timers.Timer();
        private void timer1_Tick(object sender, EventArgs e)
        {

            var str = DateTime.Now.ToString("HH:mm:ss");

            if (label2.InvokeRequired) label2.Invoke(new Action<string>((s) => label2.Text = s), str);
            else label2.Text = str;
           


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    pc1.Enabled = false;
                    pc1.BackColor = Color.Silver;

                    break;
                case 1:
                    MessageBox.Show("Выбран второй");
                    break;
            }
        }
        public bool b = true;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (b)
            {
                this.BackColor = Color.Blue;this.BackColor = Color.Red;
                
            }
            
            
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    timer2.Start();
                 

                    break;
                case 1:
                    MessageBox.Show("Выбран второй");
                    break;
            }
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}

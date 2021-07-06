using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerviyProekt
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Пользователь");
            comboBox1.Items.Add("Администратор");
            
        }
        string Permission;
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Permission = comboBox1.SelectedItem.ToString();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                string Password = textBox1.Text;
                string Login = textBox3.Text;
                User user = new User(Password, Login, Permission);

            }
            this.Hide();
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

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

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = comboBox1.SelectedItem.ToString();
            
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}

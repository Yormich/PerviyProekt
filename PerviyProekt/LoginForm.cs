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
    public partial class LoginForm : Form
    {
        UserStorage RL = new UserStorage();
        public LoginForm()
        {
   
            InitializeComponent();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void UserIcon_Click(object sender, EventArgs e)
        {

        }

        private void RegFormButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegForm registerForm = new RegForm();
            registerForm.Show();
        }

        private void RegFormButton_MouseEnter(object sender, EventArgs e)
        {
            RegFormButton.ForeColor = Color.Blue;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LogButton_Click(object sender, EventArgs e)
        {
            String Login = LoginField.Text;
            String PassWord = PassField.Text;
            if (RL.ReadDocument(RL.GetPath(),Login,PassWord))
            {
                MessageBox.Show("Вы успешно авторизовались!");
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Не удалось авторизоваться.");
                LoginField.Clear();
                PassField.Clear();
            }
        }

        private void RegFormButton_MouseLeave(object sender, EventArgs e)
        {
            RegFormButton.ForeColor = Color.Black;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }

}


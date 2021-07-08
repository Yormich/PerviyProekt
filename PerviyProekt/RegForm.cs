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
        Storage db;
        public RegForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Пользователь");
            comboBox1.Items.Add("Администратор");
            db = new Storage();              
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
            string passWord = PassField1.Text;
            string PassWordRep = PassField2.Text;
            string login = LoginField1.Text;
            if (login.Length < 4)
            {
                MessageBox.Show("Ваш логин слишком короткий.");
            }
            else if (passWord.Length < 5)
            {
                MessageBox.Show("Ваш пароль слишком короткий.");
            }
            else if (passWord != PassWordRep)
            {
                MessageBox.Show("Пароли не совпадают.Повторите попытку.");
            }
            else
            {
                User user = new User(login, passWord, Permission);
                db.Users.Add(user);
                db.SaveChanges();   
                this.Hide();
                LoginForm LoginForm = new LoginForm();
                LoginForm.Show();
            }
        }

        private void ExitButton_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }
    }
}

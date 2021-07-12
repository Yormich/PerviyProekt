using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PerviyProekt
{
    public partial class RegForm : Form
    {
        UserStorage RL= new UserStorage();
        public RegForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("Пользователь");
            comboBox1.Items.Add("Администратор");
                 
        }
        string Permission=null;
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
            int MinFieldLength = 5;
            if (login.Length < MinFieldLength)
            {
                MessageBox.Show("Ваш логин слишком короткий.");
            }
            else if (passWord.Length < MinFieldLength)
            {
                MessageBox.Show("Ваш пароль слишком короткий.");
            }
            else if (passWord != PassWordRep)
            {
                MessageBox.Show("Пароли не совпадают.Повторите попытку.");
            }
            else if (Permission == null)
            {
                MessageBox.Show("Вы не выбрали тип пользователя.");
            }
            else
            {
                User user = new User(login, passWord, Permission);
                RL.AddToDocument(RL.GetPath(),user);
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
            if(!File.Exists(RL.GetPath()))
            {
                RL.CreateXMLDocument(RL.GetPath());
            }
        }
    }
}

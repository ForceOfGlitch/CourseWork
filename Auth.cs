using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursProject
{
    public partial class Auth : Form
    {
        string connect;
        public Auth()
        {
            InitializeComponent();
            connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString; // строка подключения из App.config
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect); // создаем подключение
            if (!string.IsNullOrEmpty(textBox1.Text))
            {

                string sql2 = @"SELECT * FROM Users where UserName = '"+ textBox1.Text +"'"; // запрос
                SqlCommand command2 = new SqlCommand(sql2, conn); // экземпляр класса SQL запроса
                try
                {
                    conn.Open(); // открываем подключение
                    SqlDataReader reader2 = command2.ExecuteReader(); // выполняем запрос
                    int count = 0;
                    while (reader2.Read()) // читаем все совпадения 
                    {
                        count++;

                        List<string> args = new List<string>(); // 0 - id, 1 - имя, 2 - год, 3 - пол

                        args.Add(reader2[0].ToString());
                        args.Add(reader2[1].ToString());
                        args.Add(reader2[2].ToString());
                        args.Add(reader2[3].ToString());

                        Input newForm = new Input(true, this, args);
                        Visible = false;
                        newForm.ShowDialog();
                    }
                    if (count == 0)// если совпадений нет, то оповещаем
                    {
                        MessageBox.Show("В системе нет такого пользователя");
                    }

                    reader2.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Имя пользователя не может быть пустым!");
            }
        }


        private void regButton_Click(object sender, EventArgs e)
        {
            Input newForm = new Input(false, this, new List<string>());
            Visible = false;
            newForm.ShowDialog();
        }
    }
}

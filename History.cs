using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace KursProject
{
    public partial class History : Form
    {
        private int userId;
        string connect;
        public History()
        {
            InitializeComponent();
        }

        public History(string userId)
        {
            InitializeComponent();

            this.userId = Convert.ToInt32(userId);
            connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;//тут у нас строка подключения из App.config

            SqlConnection conn = new SqlConnection(connect);//создаем подключение

            string sql = @"SELECT * FROM UserStatuses where IdUser = '" + userId + "'";// тута запросик в базу
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                conn.Open();//открываем подключение
                List<string> firstArgs = new List<string>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())//читаем все строки
                {
                    //firstArgs.Clear();
                    firstArgs.Add(reader[9].ToString());
                    firstArgs.Add(reader[8].ToString());
                    firstArgs.Add(reader[3].ToString());
                    firstArgs.Add(reader[4].ToString());
                    firstArgs.Add(reader[6].ToString());
                    firstArgs.Add(reader[5].ToString());
                }

                reader.Close();
                conn.Close();

                List<string> requests = new List<string>();
                requests.Add(@"SELECT * FROM MobilityLevels where IdMobilityLevel = '");
                requests.Add(@"SELECT * FROM Goals where IdGoal = '");
                requests.Add(@"SELECT * FROM Nutrients where IdNutrient = '");
                requests.Add(@"SELECT * FROM Knuckles where IdKnuckle = '");


                for (int j = 2; j < 6; j++)
                {
                    int count = 0;
                    while (count < (firstArgs.Count() / 6))
                    {
                        sql = requests[j - 2] + firstArgs[j + 6 * count] + "'";
                        command = new SqlCommand(sql, conn);

                        conn.Open();
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            firstArgs[j + 6 * count] = reader[1].ToString();
                        }
                        count++;
                        reader.Close();
                        conn.Close();
                    }


                }

                int count1 = 0;
                while(count1 < firstArgs.Count())
                {
                    if (count1 % 6 == 0) dataGridView1.Rows.Add();
                    dataGridView1.Rows[count1 / 6].Cells[count1 % 6].Value = firstArgs[count1];
                    count1++;
                }

                conn.Close();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так...");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

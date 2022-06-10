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
    public partial class Input : Form
    {
        bool isNotReg;
        Form mainForm;
        string connect;
        List<string> args = new List<string>();
        public Input()
        {
            InitializeComponent();
        }

        public Input(bool isNotReg, Form form, List<string> inputArgs) // 0 - id, 1 - имя, 2 - год, 3 - пол
        {
            InitializeComponent();

            args = inputArgs;
            mainForm = form;
            this.isNotReg = isNotReg;

            if (isNotReg)
            {
                nameTextBox.Text = inputArgs[1];
                nameTextBox.Enabled = false;
                birthYearTextBox.Text = inputArgs[2];
                birthYearTextBox.Enabled = false;
                sexComboBox.Text = (inputArgs[3] == "True") ? "Мужской": "Женский";
                sexComboBox.Enabled = false;

                connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString; //тут у нас строка подключения из App.config
                SqlConnection conn = new SqlConnection(connect); //создаем подключение

                string sql = @"SELECT * FROM UserStatuses where IdUser = '" + inputArgs[0] + "'"; // тута запросик в базу
                SqlCommand command = new SqlCommand(sql, conn); // создаем запросик для SQL, передавая текст запроса и строку подключения

                try
                {
                    conn.Open(); // открываем подключение
                    SqlDataReader reader = command.ExecuteReader(); // выполняем запросик
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            switch (reader[3].ToString())
                            {
                                case "1":
                                    levelActivityComboBox.Text = "Низкий";
                                    break;
                                case "2":
                                    levelActivityComboBox.Text = "Средний";
                                    break;
                                case "3":
                                    levelActivityComboBox.Text = "Высокий";
                                    break;
                                default:
                                    break;
                            }

                            switch (reader[4].ToString())
                            {
                                case "1":
                                    goalComboBox.Text = "Похудеть";
                                    break;
                                case "2":
                                    goalComboBox.Text = "Набрать массу";
                                    break;
                                default:
                                    break;
                            }

                            switch (reader[5].ToString())
                            {
                                case "1":
                                    trobleKnuckleComboBox.Text = "Голеностоп";
                                    break;
                                case "2":
                                    trobleKnuckleComboBox.Text = "Коленный";
                                    break;
                                case "3":
                                    trobleKnuckleComboBox.Text = "Тазобедренный";
                                    break;
                                case "4":
                                    trobleKnuckleComboBox.Text = "Плечевой";
                                    break;
                                case "5":
                                    trobleKnuckleComboBox.Text = "Локтевой";
                                    break;
                                default:
                                    break;
                            }

                            switch (reader[6].ToString())
                            {
                                case "1":
                                    trobleKnuckleComboBox.Text = "Кальций";
                                    break;
                                case "2":
                                    trobleKnuckleComboBox.Text = "Магний";
                                    break;
                                case "3":
                                    trobleKnuckleComboBox.Text = "Фосфор";
                                    break;
                                default:
                                    break;
                            }

                            weightTextBox.Text = reader[8].ToString();
                        }
                    }

                    reader.Close();//не забываем закрыть ридер, чтобы потом можно было еще базу юзать
                    conn.Close();//ну и подключение закрываем, на кой оно нам
                }
                catch
                {
                    MessageBox.Show("Подключение отсутствует! Input"); //читай что пишет, все поймешь
                }
            }
        }

        private void foodButton_Click(object sender, EventArgs e)
        {
            if (args.Count() == 0)
            {
                MessageBox.Show("Вы ещё не зарегистрировались!");
            }
            else
            {
                Food newFoodForm = new Food();
                newFoodForm.ShowDialog();
            }
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            if (args.Count() == 0)
            {
                MessageBox.Show("Вы ещё не зарегистрировались!");
            }
            else
            {
                History newForm = new History(args[0].ToString());
                newForm.ShowDialog();
            }
        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text == "" || sexComboBox.Text == "" || birthYearTextBox.Text == ""
                || weightTextBox.Text == "" || goalComboBox.Text == "" || levelActivityComboBox.Text == "")
            {
                MessageBox.Show("Введены не все обязательные параметры!");
            }
            else
            {
                if(isNotReg)
                {
                    List<string> temp = new List<string>();
                    for (int k = 0; k < 4; k++) temp.Add(args[k]);
                    args.Clear();
                    for (int k = 0; k < 4; k++) args.Add(temp[k]);
                    args[3] = sexComboBox.Text;
                    args.Add(weightTextBox.Text);
                    args.Add(goalComboBox.Text);
                    args.Add(levelActivityComboBox.Text);
                    args.Add(lackNutrientComboBox.Text);
                    args.Add(trobleKnuckleComboBox.Text);
                }
                else
                {
                    args.Clear();
                    args.Add("0");
                    args.Add(nameTextBox.Text);
                    args.Add(birthYearTextBox.Text);
                    args.Add(sexComboBox.Text);
                    

                    args.Add(weightTextBox.Text);
                    args.Add(goalComboBox.Text);
                    args.Add(levelActivityComboBox.Text);
                    args.Add(lackNutrientComboBox.Text);
                    args.Add(trobleKnuckleComboBox.Text);
                }

                Result newForm = new Result(args); // НЕ РЕГИСТРАЦИЯ: 0 - id, 1 - имя, 2 - год, 3 - пол, 4 - вес, 5 - цель, 6 - уровень активности 7-нутр 8-сустав
                                                   // РЕГИСТРАЦИЯ: 0-место для id(default 0) 1-имя 2-год 3-пол 4-вес 5-цель 6-уровень акт 7-нутриент 8-сустав
                newForm.ShowDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lackNutrientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lackNutrientLabel_Click(object sender, EventArgs e)
        {

        }

        private void Input_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Visible = true;
        }

        private void goalLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

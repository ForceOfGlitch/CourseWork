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
    public partial class Result : Form
    {
        string[,] argFoodUnits;
        double argCal, argProt, argFats, argCarb, argNutr;
        int argType;
        Random argRand;

        string[,] argExercises;
        int goal; // 0 - набор массы 1 - похудение
        int activityLevel;
        string knuckle;

        public Result(List<string> args) //0 - id, 1 - имя, 2 - год, 3 - пол, 4 - вес, 5 - цель, 6 - уровень активности 7-нутр 8-сустав
        {
            InitializeComponent();

            dietResult(args);
            exerciseResult(args);

            if (args[0] == "0") // если регистрация, то сначала вносим пользвателя в базу, потом по него делаем статус
            {
                string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

                List<string> values = new List<string>();

                SqlConnection conn = new SqlConnection(connect);

                int age = DateTime.Now.Year - Convert.ToInt32(args[2]);

                string sex = args[2] == "Мужской" ? "True" : "False";

                string insert = @"INSERT Users VALUES ('" + args[1] + "', '" + args[2] + "',  '" + sex + "')";

                SqlCommand command = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось записать нового пользователя");
                }

                int currUserId = 0;

                string select = @"SELECT IdUser FROM Users where UserName = '" + args[1] + "' AND BirthYear = '" + args[2] + "' AND Sex = '" + sex + "'";

                command = new SqlCommand(select, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        currUserId = Convert.ToInt32(reader[0].ToString());
                    }
                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные о текущем пользователе (регистрация)");
                }

                int idMobLvl = 1;
                if (args[6] == "Средний") idMobLvl = 2;
                if (args[6] == "Высокий") idMobLvl = 3;

                int idGoal = 1;
                if (args[5] == "Набрать массу") idGoal = 2;

                int idKnuckle = 1;
                if (args[8] == "Тазобедренный") idKnuckle = 2;
                if (args[8] == "Плечевой") idKnuckle = 3;
                if (args[8] == "Локтевой") idKnuckle = 4;
                if (args[8] == "Позвоночник") idKnuckle = 5;

                int idNutrient = 1;
                if (args[7] == "Магний") idNutrient = 2;
                if (args[7] == "Фосфор") idNutrient = 3;
                
                insert = @"INSERT UserStatuses VALUES ('" + currUserId + "', '" + 1 + "', '" + idMobLvl + "', '" + idGoal + "', " +
                    " '" + idKnuckle + "', '" + idNutrient + "',  '" + 1 + "', '" + args[4] + "',  '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day +"')";

                command = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось записать состояние пользователя");
                }
            }
            else // если не регистрация, то просто записывает новое состояние в бд
            {
                string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

                List<string> values = new List<string>();

                SqlConnection conn = new SqlConnection(connect);

                int age = DateTime.Now.Year - Convert.ToInt32(args[2]);

                string sex = args[2] == "Мужской" ? "True" : "False";

                int idMobLvl = 1;
                if (args[6] == "Средний") idMobLvl = 2;
                if (args[6] == "Высокий") idMobLvl = 3;

                int idGoal = 1;
                if (args[5] == "Набрать массу") idGoal = 2;

                int idKnuckle = 1;
                if (args[8] == "Тазобедренный") idKnuckle = 2;
                if (args[8] == "Плечевой") idKnuckle = 3;
                if (args[8] == "Локтевой") idKnuckle = 4;
                if (args[8] == "Позвоночник") idKnuckle = 5;

                int idNutrient = 1;
                if (args[7] == "Магний") idNutrient = 2;
                if (args[7] == "Фосфор") idNutrient = 3;


                string insert = @"INSERT UserStatuses VALUES ('" + args[0] + "', '" + 1 + "',  '" + idMobLvl + "', '" + idGoal + "'," +
                    "  '" + idKnuckle + "', '" + idNutrient + "',  '" + 1 + "', '" + args[4] + "',  '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "')";

                SqlCommand command = new SqlCommand(insert, conn);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось записать состояние пользователя");
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Food newForm = new Food();
            newForm.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e) // если нажали на ячейку с тренировками
        {
            List<string> args = new List<string>();
            List<string> knuckles = new List<string>();

            for (int j = 0; j < dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells.Count; j++)
            {
                string str = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[j].Value.ToString();
                args.Add(str);
            }

            string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

            SqlConnection conn = new SqlConnection(connect);

            string select = @"SELECT IdExercise FROM Exercises where ExerciseName = '" + args[0] + "'";

            SqlCommand command = new SqlCommand(select, conn);

            int IdExercise = 0;

            try
            {
                conn.Open();//открываем подключение
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        IdExercise = Convert.ToInt32(reader[0].ToString());
                    }
                }

                reader.Close();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось получить даные из таблицы упражнений (инфо об упр)");
            }

            select = @"SELECT IdKnuckle FROM KnuckleExercise where IdExercise = '" + IdExercise + "'";

            List<int> knucklesId = new List<int>();

            command = new SqlCommand(select, conn);

            try
            {
                conn.Open();//открываем подключение
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        knucklesId.Add(Convert.ToInt32(reader[0].ToString()));
                    }
                }

                reader.Close();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось получить даные из таблицы связи упражнений и суставов");
            }

            foreach (int id in knucklesId)
            {
                select = @"SELECT KnuckleName FROM Knuckles where IdKnuckle = '" + id + "'";

                command = new SqlCommand(select, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            knuckles.Add(reader[0].ToString());
                        }
                    }
                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось получить даные из таблицы суставов");
                }
            }

            ExcerciseInfo newForm = new ExcerciseInfo(args, knuckles);
            newForm.ShowDialog();
        }
        private void exerciseResult(List<string> args)
        {
            label10.Text = "Цель тренировок: " + args[5];
            label9.Text = "Уровень активности: " + args[6];
            label7.Text = "Сустав без нагрузки: " + args[8];

            string[,] exercises = new string[11, 2];

            knuckle = args[8];
            if (args[5] == "Похудеть") goal = 1;
            else goal = 0;

            switch (args[6]) // Проверка на уровень активности
            {
                case "Низкий":
                    activityLevel = 1;
                    break;
                case "Средний":
                    activityLevel = 2;
                    break;
                case "Высокий":
                    activityLevel = 3;
                    break;
                default:
                    break;
            }

            string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString; // тут у нас строка подключения из App.config

            SqlConnection conn = new SqlConnection(connect); // создаем подключение

            string sql = @"SELECT * FROM Exercises"; // тута запросик в базу
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                conn.Open();//открываем подключение
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            exercises[count, j] = reader[j].ToString();
                        }
                        count++;
                    }
                }

                reader.Close();
                conn.Close();

                Random rand = new Random();
                argRand = rand;
                argExercises = exercises;

                ExercisesOnBoard();
            }
            catch
            {
                MessageBox.Show("Не получилось сформировать тренеровочный план. Попробуйте ещё раз.");
            }
        }

        private void dietResult(List<string> args) // 0 - id, 1 - имя, 2 - год, 3 - пол, 4 - вес, 5 - цель, 6 - уровень активности, 7 - дефиц нутриент, 8 - проблемный сустав
        {

            string[,] foodUnits = new string[27, 6];

            string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;//тут у нас строка подключения из App.config

            SqlConnection conn = new SqlConnection(connect);//создаем подключение

            string sql = @"SELECT * FROM FoodUnits";// тута запросик в базу
            SqlCommand command = new SqlCommand(sql, conn);
            try
            {
                conn.Open();//открываем подключение
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    int count = 0;
                    while(reader.Read())
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            foodUnits[count, j] = reader[j].ToString();
                        }
                        count++;
                    }
                }

                reader.Close();
                conn.Close();

                double cal = 0; // дневная потребность ккал
                double proteins = 0; // дневная потребность в белках
                double fats = 0; // дневная потребность в жирах
                double carbohydrates = 0; // дневная потребность углеводах
                double nutrient; // дневная потребность в нутриенте
                int typeOfNutrient; // тип нутриента

                var currentYear = DateTime.Now.Year;

                if (args[3] == "Мужской")
                {
                    cal = 10 * Convert.ToDouble(args[4]) + 6.25 * 175 - 5 * (Convert.ToInt32(args[2]) - currentYear) + 5;
                }
                else
                {
                    cal = 10 * Convert.ToDouble(args[4]) + 6.25 * 162 - 5 * (Convert.ToInt32(args[2]) - currentYear) - 161;
                }

                switch (args[6]) // Проверка на уровень активности
                {
                    case "Низкий":
                        cal *= 1.2;
                        activityLevel = 1;
                        break;
                    case "Средний":
                        cal *= 1.55;
                        activityLevel = 2;
                        break;
                    case "Высокий":
                        cal *= 1.7;
                        activityLevel = 3;
                        break;
                    default:
                        break;
                }

                switch (args[5]) // Проверка на цель
                {
                    case "Похудеть":
                        cal -= cal * 0.1;
                        break;
                    case "Набрать массу":
                        cal += cal * 0.1;
                        break;
                    default:
                        break;
                }
                label1.Text = "Ккал (грамм):" + Convert.ToInt32(cal).ToString();

                proteins = cal * 0.2 / 4; // Соотношение БЖУ от ккал 0.2/0.3/0.5
                fats = cal * 0.3 / 9;
                carbohydrates = cal * 0.5 / 4;

                label2.Text = "Белки (грамм):" + Convert.ToInt32(proteins).ToString();
                label3.Text = "Жиры (грамм):" + Convert.ToInt32(fats).ToString();
                label4.Text = "Углеводы (грамм):" + Convert.ToInt32(carbohydrates).ToString();

                switch (args[7]) // Проверка на нутриент
                {
                    case "Кальций":
                        nutrient = 1000;
                        typeOfNutrient = 1;
                        label5.Text = "Кальций (миллиграмм):" + Convert.ToInt32(nutrient).ToString();
                        break;
                    case "Магний":
                        nutrient = 400;
                        typeOfNutrient = 2;
                        label5.Text = "Кальций (миллиграмм):" + Convert.ToInt32(nutrient).ToString();
                        break;
                    case "Фосфор":
                        nutrient = 700;
                        typeOfNutrient = 3;
                        label5.Text = "Кальций (миллиграмм):" + Convert.ToInt32(nutrient).ToString();
                        break;
                    default:
                        nutrient = 0;
                        typeOfNutrient = 0;
                        label5.Text = "Нутриент не указан";
                        break;
                }
                

                Random rand = new Random();

                argFoodUnits = foodUnits;
                argCal = cal;
                argProt = proteins;
                argCarb = carbohydrates;
                argNutr = nutrient;
                argType = typeOfNutrient;
                argRand = rand;

                DietOnBoard();
            }
            catch
            {
                MessageBox.Show("Не получилось сформировать план дневного питания. Попробуйте ещё раз.");
            }
        }

        private string[,] createDiet(string[,] foodUnits, double cal, double proteins, 
            double fats, double carbohydrates,double nutrient, int typeOfNutrient, Random rand)
        {
            string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;//тут у нас строка подключения из App.config

            SqlConnection conn = new SqlConnection(connect);//создаем подключение

            List<int> idRand = new List<int>();

            int lenOfArr = rand.Next(6, 9);

            string[,] diet = new string[lenOfArr + 1, 7];

            for (int i = 0; i < lenOfArr; i++)
            {
                idRand.Add(randId(foodUnits.Length / 6, idRand, rand));
            }

            double sumCal = 0;
            double sumProt = 0;
            double sumFats = 0;
            double sumCarb = 0;
            double sumNutr = 0;

            int[] weights = new int[lenOfArr];
            int count = 0;

            int min = 8, max = 25;

            switch (activityLevel)
            {
                case 1:
                    {
                        min = 8;
                        max = 25;
                        break;
                    }
                case 2:
                    {
                        min = 10;
                        max = 30;
                        break;
                    }
                case 3:
                    {
                        min = 15;
                        max = 35;
                        break;
                    }
            }

            foreach (int i in idRand)
            {

                int a = rand.Next(min, max);
                weights[count] = a * 10;
                sumCal += Convert.ToInt32(foodUnits[i, 2]) * 10 * a / 100;
                sumProt += Convert.ToInt32(foodUnits[i, 3]) * 10 * a / 100;
                sumFats += Convert.ToInt32(foodUnits[i, 4]) * 10 * a / 100;
                sumCarb += Convert.ToInt32(foodUnits[i, 5]) * 10 * a / 100;

                string select = @"SELECT Value FROM FoodUnitNutrient where IdFoodUnit = '" + foodUnits[i, 0] + "' and IdNutrient = '" + argType + "'";// тута запросик в базу

                SqlCommand command = new SqlCommand(select, conn);

                try
                {
                    conn.Open();//открываем подключение
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sumNutr += Convert.ToInt32(reader[0].ToString()) * 10 * a / 100;
                        }
                    }

                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Ещё раз");
                }

                count++;
            }

            if ( (sumCal < cal + 500 && sumCal > cal - 500 && sumProt < proteins + 50 && sumProt > proteins - 50
                && sumFats < fats + 50 && sumFats > fats - 50 && sumCarb < carbohydrates + 50 && sumCarb > carbohydrates - 50
                && sumNutr < nutrient + 500 && sumNutr > nutrient - 100) )
            {
                for (int i = 0; i < lenOfArr; i++)
                {
                    for(int j = 0; j < 6; j++)
                    {
                        diet[i, j] = foodUnits[idRand[i], j];
                    }
                    diet[i, 6] = weights[i].ToString();
                }
                diet[lenOfArr, 0] = "true";
                return diet;
            }
            else
            {
                diet[lenOfArr, 0] = "false";
                return diet;
            }
        }

        private int randId(int len, List<int> idRand, Random rand)
        {
            int val = rand.Next(0, len);
            if (!idRand.Contains(val))
            {
                return val;
            }
            else
            {
                return randId(len, idRand, rand);
            }
        }

        private void exerciseButton_Click(object sender, EventArgs e)
        {
            ExercisesOnBoard();
        }

        private void dietButton_Click(object sender, EventArgs e)
        {
            DietOnBoard();
        }

        private void DietOnBoard()
        {
            try
            {
                string[,] diet = createDiet(argFoodUnits, argCal, argProt, argFats, argCarb, argNutr, argType, argRand);
                while(diet[diet.Length / 7 - 1, 0] == "false")
                {
                    diet = createDiet(argFoodUnits, argCal, argProt, argFats, argCarb, argNutr, argType, argRand);
                }
                string[] sqls = new string[diet.Length]; // Данные по нутриентам в порциях в отдельном массиве
                for (int h = 0; h < diet.Length / 7 - 1; h++)
                {
                    sqls[h] = @"SELECT Value FROM FoodUnitNutrient where IdFoodUnit = '" + diet[h, 0] + "' and IdNutrient = '" + argType + "'";// тута запросик в базу
                }

                string[] nutrientsInDish = new string[diet.Length / 7 - 1];

                if (argType != 0)
                {
                    string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;//тут у нас строка подключения из App.config

                    SqlConnection conn = new SqlConnection(connect);//создаем подключение
                    for (int j = 0; j < diet.Length / 7 - 1; j++)
                    {
                        SqlCommand command = new SqlCommand(sqls[j], conn);

                        conn.Open();//открываем подключение
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                nutrientsInDish[j] = reader[0].ToString();
                            }
                        }

                        reader.Close();
                        conn.Close();
                    }
                }
                dataGridView1.Rows.Clear();
                for (int iter1 = 0; iter1 < diet.Length / 7 - 1; iter1++)
                {
                    dataGridView1.Rows.Add();
                    for (int iter2 = 1; iter2 < 8; iter2++)
                    {
                        if (iter2 != 7) dataGridView1.Rows[iter1].Cells[iter2 - 1].Value = diet[iter1, iter2];
                        else
                        {
                            double a = Convert.ToDouble(diet[iter1, iter2 - 1]);
                            double b = Convert.ToDouble(nutrientsInDish[iter1]);
                            double c = a * b / 100;
                            dataGridView1.Rows[iter1].Cells[iter2 - 1].Value = c.ToString();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не получилось сформировать результат. Попробуйте ещё раз.");
            }            
        }

        private void ExercisesOnBoard()
        {

            try
            {
                string[,] plan = createExercises(argExercises, goal, activityLevel, knuckle, argRand);
               
                dataGridView2.Rows.Clear();
                for (int iter1 = 0; iter1 < plan.Length / 3; iter1++)
                {
                    dataGridView2.Rows.Add();
                    for (int iter2 = 0; iter2 < 3; iter2++)
                    {
                        dataGridView2.Rows[iter1].Cells[iter2].Value = plan[iter1, iter2];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не получилось сформировать результат. Попробуйте ещё раз.");
            }
        }

        private string[,] createExercises(string[,] exercises, int inpGoal, int inpActivityLevel, string inpKnuckle, Random random)
        {
            string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString; // тут у нас строка подключения из App.config

            SqlConnection conn = new SqlConnection(connect); // создаем подключение

            List<int> idRand = new List<int>();

            int lenOfArr = 3;

            switch (inpActivityLevel)
            {
                case 1:
                    {
                        lenOfArr = 3;
                        break;
                    }
                case 2:
                    {
                        lenOfArr = 4;
                        break;
                    }
                case 3:
                    {
                        lenOfArr = 5;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            string[,] exercisesPlan = new string[lenOfArr, 3];

            while (idRand.Count < lenOfArr)
            {
                bool isGood = true;
                int currRandId = randId(exercises.Length / 2, idRand, random) + 1;
                while (currRandId == 10) currRandId = randId(exercises.Length / 2, idRand, random) + 1;

                string select = @"SELECT * FROM KnuckleExercise where IdExercise = '" + currRandId + "'";// тута запросик в базу

                List<int> knucklesId = new List<int>();

                SqlCommand command = new SqlCommand(select, conn);

                try
                {
                    conn.Open();//открываем подключение
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            knucklesId.Add(Convert.ToInt32(reader[1].ToString()));
                        }
                    }

                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось получить даные из таблицы связи упражнений и суставов");
                }

                foreach(int id in knucklesId)
                {
                    select = @"SELECT KnuckleName FROM Knuckles where IdKnuckle = '" + id + "'";

                    command = new SqlCommand(select, conn);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if(reader[0].ToString() == inpKnuckle) isGood = false;
                            }
                        }
                        reader.Close();
                        conn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось получить даные из таблицы суставов");
                    }
                }

                if (isGood && !idRand.Contains(currRandId))
                {
                    idRand.Add(currRandId);
                }
            }

            int count = 0;
            foreach (int id in idRand) // заполняем план тренировок из бд с соотв id, составленными ранее
            {
                string select = @"SELECT * FROM Exercises where IdExercise = '" + id + "'";

                SqlCommand command = new SqlCommand(select, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            exercisesPlan[count,0] = reader[1].ToString();

                            if (goal == 1) exercisesPlan[count, 1] = "12-20";
                            else exercisesPlan[count, 1] = "8-12";

                            if (inpActivityLevel == 1) exercisesPlan[count, 2] = "3";
                            else exercisesPlan[count, 2] = "4";
                        }
                    }

                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось получить даные из таблицы упражнений");
                }
                count++;
            }

            return exercisesPlan;
        }
    }
}

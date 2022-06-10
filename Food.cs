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
    public partial class Food : Form
    {
        string connect;

        List<string> foodsId;
        List<string> foodsNames;

        public Food()
        {
            InitializeComponent();
            connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

            SqlConnection conn = new SqlConnection(connect);

            List<string> foodUnitsId = new List<string>();
            List<string> foodUnitsNames = new List<string>();

            string sql = @"SELECT * FROM FoodUnits";
            SqlCommand command = new SqlCommand(sql, conn); 
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    foodUnitsId.Add(reader[0].ToString());
                    foodUnitsNames.Add(reader[1].ToString());
                    dataGridView1.Rows.Add();
                    for(int i = 0; i < 5; i++)
                    {
                        dataGridView1.Rows[count].Cells[i].Value = reader[i+1].ToString();
                    }
                    count++;
                }
                reader.Close();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить данные о пищевых единицах");
            }

            List<int> nutrientsId = new List<int>();

            int count1 = 0;

            foodsId = foodUnitsId;
            foodsNames = foodUnitsNames;

            foreach (string id in foodUnitsId)
            {
                sql = @"SELECT IdNutrient, Value FROM FoodUnitNutrient where IdFoodUnit = '" + id + "'";
                command = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add();
                        for (int i = 1; i < 3; i++)
                        {
                            dataGridView2.Rows[count1].Cells[i].Value = reader[i - 1].ToString();
                            if (i == 1)
                            {
                                if (reader[i - 1].ToString() == "1") dataGridView2.Rows[count1].Cells[i].Value = "Кальций";
                                if (reader[i - 1].ToString() == "2") dataGridView2.Rows[count1].Cells[i].Value = "Магний";
                                if (reader[i - 1].ToString() == "3") dataGridView2.Rows[count1].Cells[i].Value = "Фосфор";
                            }
                        }

                        dataGridView2.Rows[count1].Cells[0].Value = foodUnitsNames[foodUnitsId.IndexOf(id)];

                        count1++;
                    }
                    reader.Close();
                    conn.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось загрузить данные о нутриентах в пищ единицах");
                }
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            bool isCorrect1 = true;
            bool isCorrect2 = true;
            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++) // проверка корректности данных в таблице1
            {
                try
                {
                    for (int j = 1; j < dataGridView1.Rows[0].Cells.Count; j++)
                        Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                catch
                {
                    isCorrect1 = false;
                }
            }

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) // проверка корректности данных в таблице2
            {
                try
                {
                    isCorrect2 = false;
                    for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[0].Value.ToString() == dataGridView1.Rows[j].Cells[0].Value.ToString())
                        {
                            isCorrect2 = true;
                            j = dataGridView1.Rows.Count - 1;
                        }
                    }
                    if (!isCorrect2)
                    {
                        throw new Exception();
                    }
                    Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value.ToString());

                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() != "Кальций" && 
                        dataGridView2.Rows[i].Cells[1].Value.ToString() != "Магний" && 
                        dataGridView2.Rows[i].Cells[1].Value.ToString() != "Фосфор")
                    {
                        isCorrect2 = false;
                    }
                }
                catch
                {
                    isCorrect2 = false;
                    break;
                }
            }

            if(isCorrect1 && isCorrect2)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) // обновление записей в бд текущими записями первой таблицы
                {
                    string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

                    List<string> values = new List<string>();

                    SqlConnection conn = new SqlConnection(connect);

                    List<string> columnsTitles = new List<string>();
                    columnsTitles.Add("Name");
                    columnsTitles.Add("Calories");
                    columnsTitles.Add("Proteins");
                    columnsTitles.Add("Fats");
                    columnsTitles.Add("Carbohydrates");

                    for(int iter = 0; iter < columnsTitles.Count; iter++)
                    {
                        string update = @"update FoodUnits set " + columnsTitles[iter] + " = '" + 
                            dataGridView1.Rows[i].Cells[iter].Value.ToString() + "' where IdFoodUnit = '" + foodsId[i] + "'";

                        SqlCommand command = new SqlCommand(update, conn);

                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось записать данные");
                        }
                    }
                }

                /*for (int i = 0; i < dataGridView2.Rows.Count - 1; i++) // обновление записей в бд текущими записями второй таблицы
                {
                    string connect = ConfigurationManager.ConnectionStrings["KursDB"].ConnectionString;

                    List<string> values = new List<string>();

                    SqlConnection conn = new SqlConnection(connect);

                    List<string> columnsTitles = new List<string>();
                    columnsTitles.Add("Name");
                    columnsTitles.Add("Calories");
                    columnsTitles.Add("Proteins");
                    columnsTitles.Add("Fats");
                    columnsTitles.Add("Carbohydrates");

                    for (int iter = 0; iter < columnsTitles.Count; iter++)
                    {
                        string update = @"update FoodUnits set " + columnsTitles[iter] + " = '" + dataGridView1.Rows[i].Cells[iter].Value.ToString() + "' where IdFoodUnit = '" + foodsId[i] + "'";

                        SqlCommand command = new SqlCommand(update, conn);

                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось записать данные");
                        }
                    }
                }*/
            }
            else
            {
                MessageBox.Show("Проверьте корректность введённых данных");
            }
        }
    }
}

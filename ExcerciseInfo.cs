using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursProject
{
    public partial class ExcerciseInfo : Form
    {
        public ExcerciseInfo(List<string> args, List<string> knuckles) // 0-название 1-повторы 2-подходы
        {
            InitializeComponent();

            label1.Text = "Название упражнения: " + args[0];

            foreach(string str in knuckles)
            {
                label2.Text += " " + str + " ";
            }
            if (knuckles.Count == 0) label2.Text = "Нет суставов под напряжением";

            label3.Text = "Повторения: " + args[1];
            label4.Text = "Подходы: " + args[2];
        }

        private void ExcerciseInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}

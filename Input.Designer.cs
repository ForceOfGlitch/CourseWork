
namespace KursProject
{
    partial class Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.birthYearTextBox = new System.Windows.Forms.TextBox();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.levelActivityComboBox = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.birthYearLabel = new System.Windows.Forms.Label();
            this.sexLabel = new System.Windows.Forms.Label();
            this.mobilityLevelLabel = new System.Windows.Forms.Label();
            this.goalLabel = new System.Windows.Forms.Label();
            this.troubleKnuckleLabel = new System.Windows.Forms.Label();
            this.resultButton = new System.Windows.Forms.Button();
            this.historyButton = new System.Windows.Forms.Button();
            this.foodButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.lackNutrientLabel = new System.Windows.Forms.Label();
            this.lackNutrientComboBox = new System.Windows.Forms.ComboBox();
            this.trobleKnuckleComboBox = new System.Windows.Forms.ComboBox();
            this.goalComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameTextBox.Location = new System.Drawing.Point(7, 39);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(213, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // birthYearTextBox
            // 
            this.birthYearTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthYearTextBox.Location = new System.Drawing.Point(7, 129);
            this.birthYearTextBox.Name = "birthYearTextBox";
            this.birthYearTextBox.Size = new System.Drawing.Size(213, 20);
            this.birthYearTextBox.TabIndex = 2;
            // 
            // sexComboBox
            // 
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "Женский",
            "Мужской"});
            this.sexComboBox.Location = new System.Drawing.Point(7, 82);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(213, 21);
            this.sexComboBox.TabIndex = 3;
            // 
            // levelActivityComboBox
            // 
            this.levelActivityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelActivityComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelActivityComboBox.FormattingEnabled = true;
            this.levelActivityComboBox.Items.AddRange(new object[] {
            "Низкий",
            "Средний",
            "Высокий"});
            this.levelActivityComboBox.Location = new System.Drawing.Point(268, 82);
            this.levelActivityComboBox.Name = "levelActivityComboBox";
            this.levelActivityComboBox.Size = new System.Drawing.Size(213, 21);
            this.levelActivityComboBox.TabIndex = 6;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.Location = new System.Drawing.Point(6, 23);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(107, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Имя пользователя*";
            // 
            // birthYearLabel
            // 
            this.birthYearLabel.AutoSize = true;
            this.birthYearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.birthYearLabel.Location = new System.Drawing.Point(6, 113);
            this.birthYearLabel.Name = "birthYearLabel";
            this.birthYearLabel.Size = new System.Drawing.Size(82, 13);
            this.birthYearLabel.TabIndex = 8;
            this.birthYearLabel.Text = "Год рождения*";
            // 
            // sexLabel
            // 
            this.sexLabel.AutoSize = true;
            this.sexLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sexLabel.Location = new System.Drawing.Point(6, 69);
            this.sexLabel.Name = "sexLabel";
            this.sexLabel.Size = new System.Drawing.Size(31, 13);
            this.sexLabel.TabIndex = 9;
            this.sexLabel.Text = "Пол*";
            // 
            // mobilityLevelLabel
            // 
            this.mobilityLevelLabel.AutoSize = true;
            this.mobilityLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mobilityLevelLabel.Location = new System.Drawing.Point(264, 69);
            this.mobilityLevelLabel.Name = "mobilityLevelLabel";
            this.mobilityLevelLabel.Size = new System.Drawing.Size(137, 13);
            this.mobilityLevelLabel.TabIndex = 12;
            this.mobilityLevelLabel.Text = "Ваш уровень активности*";
            // 
            // goalLabel
            // 
            this.goalLabel.AutoSize = true;
            this.goalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goalLabel.Location = new System.Drawing.Point(265, 22);
            this.goalLabel.Name = "goalLabel";
            this.goalLabel.Size = new System.Drawing.Size(65, 13);
            this.goalLabel.TabIndex = 11;
            this.goalLabel.Text = "Ваша цель*";
            this.goalLabel.Click += new System.EventHandler(this.goalLabel_Click);
            // 
            // troubleKnuckleLabel
            // 
            this.troubleKnuckleLabel.AutoSize = true;
            this.troubleKnuckleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.troubleKnuckleLabel.Location = new System.Drawing.Point(264, 159);
            this.troubleKnuckleLabel.Name = "troubleKnuckleLabel";
            this.troubleKnuckleLabel.Size = new System.Drawing.Size(133, 13);
            this.troubleKnuckleLabel.TabIndex = 10;
            this.troubleKnuckleLabel.Text = "Травмированный сустав";
            // 
            // resultButton
            // 
            this.resultButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultButton.Location = new System.Drawing.Point(6, 19);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(179, 30);
            this.resultButton.TabIndex = 13;
            this.resultButton.Text = "Получить результат";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.resultButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.historyButton.Location = new System.Drawing.Point(6, 60);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(179, 30);
            this.historyButton.TabIndex = 14;
            this.historyButton.Text = "Просмотр истории состояний";
            this.historyButton.UseVisualStyleBackColor = true;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // foodButton
            // 
            this.foodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.foodButton.Location = new System.Drawing.Point(6, 98);
            this.foodButton.Name = "foodButton";
            this.foodButton.Size = new System.Drawing.Size(179, 42);
            this.foodButton.TabIndex = 15;
            this.foodButton.Text = "Редактирование пищевых единиц";
            this.foodButton.UseVisualStyleBackColor = true;
            this.foodButton.Click += new System.EventHandler(this.foodButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resultButton);
            this.groupBox1.Controls.Add(this.foodButton);
            this.groupBox1.Controls.Add(this.historyButton);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(534, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 149);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.weightTextBox);
            this.groupBox2.Controls.Add(this.weightLabel);
            this.groupBox2.Controls.Add(this.lackNutrientLabel);
            this.groupBox2.Controls.Add(this.lackNutrientComboBox);
            this.groupBox2.Controls.Add(this.trobleKnuckleComboBox);
            this.groupBox2.Controls.Add(this.goalComboBox);
            this.groupBox2.Controls.Add(this.nameLabel);
            this.groupBox2.Controls.Add(this.nameTextBox);
            this.groupBox2.Controls.Add(this.mobilityLevelLabel);
            this.groupBox2.Controls.Add(this.birthYearTextBox);
            this.groupBox2.Controls.Add(this.goalLabel);
            this.groupBox2.Controls.Add(this.sexComboBox);
            this.groupBox2.Controls.Add(this.troubleKnuckleLabel);
            this.groupBox2.Controls.Add(this.sexLabel);
            this.groupBox2.Controls.Add(this.birthYearLabel);
            this.groupBox2.Controls.Add(this.levelActivityComboBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 211);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ввод данных";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weightTextBox.Location = new System.Drawing.Point(7, 175);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(213, 20);
            this.weightTextBox.TabIndex = 17;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weightLabel.Location = new System.Drawing.Point(6, 159);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(30, 13);
            this.weightLabel.TabIndex = 18;
            this.weightLabel.Text = "Вес*";
            // 
            // lackNutrientLabel
            // 
            this.lackNutrientLabel.AutoSize = true;
            this.lackNutrientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lackNutrientLabel.Location = new System.Drawing.Point(264, 113);
            this.lackNutrientLabel.Name = "lackNutrientLabel";
            this.lackNutrientLabel.Size = new System.Drawing.Size(115, 13);
            this.lackNutrientLabel.TabIndex = 16;
            this.lackNutrientLabel.Text = "Нутриент в дефиците";
            this.lackNutrientLabel.Click += new System.EventHandler(this.lackNutrientLabel_Click);
            // 
            // lackNutrientComboBox
            // 
            this.lackNutrientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lackNutrientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lackNutrientComboBox.FormattingEnabled = true;
            this.lackNutrientComboBox.Items.AddRange(new object[] {
            "Кальций",
            "Магний",
            "Фосфор"});
            this.lackNutrientComboBox.Location = new System.Drawing.Point(268, 129);
            this.lackNutrientComboBox.Name = "lackNutrientComboBox";
            this.lackNutrientComboBox.Size = new System.Drawing.Size(213, 21);
            this.lackNutrientComboBox.TabIndex = 15;
            this.lackNutrientComboBox.SelectedIndexChanged += new System.EventHandler(this.lackNutrientComboBox_SelectedIndexChanged);
            // 
            // trobleKnuckleComboBox
            // 
            this.trobleKnuckleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trobleKnuckleComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trobleKnuckleComboBox.FormattingEnabled = true;
            this.trobleKnuckleComboBox.Items.AddRange(new object[] {
            "Коленный",
            "Тазобедренный",
            "Плечевой",
            "Локтевой",
            "Позвоночник"});
            this.trobleKnuckleComboBox.Location = new System.Drawing.Point(268, 174);
            this.trobleKnuckleComboBox.Name = "trobleKnuckleComboBox";
            this.trobleKnuckleComboBox.Size = new System.Drawing.Size(213, 21);
            this.trobleKnuckleComboBox.TabIndex = 14;
            // 
            // goalComboBox
            // 
            this.goalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.goalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.goalComboBox.FormattingEnabled = true;
            this.goalComboBox.Items.AddRange(new object[] {
            "Похудеть",
            "Набрать массу"});
            this.goalComboBox.Location = new System.Drawing.Point(268, 38);
            this.goalComboBox.Name = "goalComboBox";
            this.goalComboBox.Size = new System.Drawing.Size(213, 21);
            this.goalComboBox.TabIndex = 13;
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(738, 234);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Input_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox birthYearTextBox;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.ComboBox levelActivityComboBox;
        private System.Windows.Forms.Label birthYearLabel;
        private System.Windows.Forms.Label sexLabel;
        private System.Windows.Forms.Label mobilityLevelLabel;
        private System.Windows.Forms.Label goalLabel;
        private System.Windows.Forms.Label troubleKnuckleLabel;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button foodButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.ComboBox goalComboBox;
        private System.Windows.Forms.ComboBox trobleKnuckleComboBox;
        private System.Windows.Forms.Label lackNutrientLabel;
        private System.Windows.Forms.ComboBox lackNutrientComboBox;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.Label weightLabel;
    }
}
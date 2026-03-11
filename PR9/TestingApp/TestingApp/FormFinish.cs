using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TestingApp
{
    public partial class FormFinish : Form
    {
        private int userId;
        private int correctAnswers;
        private int totalQuestions;
        private int timeSpent;

        public FormFinish(int userId, int correct, int total, int timeSpent = 0)
        {
            InitializeComponent();
            this.userId = userId;
            this.correctAnswers = correct;
            this.totalQuestions = total;
            this.timeSpent = timeSpent;
        }

        private void FormFinish_Load(object sender, EventArgs e)
        {
            DisplayResult();
            LoadTestHistory();
        }

        private void DisplayResult()
        {
            double percentage = (double)correctAnswers / totalQuestions * 100;
            string percentageFormatted = percentage.ToString("F1");

            string gradeMessage;
            if (percentage >= 80)
                gradeMessage = "Отлично!";
            else if (percentage >= 60)
                gradeMessage = "Хорошо";
            else if (percentage >= 40)
                gradeMessage = "Удовлетворительно";
            else
                gradeMessage = "Попробуйте еще раз";

            string timeFormatted;
            if (timeSpent < 60)
                timeFormatted = $"{timeSpent} сек";
            else
                timeFormatted = $"{timeSpent / 60} мин {timeSpent % 60} сек";
            lblResult.Text = $"Правильных ответов: {correctAnswers} из {totalQuestions}\n" +
                             $"Результат: {percentageFormatted}% - {gradeMessage}";
        }

        private void LoadTestHistory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = @"
                        SELECT 
                            u.LastName + ' ' + u.FirstName AS 'Пользователь',
                            FORMAT(ua.TestDate, 'dd.MM.yyyy HH:mm') AS 'Дата теста',
                            SUM(CASE WHEN ua.IsCorrect = 1 THEN 1 ELSE 0 END) AS 'Баллы',
                            MAX(ua.TimeSpent) AS 'Время (сек)'
                        FROM UserAnswers ua
                        JOIN Users u ON ua.UserId = u.Id
                        WHERE ua.UserId = @userId
                        GROUP BY u.LastName, u.FirstName, ua.TestDate
                        ORDER BY ua.TestDate DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["Пользователь"].HeaderText = "Пользователь";
                        dataGridView1.Columns["Дата теста"].HeaderText = "Дата теста";
                        dataGridView1.Columns["Баллы"].HeaderText = "Баллы";
                        dataGridView1.Columns["Время (сек)"].HeaderText = "Время (сек)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки истории: " + ex.Message);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Начать тест заново?",
              "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                   "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Application.Exit();
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

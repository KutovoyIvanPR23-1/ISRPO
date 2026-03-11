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


namespace TestingApp
{
    public partial class FormQuestions : Form
    {
        private int userId;
        private int currentQuestion = 0;
        private DataTable questionsTable;
        private int correctAnswers = 0;
        private int totalSeconds = 1500;
        private int timeSpent = 0; 
        private DateTime testStartTime;
        private int a = 1;

        public FormQuestions(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.testStartTime = DateTime.Now;
        }

        private void FormQuestions_Load(object sender, EventArgs e)
        {       
            LoadQuestions();
            DisplayQuestion();
            timer1.Interval = 1000; 
            timer1.Start();

            UpdateTimerDisplay();
            label2.Text = "Вопрос 1 из 15";
        }

        private void LoadQuestions()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = "SELECT * FROM Questions ORDER BY Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    questionsTable = new DataTable();
                    adapter.Fill(questionsTable);

                    if (questionsTable.Rows.Count == 0)
                    {
                        MessageBox.Show("В базе данных нет вопросов!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки вопросов: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DisplayQuestion()
        {
            if (questionsTable != null && currentQuestion < questionsTable.Rows.Count)
            {
                DataRow row = questionsTable.Rows[currentQuestion];

                lblQuestion.Text = row["QuestionText"].ToString();

                rbOption1.Text = row["Option1"].ToString();
                rbOption2.Text = row["Option2"].ToString();
                rbOption3.Text = row["Option3"].ToString();
                rbOption4.Text = row["Option4"].ToString();

                rbOption1.Checked = false;
                rbOption2.Checked = false;
                rbOption3.Checked = false;
                rbOption4.Checked = false;
            }
        }

        private void UpdateTimerDisplay()
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            lblTimer.Text = $"{minutes:00}:{seconds:00} мин";

        }

        private void SaveAnswer(int questionId, int selectedOption, bool isCorrect)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = @"INSERT INTO UserAnswers (UserId, QuestionId, SelectedOption, IsCorrect, TestDate) 
                                   VALUES (@uid, @qid, @opt, @correct, @testDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@qid", questionId);
                    cmd.Parameters.AddWithValue("@opt", selectedOption);
                    cmd.Parameters.AddWithValue("@correct", isCorrect);
                    cmd.Parameters.AddWithValue("@testDate", testStartTime);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения ответа: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinishTest()
        {
            SaveTestTime();

            FormFinish formFinish = new FormFinish(
                userId,
                correctAnswers,
                questionsTable.Rows.Count,
                timeSpent
            );
            formFinish.Show();
            this.Hide();
        }

        private void SaveTestTime()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    string query = @"UPDATE UserAnswers 
                                   SET TimeSpent = @timeSpent
                                   WHERE UserId = @userId AND TestDate = @testDate";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@timeSpent", timeSpent);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@testDate", testStartTime);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Ошибка сохранения времени: " + ex.Message);
            }
        }
        private void FormQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop(); 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int selectedOption = -1;
            if (rbOption1.Checked) selectedOption = 1;
            else if (rbOption2.Checked) selectedOption = 2;
            else if (rbOption3.Checked) selectedOption = 3;
            else if (rbOption4.Checked) selectedOption = 4;

            if (selectedOption == -1)
            {
                MessageBox.Show("Выберите вариант ответа!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int correctOption = Convert.ToInt32(questionsTable.Rows[currentQuestion]["CorrectOption"]);
            bool isCorrect = (selectedOption == correctOption);
            if (isCorrect) correctAnswers++;
            a++;
            label2.Text = $"Вопрос {a} из 15";

            SaveAnswer(Convert.ToInt32(questionsTable.Rows[currentQuestion]["Id"]),
                      selectedOption, isCorrect);

            currentQuestion++;
            if (currentQuestion < questionsTable.Rows.Count)
            {
                DisplayQuestion();
            }
            else
            {
                timer1.Stop();
                FinishTest();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                timeSpent++;
                UpdateTimerDisplay();
            }

            if (totalSeconds <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Время вышло! Тест завершается.", "Время истекло",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                FinishTest();
            }
        }
    }
}

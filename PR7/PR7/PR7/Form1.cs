using PR7.Models;
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

namespace PR7
{
    public partial class MainForm : Form
    {
        private DatabaseHelper db;

        public MainForm()
        {
            InitializeComponent();
            db = new DatabaseHelper();
            LoadBooks();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!db.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooks()
        {

            try
            {
                var books = db.GetBooks();
                dataGridViewBooks.DataSource = books;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите книгу для заказа!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedBook = (Book)dataGridViewBooks.SelectedRows[0].DataBoundItem;
            FormOrder orderForm = new FormOrder(selectedBook, db);
            orderForm.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

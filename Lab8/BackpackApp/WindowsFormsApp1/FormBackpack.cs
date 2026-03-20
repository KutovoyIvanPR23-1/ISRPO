using BackpackApp;
using BackpackApp.Debugging;
using BackpackApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormBackpack : Form
    {
        private DatabaseHelper dbHelper;
        private BackpackSolver solver;
        private List<Item> allItems;
        public FormBackpack()
        {
            InitializeComponent();
            listViewItems.FullRowSelect = true;
            listViewItems.GridLines = true;
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            
            if (!int.TryParse(txtMaxWeight.Text, out int maxWeight) || maxWeight <= 0)
            {
                MessageBox.Show("Введите корректный максимальный вес (положительное число)",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Решение приведено в таблице!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

                try
                {
                    DebugLogger.Log($"Запуск решения задачи с максимальным весом: {maxWeight}");

                    var result = solver.Solve(allItems, maxWeight);
                    DisplayItems(result);

                    if (result.Count == 0)
                    {
                        MessageBox.Show("Не удалось подобрать набор предметов", "Результат",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    DebugLogger.Log($"Ошибка при решении задачи: {ex.Message}");
                    MessageBox.Show($"Ошибка при решении задачи: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseTester.TestConnection();

            dbHelper = new DatabaseHelper();
            solver = new BackpackSolver();
            LoadAllItems();
        }

        private void LoadAllItems()
        {
            try
            {
                DebugLogger.Log("Загрузка всех предметов из базы данных");
                allItems = dbHelper.GetAllItems();
                DisplayItems(allItems);
            }
            catch (Exception ex)
            {
                DebugLogger.Log($"Ошибка при загрузке данных: {ex.Message}");
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayItems(List<Item> items)
        {
            listViewItems.Items.Clear();

            foreach (var item in items)
            {
                var listItem = new ListViewItem(item.Name);
                listItem.SubItems.Add(item.Weight.ToString());
                listItem.SubItems.Add(item.Cost.ToString());
                listViewItems.Items.Add(listItem);
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DebugLogger.Log("Показаны исходные данные");
            DisplayItems(allItems);
        }
    }
}

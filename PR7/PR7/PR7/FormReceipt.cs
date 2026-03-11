using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PR7.Models;

namespace PR7
{
    public partial class FormReceipt : Form
    {
        private int orderId;
        private DatabaseHelper db;
        
        private string bookTitle;
        private string customerName;  
        private string officeName;    

        
        public FormReceipt(int id, DatabaseHelper databaseHelper, string bookTitle,
                          string customerName, string officeName)
        {
            InitializeComponent();
            orderId = id;
            db = databaseHelper;
            this.bookTitle = bookTitle;
            this.customerName = customerName;  
            this.officeName = officeName;     
            
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            try
            {
                var order = db.GetOrderDetails(orderId);

                
                string formattedDate = "Не указана";
                if (order != null && DateTime.TryParse(order.DateOfAdmission, out DateTime date))
                {
                    formattedDate = date.ToString("dd.MM.yyyy HH:mm");
                }
                else if (order == null)
                {
                    formattedDate = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                }

                

                
                string bookTitleToShow = bookTitle;
                string customerNameToShow = customerName;  
                string officeNameToShow = officeName;      

                
                if (order != null)
                {
                    if (string.IsNullOrEmpty(bookTitleToShow) && !string.IsNullOrEmpty(order.BookTitle))
                        bookTitleToShow = order.BookTitle;

                    if (string.IsNullOrEmpty(customerNameToShow) && !string.IsNullOrEmpty(order.CustomerName))
                        customerNameToShow = order.CustomerName;

                    if (string.IsNullOrEmpty(officeNameToShow) && !string.IsNullOrEmpty(order.OfficeName))
                        officeNameToShow = order.OfficeName;
                }

                
                if (string.IsNullOrEmpty(bookTitleToShow))
                    bookTitleToShow = "Неизвестная книга";

                if (string.IsNullOrEmpty(customerNameToShow))
                    customerNameToShow = "Клиент не указан";

                if (string.IsNullOrEmpty(officeNameToShow))
                    officeNameToShow = "Офис не выбран";

                
                textBoxReceiptDetails.Text =
                    $"=== ЧЕК ПРЕДЗАКАЗА ===\r\n" +
                    $"Номер заказа: {(order?.Id_Order ?? orderId)}\r\n" +
                    $"Дата оформления: {formattedDate}\r\n" +
                    $"--------------------------------\r\n" +
                    $"Товар: {bookTitleToShow}\r\n" +
                    $"Клиент: {customerNameToShow}\r\n" +
                    $"Офис получения: {officeNameToShow}\r\n" +
                    $"--------------------------------\r\n" +
                    $"Итого к оплате: {$"{order.Price} руб."}\r\n" +
                    $"================================\r\n" +
                    $"Спасибо за предзаказ!\r\n";

              
                if (order == null)
                {
                    MessageBox.Show("Заказ сохранен, но не найден в базе данных для деталей.",
                                  "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Ошибка загрузки деталей: {ex.Message}\nПоказан упрощенный чек.",
                              "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чек отправлен на печать.", "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

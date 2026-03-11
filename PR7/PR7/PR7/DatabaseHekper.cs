using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PR7.Models;



namespace PR7
{
    public class DatabaseHelper : IDisposable
    {
        private readonly string connectionString = @"Data Source=Desktop1488\SQLEXPRESS;Initial Catalog=Publishing;Integrated Security=True;Connect Timeout=30";

        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT p.id_Publication, p.Name, p.Author,
                               a.Surname + ' ' + a.Name as AuthorName,
                               p.ReleaseYear, p.VolumeOfSheets, p.Circulation
                        FROM Publication p
                        LEFT JOIN Authors a ON p.Author = a.id_Author
                        ORDER BY p.Name";
                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book
                            {
                                Id = (int)reader["id_Publication"],
                                Title = reader["Name"].ToString(),
                                AuthorId = reader["Author"] != DBNull.Value ? (int)reader["Author"] : 0,
                                AuthorName = reader["AuthorName"].ToString(),
                                ReleaseYear = (int)reader["ReleaseYear"],
                                Pages = (int)reader["VolumeOfSheets"],
                                Circulation = (int)reader["Circulation"]

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке книг: " + ex.Message);
            }
            return books;
        }

        public List<Office> GetOffices()
        {
            var offices = new List<Office>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id_Office, Office, Address, Phone FROM Offices ORDER BY Office";
                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            offices.Add(new Office
                            {
                                Id = (int)reader["id_Office"],
                                Name = reader["Office"].ToString(),
                                Address = reader["Address"].ToString(),
                                Phone = reader["Phone"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке офисов: " + ex.Message);
            }
            return offices;
        }

        public int CreateOrder(Order order)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                         INSERT INTO Orders (Name, Type, Publication, Office, Customer,
                                            DateOfAdmission, DateOfCompletion, Price)
                        VALUES (@Name, 1, @Publication, @Office, @Customer,
                                @DateOfAdmission, @DateOfCompletion, @Price);
                        SELECT SCOPE_IDENTITY();";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", order.Name);
                        command.Parameters.AddWithValue("@Customer", order.Customer);
                        command.Parameters.AddWithValue("@Type", order.Type);
                        command.Parameters.AddWithValue("@Publication", order.Publication);
                        command.Parameters.AddWithValue("@Office", order.Office);
                        command.Parameters.AddWithValue("@DateOfAdmission", order.DateOfAdmission);
                        command.Parameters.AddWithValue("@DateOfCompletion",
                            string.IsNullOrEmpty(order.DateOfCompletion) ? (object)DBNull.Value : order.DateOfCompletion);
                        command.Parameters.AddWithValue("@Price", order.Price);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании заказа: " + ex.Message);
            }
        }

        public int CreateCustomer(Customer customer)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO Customers (Name, Type, Address, Phone)
                        VALUES (@Name, 1, @Address, @Phone);
                        SELECT SCOPE_IDENTITY();";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", customer.Name);
                        command.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(customer.Address) ? (object)DBNull.Value : customer.Address);
                        command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(customer.Phone) ? (object)DBNull.Value : customer.Phone);
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при создании клиента: " + ex.Message);
            }
        }

        public Order GetOrderDetails(int orderId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            o.Id_Order, 
                            o.Name, 
                            o.Customer,
                            o.Type,
                            o.Publication,
                            o.Office,
                            o.DateOfAdmission,
                            o.DateOfCompletion,
                            o.Price,
                            p.Name as BookTitle,
                            c.Name as CustomerName,
                            ofc.Office as OfficeName
                        FROM Orders o
                        LEFT JOIN Publication p ON o.Publication = p.id_Publication
                        LEFT JOIN Customers c ON o.Customer = c.id_Customer
                        LEFT JOIN Offices ofc ON o.Office = ofc.id_Office
                        WHERE o.Id_Order = @OrderId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderId", orderId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Order
                                {
                                    Id_Order = (int)reader["id_Order"],
                                    Name = reader["Name"].ToString(),
                                    Type = (int)reader["Type"],
                                    Publication = (int)reader["Publication"],
                                    Office = (int)reader["Office"],
                                    Customer = (int)reader["Customer"],
                                    DateOfAdmission = reader["DateOfAdmission"].ToString(),
                                    DateOfCompletion = reader["DateOfCompletion"] != DBNull.Value ?
                                        reader["DateOfCompletion"].ToString() : string.Empty,
                                    Price = reader["Price"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при загрузке деталей заказа: " + ex.Message);
            }
            return null;
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return connection.State == System.Data.ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection test failed: {ex.Message}");
                return false;
            }
        }

        public void Dispose()
        {
            // Здесь можно освободить ресурсы, если потребуется
        }
    }

}

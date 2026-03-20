using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BackpackApp.Debugging;
using BackpackApp.Models;

namespace BackpackApp
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            connectionString = @"Server=DESKTOP1488\SQLEXPRESS;Database=backpack;Trusted_Connection=True;";
        }

        public List<Item> GetAllItems()
        {
            var items = new List<Item>();

            using (var timer = new ExecutionTimer("Получение всех предметов из БД"))
            {
                string query = "SELECT Id, Name, Weight, Cost FROM objects ORDER BY Id";
                DebugLogger.LogSqlQuery(query);

                try
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var command = new SqlCommand(query, connection))
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new Item
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Weight = reader.GetInt32(2),
                                    Cost = reader.GetInt32(3)
                                });
                            }
                        }
                    }

                    DebugLogger.LogItems(items, "Загруженные предметы");
                }
                catch (Exception ex)
                {
                    DebugLogger.Log($"Ошибка при загрузке данных: {ex.Message}");
                    throw;
                }
            }

            return items;
        }
    }
}

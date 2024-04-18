using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VillageRentalsPrototype.Models;

namespace VillageRentalsPrototype.Managers
{
    class DatabaseManager
    {
        private string connectionString;

        // constructor with connection string
        public DatabaseManager()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "sa_prototype",
            };

            this.connectionString = builder.ConnectionString;
        }



        // delete equipment from the table
        public void DeleteEquipment(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "DELETE FROM equipment WHERE id=@Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        // update equipment
        public void UpdateEqeuipment(Equipment eq)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "UPDATE equipment SET " +
                    "category_id=@CategoryId, " +
                    "name=@Name, " +
                    "description=@Description, " +
                    "daily_rate=@DailyRate " +
                    "WHERE id=@Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", eq.CategoryId);
                    command.Parameters.AddWithValue("@Name", eq.Name);
                    command.Parameters.AddWithValue("@Description", eq.Description);
                    command.Parameters.AddWithValue("@DailyRate", eq.DailyRate);
                    command.Parameters.AddWithValue("@Id", eq.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        // add new equipment
        public void AddEquipment(int categoryId, string name, string description, double dailyRate)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO equipment(category_id, name, description, daily_rate) VALUES (@CategoryId, @Name, @Description, @DailyRate)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryId", categoryId);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@DailyRate", dailyRate);

                    command.ExecuteNonQuery();
                }
            }
        }


        // get all equipments from the table
        public List<Equipment> GetAllEquipments()
        {
            List<Equipment> equipments = new List<Equipment>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT e.id, e.name, description, daily_rate, c.name as category_name from equipment e join category c on e.category_id=c.id";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipments.Add(
                                new Equipment(
                                    reader.GetInt32("id"),
                                    reader.GetString("name"),
                                    reader.GetString("description"),
                                    reader.GetDouble("daily_rate"),
                                    reader.GetString("category_name")
                                    ) 
                                );
                        }
                    }
                }
            }

            return equipments;
        }

        // get all categories from the table
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM category";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categories.Add(
                                new Category(
                                    reader.GetInt32("id"),
                                    reader.GetString("name")
                                    )
                                );
                        }
                    }
                }
            }

            return categories;
        }

        // get equipment by id
        public Equipment? GetEquipmentById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT e.id, e.name, description, daily_rate, " +
                    "category_id, c.name as category_name " +
                    "FROM equipment e join category c on e.category_id=c.id " +
                    "WHERE e.id=@Id";
                
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Equipment(
                                reader.GetInt32("id"),
                                reader.GetString("name"),
                                reader.GetString("description"),
                                reader.GetDouble("daily_rate"),
                                reader.GetString("category_name"),
                                reader.GetInt32("category_id")
                            );
                        }
                    }

                    return null;
                }
            }
        }

        // get all customers from the table
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * from customer";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(
                                new Customer(
                                    reader.GetInt32("id"),
                                    reader.GetString("last_name"),
                                    reader.GetString("first_name"),
                                    reader.GetString("phone"),
                                    reader.GetString("email")
                                    )
                                );
                        }
                    }
                }
            }

            return customers;
        }

        // add new customer
        public void AddCustomer(Customer customer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO customer(last_name, first_name, phone, email) VALUES (@LastName, @FirstName, @Phone, @Email)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@Email", customer.Email);

                    command.ExecuteNonQuery();
                }
            }
        }


        // get customer by id
        public Customer? GetCustomerById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM customer WHERE id=@Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Customer(
                                reader.GetInt32("id"),
                                reader.GetString("last_name"),
                                reader.GetString("first_name"),
                                reader.GetString("phone"),
                                reader.GetString("email")
                            );
                        }
                    }

                    return null;
                }
            }
        }

        // update customer
        public void UpdateCustomer(Customer customer)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "UPDATE customer SET " +
                    "first_name=@FirstName, " +
                    "last_name=@LastName, " +
                    "phone=@Phone, " +
                    "email=@Email " +
                    "WHERE id=@Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@LastName", customer.LastName);
                    command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Id", customer.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        // delete equipment from the table
        public void DeleteCustomer(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "DELETE FROM customer WHERE id=@Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}

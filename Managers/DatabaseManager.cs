using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // add course to the table
        //public void AddCourse(Course course)
        //{
        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        var query = "INSERT INTO Courses(CourseId, Name, Credits) VALUES (@CourseId, @Name, @Credits)";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CourseId", course.CourseId);
        //            command.Parameters.AddWithValue("@Name", course.Name);
        //            command.Parameters.AddWithValue("@Credits", course.Credits);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        // delete course from the table
        //public void DeleteCourse(Course course)
        //{
        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        var query = "DELETE FROM Courses WHERE CourseIdd=@CourseId";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CourseId", course.CourseId);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        // update course in the table
        //public void UpdateStudent(Course course)
        //{
        //    using (var connection = new SQLiteConnection(connectionString))
        //    {
        //        connection.Open();

        //        var query = "UPDATE Courses SET CourseId=@CourseId, Name=@Name, Credits=@Credits WHERE id=@Id";

        //        using (var command = new SQLiteCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@CourseId", course.CourseId);
        //            command.Parameters.AddWithValue("@Name", course.Name);
        //            command.Parameters.AddWithValue("@Credits", course.Credits);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}

        // get all courses from the table
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

    }
}

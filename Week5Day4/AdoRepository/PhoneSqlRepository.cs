using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5Day4.Entities;
using Week5Day4.Interfaces;

namespace Week5Day4.AdoRepository
{
    class PhoneSqlRepository : IphoneDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                           "Initial Catalog = NegozioElettronica;" +
                                           "Integrated Security = true;";

        const string _discriminator = "Phone";
        public void Delete(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", phone.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Phone> Fetch()
        {
            List<Phone> phones = new List<Phone>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Type = @type";
                command.Parameters.AddWithValue("@type", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var memory = (int)reader["Memory"];
                    var id = (int)reader["Id"];

                    Phone phone = new Phone(brand, model, quantity, memory, id);
                    phones.Add(phone);
                }
            }
            return phones;
        }

        public List<Phone> FilterByMemory(int m)
        {
            List<Phone> phones = new List<Phone>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Memory >= @memory";
                command.Parameters.AddWithValue("@memory", m);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var memory = (int)reader["Memory"];
                    var id = (int)reader["Id"];

                    Phone phone = new Phone(brand, model, quantity, memory, id);
                    phones.Add(phone);
                }
            }
            return phones;
        }

        public Phone GetById(int? id)
        {
            Phone phone = new Phone();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Id = @id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var memory = (int)reader["Memory"];


                    phone = new Phone(brand, model, quantity, memory, id);
                    
                }
            }
            return phone;
        }

        public void Insert(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                
                command.CommandText = "insert into Product values (@brand, @model, @quantity, @memory, @os, @touch, @inch, @type)";
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@quantity", phone.Quantity);
                command.Parameters.AddWithValue("@memory", phone.Memory);
                command.Parameters.AddWithValue("@os", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inch", DBNull.Value);
                command.Parameters.AddWithValue("@type", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Phone phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Product " +
                                      "set Brand = @brand, Model = @model, Quantity = @quantity, " +
                                      "Memory = @memory, OS = @os, Touchscreen = @touch, Inch = @inch, Type = @type " +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@brand", phone.Brand);
                command.Parameters.AddWithValue("@model", phone.Model);
                command.Parameters.AddWithValue("@quantity", phone.Quantity);
                command.Parameters.AddWithValue("@memory", phone.Memory);
                command.Parameters.AddWithValue("@os", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inch", DBNull.Value);
                command.Parameters.AddWithValue("@type", _discriminator);
                command.Parameters.AddWithValue("@id", phone.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
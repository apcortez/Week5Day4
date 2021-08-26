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
    class PcSqlRepository : IPcDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                              "Initial Catalog = NegozioElettronica;" +
                                              "Integrated Security = true;";

        const string _discriminator = "Pc";
        public void Delete(Pc pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", pc.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Pc> Fetch()
        {
            List<Pc> pcs = new List<Pc>();
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
                    var os = (_OS)reader["OS"];
                    var touchscreen = (bool)reader["Touchscreen"];
                    var id = (int)reader["Id"];

                    Pc pc = new Pc(brand, model, quantity, os, touchscreen, id);
                    pcs.Add(pc);
                }
            }
            return pcs;
        }

        public List<Pc> FilterByOS(_OS ops)
        {
            List<Pc> pcs = new List<Pc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                int sistema = (int)ops;
                command.CommandText = "select * from Product where OS = @os";
                command.Parameters.AddWithValue("@os", sistema);

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var os = (_OS)reader["OS"];
                    var touchscreen = (bool)reader["Touchscreen"];
                    var id = (int)reader["Id"];

                    Pc pc = new Pc(brand, model, quantity, os, touchscreen, id);
                    pcs.Add(pc);
                }
            }
            return pcs;
        }

        public Pc GetById(int? id)
        {
            Pc pc = new Pc();
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
                    var os = (_OS)reader["OS"];
                    var touchscreen = (bool)reader["Touchscreen"];

                    pc = new Pc(brand, model, quantity, os, touchscreen, id);

                }
            }
            return pc;
        }

        public void Insert(Pc pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into Product values (@brand, @model, @quantity, @memory, @os, @touch, @inch, @type)";
                command.Parameters.AddWithValue("@brand", pc.Brand);
                command.Parameters.AddWithValue("@model", pc.Model);
                command.Parameters.AddWithValue("@quantity", pc.Quantity);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@os", pc.OS);
                command.Parameters.AddWithValue("@touch", pc.IsTouchScreen);
                command.Parameters.AddWithValue("@inch", DBNull.Value);
                command.Parameters.AddWithValue("@type", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Pc pc)
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
                command.Parameters.AddWithValue("@brand", pc.Brand);
                command.Parameters.AddWithValue("@model", pc.Model);
                command.Parameters.AddWithValue("@quantity", pc.Quantity);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@os", pc.OS);
                command.Parameters.AddWithValue("@touch", pc.IsTouchScreen);
                command.Parameters.AddWithValue("@inch", DBNull.Value);
                command.Parameters.AddWithValue("@type", _discriminator);
                command.Parameters.AddWithValue("@id", pc.Id);

                command.ExecuteNonQuery();
            }
        }

    }
}
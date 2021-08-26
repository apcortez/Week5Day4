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
    class TvSqlRepository : ITvDbManager
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                             "Initial Catalog = NegozioElettronica;" +
                                             "Integrated Security = true;";

        const string _discriminator = "Tv";
        public void Delete(Tv tv)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Tv> Fetch()
        {
            List<Tv> tvs = new List<Tv>();
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
                    var inch = (int)reader["Inch"];
                    var id = (int)reader["Id"];

                    Tv tv = new Tv(brand, model, quantity, inch, id);
                    tvs.Add(tv);
                }
            }
            return tvs;
        }

        public List<Tv> FilterByInch(int inches)
        {
            List<Tv> tvs = new List<Tv>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Inch >= @inch";
                command.Parameters.AddWithValue("@inch", inches);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var quantity = (int)reader["Quantity"];
                    var inch = (int)reader["Inch"];
                    var id = (int)reader["Id"];

                    Tv tv = new Tv(brand, model, quantity, inch, id);
                    tvs.Add(tv);
                }
            }
            return tvs;
        }

        public Tv GetById(int? id)
        {
            Tv tv = new Tv();
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
                    var inch = (int)reader["Inch"];

                    tv = new Tv(brand, model, quantity, inch, id);

                }
            }
            return tv;
        }

        public void Insert(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into Product values (@brand, @model, @quantity, @memory, @os, @touch, @inch, @type)";
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@quantity", tv.Quantity);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@os", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inch", tv.Inch);
                command.Parameters.AddWithValue("@type", _discriminator);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Tv tv)
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
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@quantity", tv.Quantity);
                command.Parameters.AddWithValue("@memory", DBNull.Value);
                command.Parameters.AddWithValue("@os", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inch", tv.Inch);
                command.Parameters.AddWithValue("@type", _discriminator);
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
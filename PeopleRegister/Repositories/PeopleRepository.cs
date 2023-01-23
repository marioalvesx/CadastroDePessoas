using PeopleRegister.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleRegister.Repositories
{
    public class PeopleRepository : BaseRepository, IPeopleRepository
    {
        public PeopleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<People> GetAll()
        {
            var peopleList = new List<People>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM pessoas ORDER BY Id DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var peopleModel = new People();
                        peopleModel.Id = reader.GetInt32(0);
                        peopleModel.Nome = reader[1].ToString();
                        peopleModel.Telefone = reader[2].ToString();
                        peopleList.Add(peopleModel);
                    }
                }
            }
            return peopleList;
        }

        public void Add(People people)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO pessoas values (@nome, @telefone)";
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = people.Nome;
                command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = people.Telefone;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM pessoas WHERE Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(People people)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE pessoas SET Nome = @nome, Telefone = @telefone WHERE Id = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = people.Id;
                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = people.Nome;
                command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = people.Telefone;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<People> GetByValue(string value)
        {
            var peopleList = new List<People>();
            string peopleName = value;
            string peoplePhone = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from pessoas
                                        where Nome like @nome+'%' or Telefone LIKE @Telefone+'%'
                                        order by Id desc";

                command.Parameters.Add("@nome", SqlDbType.VarChar).Value = peopleName;
                command.Parameters.Add("@telefone", SqlDbType.VarChar).Value = peoplePhone;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var peopleModel = new People();
                        peopleModel.Nome = reader[1].ToString();
                        peopleModel.Telefone = reader[2].ToString();
                        peopleList.Add(peopleModel);
                    }
                }
            }
            return peopleList;
        }
    }
}

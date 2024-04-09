using PlayerClassifier.WPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlayerClassifier.WPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool Add(NetworkCredential credential, string userName, string userEmail, string cargo)
        {
            bool valid;

            using(var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO [UsersPc] (Username, Password, Name, Cargo, Email) VALUES (@username, @password, @name, @userjob, @useremail)";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = userName;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@userjob", System.Data.SqlDbType.NVarChar).Value = cargo;
                command.Parameters.Add("@useremail", System.Data.SqlDbType.NVarChar).Value = userEmail;

                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool AuthenticateUser(NetworkCredential credential) //esse método estabelece uma conexão com o SQL Server e faz uma query. Se bem sucedida, o usuário é válido
        {
            bool validUser;
            int userCount;
            
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select COUNT(*) from [UsersPc] where Username=@username and [Password]=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                userCount = Convert.ToInt32(command.ExecuteScalar());
                if (userCount > 0)
                {
                    validUser = true;
                } else
                {
                    validUser = false;
                }
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserModel GetByUserName(string username)
        {
            UserModel user = null;
            int userCount;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [UsersPc] where Username = @username";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            UserName = reader[1].ToString(),
                            Password = string.Empty,
                            UserEmail = reader[3].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

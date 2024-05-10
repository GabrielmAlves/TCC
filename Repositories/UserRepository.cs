using PlayerClassifier.WPF.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PlayerClassifier.WPF.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool Add(NetworkCredential credential, string userName, string userEmail, string cargo)
        {
            bool userAdded;
                //bool userExist = verifyUser(userName, userEmail);
                //if (userExist == false)
                //{
                    using (var connection = GetConnection())
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "INSERT INTO UsersPc (Username, Password, Name, Cargo, Email) " + "VALUES (@username, @password, @name, @userjob, @useremail)";
                        command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = userName;
                        command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = credential.Password;
                        command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = credential.UserName;
                        command.Parameters.Add("@userjob", System.Data.SqlDbType.NVarChar).Value = cargo;
                        command.Parameters.Add("@useremail", System.Data.SqlDbType.NVarChar).Value = userEmail;
                        command.ExecuteNonQuery();
                        sendEmail(userEmail);
                        userAdded = true;
                    }
                //} else
                //{
                    //Console.WriteLine("ERRO");
                //}
            return userAdded;
        }

        //private bool verifyUser(string userName, string userEmail)
        //{
        //    bool exist;
        //    int quantity = 0;
        //    using (var connection2 = GetConnection())
        //    using (var command2 = new SqlCommand())
        //    {
        //        connection2.Open();         
        //        command2.Connection = connection2;
        //        command2.CommandType= System.Data.CommandType.Text;
        //        command2.CommandText = "select COUNT(*) from [UsersPc] where Username=@username and [Email]=@useremail";
        //        command2.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value =userName;
        //        command2.Parameters.Add("@useremail", System.Data.SqlDbType.NVarChar).Value = userEmail;
        //        SqlDataReader reader = command2.ExecuteReader();
        //        if (reader.HasRows)
        //            quantity = Convert.ToInt32(command2.ExecuteScalar());
        //        if (quantity > 0)
        //        {
        //            while (reader.Read())
        //            {
        //                Guid userId = reader.GetGuid(0);
        //                string user = reader.GetString(1);
        //                string email = reader.GetString(2);
        //                Console.WriteLine($"UserID: {userId}, UserName: {user}, Email: {email}");
        //            }
        //            exist = true;
        //        }
        //        else
        //        {
        //            exist = false;;
        //        }
        //    }
        //    return exist;
        //}

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

        public UserModel GetProfilePicture(string user)
        {
            UserModel userInfo = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT ProfilePicture FROM UsersPc WHERE Username = @username";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = user;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userInfo = new UserModel()
                        {
                            ProfilePicture = null  // Inicializar ProfilePicture como null por padrão
                        };

                        // Verificar se ProfilePicture não é DBNull antes de atribuir
                        if (!(reader["ProfilePicture"] is DBNull))
                        {
                            long byteLength = reader.GetBytes(reader.GetOrdinal("ProfilePicture"), 0, null, 0, 0); // Obter o comprimento do array de bytes
                            byte[] profilePictureBytes = new byte[byteLength];
                            reader.GetBytes(reader.GetOrdinal("ProfilePicture"), 0, profilePictureBytes, 0, (int)byteLength); // Ler o ProfilePicture como byte[]
                            userInfo.ProfilePicture = profilePictureBytes; // Atribuir o ProfilePicture como byte[]
                        }
                    }
                }
            }

            return userInfo;
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
                            UserJob = reader[4].ToString(),
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

        public bool AddProfilePicture(byte[] profileImage, UserAccountModel user, string userInfo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                string sql = "UPDATE UsersPc SET ProfilePicture = @ProfilePicture WHERE Username = @userinfo";
                command.CommandText = sql;
                command.Parameters.Add("@userinfo", System.Data.SqlDbType.NVarChar).Value = userInfo;
                command.Parameters.AddWithValue("@ProfilePicture", profileImage);
                command.Parameters.AddWithValue("@Username", user.profilePicture); // Utilizar o Username do usuário
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void sendEmail(string userEmail)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Player Classifier", "engcomp.gabriel@gmail.com"));
            message.To.Add(MailboxAddress.Parse(userEmail));
            message.Subject = "Bem-vindo!";
            message.Body = new TextPart("plain")
            {
                Text = @"Você se cadastrou no sistema do Player Classifier!"
            };

            string email = "engcomp.gabriel@gmail.com";
            string senha = "iuqb qpfo zpzi hqzm";

            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(email, senha);
                smtpClient.Send(message);
                Console.WriteLine("E-mail enviado.");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }

        public bool ClassifyPlayer(string path)
        {
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            scope.SetVariable("", path);
            engine.ExecuteFile(path, scope);
            return true;
        }
    }
}

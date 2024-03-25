using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PlayerClassifier.WPF.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;

        public RepositoryBase ()
        {
            _connectionString = "Server=localhost;Database=master;Trusted_Connection=True;"; //string de conexão com o SQL Server
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection (_connectionString);
        }
    }
}

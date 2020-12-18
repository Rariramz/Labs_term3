using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessLayer
    {
        SqlConnection connection;
        public DataAccessLayer(Options.ConnectionOptions options)
        {
            string connectionStr = $"Data Source={options.DataSource}; Database={options.DataBase}; User={options.User}; Password={options.Password}";
            using(TransactionScope scope = new TransactionScope())
            {
                connection = new SqlConnection(connectionStr);
                connection.Open();
                scope.Complete();
            }
        }

        public T GetInstance<T>(int id) where T : new()
        {
            T obj = new T();
            using(TransactionScope scope = new TransactionScope())
            {
                SqlCommand sqlCommand = new SqlCommand($"Get{typeof(T).Name}", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add(new SqlParameter("id", id));
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if(reader.Read())
                {
                    obj = Read<T>(reader);
                }
                
                reader.Close();
                scope.Complete();
            }
            return obj;
        }

        public List<T> GetAllInstances<T>() where T : new()
        {
            List<T> list = new List<T>();
            using(TransactionScope scope = new TransactionScope())
            {
                SqlCommand sqlCommand = new SqlCommand($"Get{typeof(T).Name}s", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    list.Add(Read<T>(reader));
                }
                reader.Close();
                scope.Complete();
            }
            return list;
        }

        T Read<T>(SqlDataReader reader) where T : new()
        {
            T obj = new T();
            for(int i = 0; i < reader.FieldCount; i++)
            {
                string name = reader.GetName(i);
                object value = reader.GetValue(i); ;
                if(typeof(T).GetProperty(name) != null && value.GetType() != typeof(DBNull))
                {
                    typeof(T).GetProperty(name).SetValue(obj, value);
                }
            }
            return obj;
        }

        public void Log(DateTime date, string fileEvent, string filePath)
        {
            using(TransactionScope scope = new TransactionScope())
            {
                SqlCommand sqlCommand = new SqlCommand("Log", connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("date", date));
                sqlCommand.Parameters.Add(new SqlParameter("fileEvent", fileEvent));
                sqlCommand.Parameters.Add(new SqlParameter("filePath", filePath));

                sqlCommand.ExecuteNonQuery();
                scope.Complete();
            }
        }
    }
}

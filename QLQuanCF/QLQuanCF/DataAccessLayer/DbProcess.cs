using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace QLQuanCF.DataAccessLayer
{
    public class DbProcess
    {
        private readonly string _connectionString;

        public DbProcess(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        // Mở kết nối tới cơ sở dữ liệu
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Thực thi một stored procedure không trả về dữ liệu (ví dụ: thêm, cập nhật, xóa)
        public void ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Log exception or handle accordingly
                        throw new Exception("An error occurred while executing the command.", ex);
                    }
                }
            }
        }

        //Thực thi một stored procedure và trả về một DataTable
        public DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    try
                    {
                        adapter.Fill(dataTable);
                    }
                    catch (SqlException ex)
                    {
                        // Log exception or handle accordingly
                        throw new Exception("An error occurred while executing the query.", ex);
                    }

                    return dataTable;
                }
            }
        }

        // Thực thi một stored procedure và trả về giá trị đầu ra
        public object ExecuteScalar(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    try
                    {
                        return command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        // Log exception or handle accordingly
                        throw new Exception("An error occurred while executing the scalar command.", ex);
                    }
                }
            }
        }

        // Asynchronous method example
        public async Task<DataTable> ExecuteQueryAsync(string storedProcedure, SqlParameter[] parameters)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    await connection.OpenAsync(); // Mở kết nối một cách bất đồng bộ
                    await Task.Run(() => adapter.Fill(dataTable)); // Thực hiện việc điền dữ liệu
                    return dataTable;
                }
            }
        }

	}
}

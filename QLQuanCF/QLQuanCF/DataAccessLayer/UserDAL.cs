using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQuanCF.Models;

namespace QLQuanCF.DataAccessLayer
{
    public class UserDAL
    {
        private readonly DbProcess _dbProcess;

        public UserDAL(string connectionString)
        {
            _dbProcess = new DbProcess(connectionString);
        }

        // Lấy tất cả người dùng
        public List<User> GetAllUsers()
        {
            DataTable dataTable = _dbProcess.ExecuteQuery("GetAllUsers", null);
            List<User> users = new List<User>();

            foreach (DataRow row in dataTable.Rows)
            {
                User user = new User
                {
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString(),
                    MaNV = row["MaNV"].ToString()
                };

                users.Add(user);
            }

            return users;
        }

        // Kiểm tra đăng nhập
        public bool CheckLogin(string username, string password)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            int result = (int)_dbProcess.ExecuteScalar("CheckLogin", parameters);
            return result > 0;
        }

        // Thêm người dùng mới
        public void AddUser(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@MaNV", user.MaNV)
            };

            _dbProcess.ExecuteNonQuery("AddUser", parameters);
        }

        // Cập nhật thông tin người dùng
        public void UpdateUser(User user)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@MaNV", user.MaNV)
            };

            _dbProcess.ExecuteNonQuery("UpdateUser", parameters);
        }

        // Xóa người dùng
        public void DeleteUser(string username)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username)
            };

            _dbProcess.ExecuteNonQuery("DeleteUser", parameters);
        }

        // Lấy vai trò của người dùng theo tên
        public string GetUserRole(string username)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username)
            };

            return (string)_dbProcess.ExecuteScalar("GetUserRole", parameters);
        }

        // Lấy người dùng theo tên đăng nhập
        public User GetUserByUsername(string username)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@Username", username)
            };

            DataTable dataTable = _dbProcess.ExecuteQuery("GetUserByUsername", parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new User
                {
                    Username = row["Username"].ToString(),
                    Password = row["Password"].ToString(),
                    Role = row["Role"].ToString(),
                    MaNV = row["MaNV"].ToString()              
                };
            }

            return null; // Nếu không tìm thấy người dùng
        }
    }
}

using QLQuanCF.DataAccessLayer;
using QLQuanCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanCF.BusinessLogicLayer
{
    public class UserBLL
    {
        private readonly UserDAL _userDAL;

        public UserBLL(string connectionString)
        {
            _userDAL = new UserDAL(connectionString);
        }

        // Hàm kiểm tra đăng nhập
        public bool CheckLogin(string username, string password)
        {
            // Kiểm tra người dùng có tồn tại và mật khẩu có đúng không
            User user = _userDAL.GetUserByUsername(username);
            if (user != null && user.Password == password)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfUsernameExists(string username)
        {
            // Query the database to check if the username already exists
            var existingUser = _userDAL.GetUserByUsername(username);
            return existingUser != null;
        }

        // Hàm lấy thông tin người dùng theo tên đăng nhập
        public User GetUserByUsername(string username)
        {
            return _userDAL.GetUserByUsername(username);
        }

        public List<User> GetAllUserByUsername(string username)
        {
            return _userDAL.GetAllUserByUsername(username);
        }

        // Hàm kiểm tra quyền của người dùng (ví dụ: Admin hoặc Staff)
        public bool CheckUserRole(string username, string role)
        {
            User user = _userDAL.GetUserByUsername(username);
            if (user != null && user.Role == role)
            {
                return true;
            }
            return false;
        }

        // Hàm thêm người dùng mới
        public void AddUser(User user)
        {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                _userDAL.AddUser(user);
            }
            else
            {
                throw new ArgumentException("Tên người dùng và mật khẩu không được để trống.");
            }
        }

        // Hàm cập nhật thông tin người dùng
        public void UpdateUser(User user)
        {
            if (!string.IsNullOrEmpty(user.Username))
            {
                _userDAL.UpdateUser(user);
            }
            else
            {
                throw new ArgumentException("Tên người dùng không được để trống.");
            }
        }

        // Hàm xóa người dùng
        public void DeleteUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                _userDAL.DeleteUser(username);
            }
            else
            {
                throw new ArgumentException("Tên người dùng không được để trống.");
            }
        }

        // Hàm lấy tất cả người dùng
        public List<User> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }
    }
}

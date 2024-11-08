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

        // Hàm lấy thông tin người dùng theo tên đăng nhập
        public User GetUser(string username)
        {
            return _userDAL.GetUserByUsername(username);
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
    }
}

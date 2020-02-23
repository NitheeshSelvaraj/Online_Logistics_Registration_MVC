using Online_Logistics_Registration_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Logistics_Registration_Repository
{
    public class UserRepository
    {
        static List<User> userList = new List<User>();
        static UserRepository()
        {
            userList.Add(new User { name = "Nitheesh", mobileNumber = "9807654321", userName = "nithi02", password = "nithi@02" });
            userList.Add(new User { name = "Ram", mobileNumber = "9807654322", userName = "ram02", password = "ram@02" });
        }
        
        public void Add(User user)
        {
            userList.Add(user);
        }
        public string Check(string userName,string password)
        {
            string flag;
            foreach (User user in userList)
            {
                if (userName.Equals(user.userName) && password.Equals(user.password))
                {
                    if (user.userName.Equals("nithi02"))
                    {
                        flag = "admin";
                        return flag;
                    }
                    else
                    {
                        flag = "user";
                        return flag;
                    }
                }
            }
            flag = "noUser";
            return flag;
            
        }
    }
}

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
        //static List<User> userList = new List<User>();
        //static UserRepository()
        //{
        //    userList.Add(new User { Id = 1000, Name = "Nitheesh", MobileNumber = "9807654321", UserName = "nithi02", Password = "nithi@02", Role = "Admin" });
        //    //userList.Add(new User { name = "Ram", mobileNumber = "9807654322", userName = "ram02", password = "ram@02" });
        //}
        //UserContext userContext = new UserContext();

        public IEnumerable<User> GetDetails()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserDetails.ToList();
            }
        }

        public bool Add(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                //UserContext userContext = new UserContext();
                userContext.UserDetails.Add(user);
                //userContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_Logistics].[dbo].[Users] ON");
                userContext.SaveChanges();
                return true;
            }
            //userContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [Online_Logistics].[dbo].[Users] OFF");
        }
        public string Check(User userEntity)
        {
            using (UserContext userContext = new UserContext())
            {
                IEnumerable<User> userList = userContext.UserDetails.ToList();
                string flag;
                foreach (User user in userList)
                {
                    if (userEntity.UserName.Equals(user.UserName) && userEntity.Password.Equals(user.Password))
                    {
                        if (user.Role.Equals("Admin"))
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
}

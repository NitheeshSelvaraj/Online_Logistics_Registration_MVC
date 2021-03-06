﻿using Online_Logistics_Registration_Entity;
using Online_Logistics_Registration_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Logistics_Registration_BL
{
    public interface IUserPath
    {
        bool Register(User user);
        User Check(User userEntity);
        IEnumerable<User> GetDB();
    }
    public class UserPath : IUserPath
    {
        UserRepository userRepository = new UserRepository();
        public IEnumerable<User> GetDB()
        {
            return userRepository.GetDetails();
        }
        public bool Register(User user)
        {           
           return userRepository.Add(user);
        }
        public User Check(User userEntity)
        {
            return userRepository.Check(userEntity);
        }
    }
}

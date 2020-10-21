using Online_Logistics_Registration_BL;
using Online_Logistics_Registration_Entity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Online_Logistics_Registration.Controllers
{
    public class Online_Logistics_Registration_UserController : Controller
    {
        // GET: Online_Logistics_Registration
        IUserPath userPath;
        public Online_Logistics_Registration_UserController()
        {
            userPath = new UserPath();
        }
        
        //User userEntity = new User();
        public ActionResult Index()
        {
            //IEnumerable<User> userList = userPath.GetDB();
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {           
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register( Online_Logistics_Registration.Models.UserModel user)
        {
            
            if (ModelState.IsValid)
            {
                var userObject = AutoMapper.Mapper.Map<Models.UserModel, Online_Logistics_Registration_Entity.User>(user);
                //userEntity.Name = user.Name;
                //userEntity.MobileNumber =user.MobileNumber;
                //userEntity.Email =user.Email;
                //userEntity.UserName =user.UserName;
                //userEntity.Password =user.Password;
                bool result=userPath.Register(userObject);
               // userRepository.Add(user);
                if(result)
                //Response.Write("Registered");
                return RedirectToAction("Login");
            }
            return View();

        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(Online_Logistics_Registration.Models.LoginModel userLogin)
        {
            if (ModelState.IsValid)
            {
                User user = AutoMapper.Mapper.Map<Models.LoginModel, Online_Logistics_Registration_Entity.User>(userLogin);//Automapping the Login Model and User Entity
                User checkUser = userPath.Check(user);//CheckUser is "Admin" Or "User"
                FormsAuthentication.SetAuthCookie(checkUser.UserName, false);
                var authTicket = new FormsAuthenticationTicket(1, checkUser.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), false, checkUser.Role);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket));
                if (checkUser != null)
                {
                    if (checkUser.Role == "Admin")//"True" if the  logined user is "Admin"                
                        return RedirectToAction("Home", "Logistics_Home");
                    else if (checkUser.Role == "User")//"True" if the Logined user is "User"           
                        return RedirectToAction("VehicleSuggestion", "Online_Logistics_Registration_Vehicle");
                }
                else
                {
                    Response.Write("User name or password not found");
                }
                //userEntity.UserName = userLogin.UserName;
                //userEntity.Password = userLogin.Password;

            //    var userObject = AutoMapper.Mapper.Map<Models.LoginModel, Online_Logistics_Registration_Entity.User>(userLogin);
            //    userEntity = userPath.Check(userObject);
            //    if (userEntity != null)
            //    {
            //        if (userEntity.Role == "Admin")
            //        {
            //            return RedirectToAction("Vehicle", "Online_Logistics_Registration_Vehicle");
            //        }
            //        else if (userEntity.Role == "User")
            //        {
            //            Response.Write("LoggedIn as User");
            //        }
            //    }
            //    else
            //    {
            //        Response.Write("User name or password not found");
            //    }
            }
            return View();
        }
      
        public RedirectToRouteResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Online_Logistics_Registration_User");
        }
        
    }
}


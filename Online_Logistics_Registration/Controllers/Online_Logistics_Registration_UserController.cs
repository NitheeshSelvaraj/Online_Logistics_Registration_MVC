using Online_Logistics_Registration_BL;
using Online_Logistics_Registration_Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Online_Logistics_Registration.Controllers
{
    public class Online_Logistics_Registration_UserController : Controller
    {
        // GET: Online_Logistics_Registration
        UserPath userPath = new UserPath();
        User userEntity = new User();
        public ActionResult Index()
        {
            IEnumerable<User> userList = userPath.GetDB();
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Register( Online_Logistics_Registration.Models.User user)
        {
            
            if (ModelState.IsValid)
            {
                userEntity.Name = user.Name;
                userEntity.MobileNumber =user.MobileNumber;
                userEntity.Email =user.Email;
                userEntity.UserName =user.UserName;
                userEntity.Password =user.Password;
                bool result=userPath.Register(userEntity);
                //userRepository.Add(user);
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
        public ActionResult Login(Online_Logistics_Registration.Models.Login userLogin)
        {
            if (ModelState.IsValid)
            {
                userEntity.UserName = userLogin.UserName;
                userEntity.Password = userLogin.Password;
                string result = userPath.Check(userEntity);
                if (result=="admin")
                {
                    return RedirectToAction("Vehicle","Online_Logistics_Registration_Vehicle");
                }
                else if(result=="user")
                {
                    Response.Write("LoggedIn as User");
                }
                else
                {
                    Response.Write("User name or password not found");
                }
            }
            return View();
        }
        
    }
}


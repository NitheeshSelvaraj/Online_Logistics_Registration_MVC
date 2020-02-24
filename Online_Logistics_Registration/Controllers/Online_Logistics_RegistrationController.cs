using Online_Logistics_Registration_Entity;
using Online_Logistics_Registration_Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Online_Logistics_Registration.Controllers
{
    public class Online_Logistics_RegistrationController : Controller
    {
        // GET: Online_Logistics_Registration
        UserRepository userRepository = new UserRepository();
        VehicleRepository vehicleRepository = new VehicleRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Add(user);
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
        //[ActionName("Login")]
        public ActionResult Login([Bind(Include = "userName,password")]User user)
        {
            if (!ModelState.IsValid)
            {
                string result = userRepository.Check(user.userName,user.password);
                if (result=="admin")
                {
                    return RedirectToAction("ViewVehicle");
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
        public ActionResult ViewVehicle()
        {
            IEnumerable<Vehicle> vehicleDetails = VehicleRepository.Display();
            TempData["Details"] = vehicleDetails;
            return View();
        }
        [HttpGet]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_post(Vehicle vehicle)
        {
            
            if(ModelState.IsValid)
            {
                vehicleRepository.Add(vehicle);
                TempData["Details"] = "Vehicle Added";
                return RedirectToAction("ViewVehicle");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Vehicle vehicle = vehicleRepository.GetVehicleById(id);
            return View(vehicle);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            vehicleRepository.Delete(id);
            TempData["Details"] = "Vehicle Details Removed";
            return RedirectToAction("ViewVehicle");
        }
        [HttpPost]
        public ActionResult Update(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicleRepository.Update(vehicle);
                TempData["Details"] = "Vehicle Details Updated";
                return RedirectToAction("ViewVehicle");
            }
            return View("Edit",vehicle);
        }
    }
}


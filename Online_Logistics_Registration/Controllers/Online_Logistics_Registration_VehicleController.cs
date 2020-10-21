
using System.Collections.Generic;
using System.Web.Mvc;
using Online_Logistics_Registration_BL;
using Online_Logistics_Registration_Entity;

namespace Online_Logistics_Registration.Controllers
{
    
    public class Online_Logistics_Registration_VehicleController : Controller
    {
        //GET: Online_Logistics_Registration_Vehicle
        IVehiclePath vehiclePath;
        public Online_Logistics_Registration_VehicleController()
        {
            vehiclePath = new VehiclePath();
        }
        //Vehicle vehicleEntity = new Vehicle();
        //public ActionResult Vehicle()
        //{
        //    return View();
        //}
        [Authorize (Roles ="Admin")]
        public ActionResult ViewVehicle()
        {
            IEnumerable<Vehicle> vehicleDetails = vehiclePath.GetDB();
            TempData["Details"] = vehicleDetails;
            return View();
        }

        [HttpGet]
        [ActionName("AddVehicle")]
        [Authorize(Roles = "Admin")]
        public ActionResult AddVehicle_get()
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");
            return View();
        }
        [HttpPost]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_post(Online_Logistics_Registration.Models.VehicleModel vehicle)
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");

            if (ModelState.IsValid)
            {
                Vehicle vehicleObject = AutoMapper.Mapper.Map<Models.VehicleModel, Online_Logistics_Registration_Entity.Vehicle>(vehicle);
                ////vehicleEntity.VehicleID = vehicle.VehicleID;
                //vehicleEntity.VehicleNumber = vehicle.VehicleNumber;
                //vehicleEntity.VehicleTypeID = vehicle.VehicleTypeID;
                //vehicleEntity.StartLocation = vehicle.StartLocation;
                //vehicleEntity.DestinationLocation = vehicle.DestinationLocation;
                //vehicleEntity.VehicleLoadWeight = vehicle.VehicleLoadWeight;
                int result = vehiclePath.Add(vehicleObject);
                if(result==1)
                return RedirectToAction("ViewVehicle");
            }
            return View();
        }
        [HttpGet]
        [ActionName("EditVehicle")]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");
            Models.VehicleModel vehicle = new Models.VehicleModel(); 
            Vehicle vehicleEntity = vehiclePath.GetVehicleById(id);
            var vehicleObject = AutoMapper.Mapper.Map<Online_Logistics_Registration_Entity.Vehicle, Models.VehicleModel>(vehicleEntity);
            //vehicle.VehicleID = vehicleEntity.VehicleID;
            //vehicle.VehicleNumber = vehicleEntity.VehicleNumber;
            //vehicle.VehicleTypeID = vehicleEntity.VehicleTypeID;
            //vehicle.StartLocation = vehicleEntity.StartLocation;
            //vehicle.DestinationLocation = vehicleEntity.DestinationLocation;
            //vehicle.VehicleLoadWeight = vehicleEntity.VehicleLoadWeight;
            return View(vehicleObject);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            int result = vehiclePath.Delete(id);
            if (result == 1)
            {
                return RedirectToAction("ViewVehicle");
            }
            return View();
        }
       
        public ActionResult Update(Models.VehicleModel vehicle)
        {
            if (ModelState.IsValid)
            {
                var vehicleObject = AutoMapper.Mapper.Map<Models.VehicleModel, Online_Logistics_Registration_Entity.Vehicle>(vehicle);
                //vehicleEntity.VehicleID = vehicle.VehicleID;
                //vehicleEntity.VehicleNumber = vehicle.VehicleNumber;
                //vehicleEntity.VehicleTypeID = vehicle.VehicleTypeID;
                //vehicleEntity.StartLocation = vehicle.StartLocation;
                //vehicleEntity.DestinationLocation = vehicle.DestinationLocation;
                //vehicleEntity.VehicleLoadWeight = vehicle.VehicleLoadWeight;
                int result=vehiclePath.Update(vehicleObject);
                if (result==1)
                   return RedirectToAction("ViewVehicle");
            }
            return View("EditVehicle", vehicle);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UserDetail()
        {
            UserPath userPath = new UserPath();
            IEnumerable<User> userDetails = userPath.GetDB();
            //foreach(User user in userDetails)
            //{
            //    if(user.Role!="Admin")
            //    {
            //        TempData["userDetails"] = user;
            //    }
            //}
            TempData["UserDetails"] = userDetails;
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            vehiclePath.DeleteUser(id);
            return RedirectToAction("UserDetail");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult VehicleType()
        {
            IEnumerable<VehicleType> vehicleTypeDetails = vehiclePath.GetTypeDetails();
            TempData["TypeDetails"] = vehicleTypeDetails;
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddVehicleType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicleType(Models.VehicleTypeModel vehicleType)
        {
            if (ModelState.IsValid)
            {
                VehicleType vehicleTypeEntity = new VehicleType();
                vehicleTypeEntity.VehicleTypes = vehicleType.VehicleTypes;
                int result = vehiclePath.AddType(vehicleTypeEntity);
                if (result == 1)
                    return RedirectToAction("VehicleType");
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteVehicleType(int id)
        {
            int result = vehiclePath.DeleteVehicleType(id);
            if (result == 1)
            {
                return RedirectToAction("VehicleType");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login","Online_Logistics_Registration_User");
        }
        public ActionResult VehicleSuggestion()
        {
            IEnumerable<Vehicle> vehicleDetails = vehiclePath.GetDB();
            TempData["Suggestion"] = vehicleDetails;
            return View();
        }
    }
}
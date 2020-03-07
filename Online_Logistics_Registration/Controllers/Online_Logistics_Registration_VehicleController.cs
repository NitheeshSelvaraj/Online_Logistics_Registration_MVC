
using System.Collections.Generic;
using System.Web.Mvc;
using Online_Logistics_Registration_BL;
using Online_Logistics_Registration_Entity;

namespace Online_Logistics_Registration.Controllers
{
    public class Online_Logistics_Registration_VehicleController : Controller
    {
        //GET: Online_Logistics_Registration_Vehicle
        VehiclePath vehiclePath = new VehiclePath();
        Vehicle vehicleEntity = new Vehicle();
        public ActionResult Vehicle()
        {
            return View();
        }
        public ActionResult ViewVehicle()
        {
            IEnumerable<Vehicle> vehicleDetails = vehiclePath.GetDB();
            TempData["Details"] = vehicleDetails;
            return View();
        }

        [HttpGet]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_get()
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");
            return View();
        }
        [HttpPost]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_post(Online_Logistics_Registration.Models.Vehicle vehicle)
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");

            if (ModelState.IsValid)
            {
                //vehicleEntity.VehicleID = vehicle.VehicleID;
                vehicleEntity.VehicleNumber = vehicle.VehicleNumber;
                vehicleEntity.VehicleTypeID = vehicle.VehicleTypeID;
                vehicleEntity.StartLocation = vehicle.StartLocation;
                vehicleEntity.DestinationLocation = vehicle.DestinationLocation;
                vehicleEntity.VehicleLoadWeight = vehicle.VehicleLoadWeight;
                int result = vehiclePath.Add(vehicleEntity);
                if(result==1)
                return RedirectToAction("ViewVehicle");
            }
            return View();
        }
        [HttpGet]
        [ActionName("EditVehicle")]
        public ActionResult Edit(int id)
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");
            Models.Vehicle vehicle = new Models.Vehicle();
            vehicleEntity = vehiclePath.GetVehicleById(id);
            vehicle.VehicleID = vehicleEntity.VehicleID;
            vehicle.VehicleNumber = vehicleEntity.VehicleNumber;
            vehicle.VehicleTypeID = vehicleEntity.VehicleTypeID;
            vehicle.StartLocation = vehicleEntity.StartLocation;
            vehicle.DestinationLocation = vehicleEntity.DestinationLocation;
            vehicle.VehicleLoadWeight = vehicleEntity.VehicleLoadWeight;
            return View(vehicle);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            vehiclePath.Delete(id);
            return RedirectToAction("ViewVehicle");
        }
       
        public ActionResult Update(Models.Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicleEntity.VehicleID = vehicle.VehicleID;
                vehicleEntity.VehicleNumber = vehicle.VehicleNumber;
                vehicleEntity.VehicleTypeID = vehicle.VehicleTypeID;
                vehicleEntity.StartLocation = vehicle.StartLocation;
                vehicleEntity.DestinationLocation = vehicle.DestinationLocation;
                vehicleEntity.VehicleLoadWeight = vehicle.VehicleLoadWeight;
                int result=vehiclePath.Update(vehicleEntity);
                if (result==1)
                   return RedirectToAction("ViewVehicle");
            }
            return View("EditVehicle", vehicle);
        }
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
        public ActionResult DeleteUser(int id)
        {
            vehiclePath.DeleteUser(id);
            return RedirectToAction("UserDetail");
        }
        public ActionResult VehicleType()
        {
            IEnumerable<VehicleType> vehicleTypeDetails = vehiclePath.GetTypeDetails();
            TempData["TypeDetails"] = vehicleTypeDetails;
            return View();
        }
        [HttpGet]
        public ActionResult AddVehicleType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicleType(Models.VehicleType vehicleType)
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
        public ActionResult DeleteVehicleType(int id)
        {
            vehiclePath.DeleteVehicleType(id);
            return RedirectToAction("VehicleType");
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Login","Online_Logistics_Registration_User");
        }
    }
}
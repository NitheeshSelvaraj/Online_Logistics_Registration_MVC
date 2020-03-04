
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
            return View();
        }
        [HttpPost]
        [ActionName("AddVehicle")]
        public ActionResult AddVehicle_post(Online_Logistics_Registration.Models.Vehicle vehicle)
        {

            if (ModelState.IsValid)
            {
                //vehicleEntity.VehicleID = vehicle.VehicleID;
                vehicleEntity.VehicleNumber = vehicle.VehicleNumber;
                vehicleEntity.VehicleType = vehicle.VehicleType;
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
            Models.Vehicle vehicle = new Models.Vehicle();
            vehicleEntity = vehiclePath.GetVehicleById(id);
            vehicle.VehicleID = vehicleEntity.VehicleID;
            vehicle.VehicleNumber = vehicleEntity.VehicleNumber;
            vehicle.VehicleType = vehicleEntity.VehicleType;
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
                vehicleEntity.VehicleType = vehicle.VehicleType;
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
            TempData["UserDetails"] = userDetails;
            return View();
        }
        public ActionResult DeleteUser(int id)
        {
            vehiclePath.DeleteUser(id);
            return RedirectToAction("UserDetail");
        }
    }
}
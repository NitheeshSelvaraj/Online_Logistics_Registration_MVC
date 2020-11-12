
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using Online_Logistics_Registration.Models;
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
        public ActionResult UserSearch()
        {
            ViewBag.startLocation = new SelectList(vehiclePath.GetStartLocation());
            ViewBag.destinationLocation = new SelectList(vehiclePath.GetDestinationLocation());
            return View();
        }
        [HttpPost]
        public ActionResult UserSearch(VehicleModel vehicleModel)
        {
            ViewBag.startLocation = new SelectList(vehiclePath.GetStartLocation());
            ViewBag.destinationLocation = new SelectList(vehiclePath.GetDestinationLocation());
            List<Vehicle> vehicle = vehiclePath.SearchByLocation(vehicleModel.StartLocation, vehicleModel.DestinationLocation);
            if(vehicle.Count!=0)
            {
                TempData["Suggestion"] = vehicle;
                return RedirectToAction("SearchDisplay");
            }
            else
            {
                ViewBag.Message = "No Vehicle for this Location";
                return View();
            }
        }
        public ActionResult SearchDisplay()
        {
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
        public ActionResult AddVehicle_post(Online_Logistics_Registration.Models.VehicleModel vehicle,HttpPostedFileBase fileBase)
        {
            ViewBag.Vehicle = new SelectList(vehiclePath.GetVehicle(), "VehicleTypeID", "VehicleTypes");
            if(fileBase!=null && fileBase.ContentLength>0)
            {
                var fileName = Path.GetFileName(fileBase.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
                fileBase.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                ///VehicleModel vehicleModel = new VehicleModel();
                vehicle.Image = new byte[fileBase.ContentLength];
                fileBase.InputStream.Read(vehicle.Image, 0, fileBase.ContentLength);
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
        [Authorize(Roles = "User")]
        public ActionResult VehicleSuggestion()
        {
            IEnumerable<Vehicle> vehicleDetails = vehiclePath.GetDB();
            TempData["Suggestion"] = vehicleDetails;
            return View();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Online_Logistics_Registration_Entity;
using System.Data.Entity;
using System.Data.SqlClient;
using System;

namespace Online_Logistics_Registration_Repository
{
    public class VehicleRepository
    {
        //static List<Vehicle> vehicleList = new List<Vehicle>();
        //static VehicleRepository()
        //{
        //    vehicleList.Add(new Vehicle { vehicleID = 12345, vehicleNumber = "TN02BA3456", vehicleType = "3-axels rigid", startLocation = "Erode", destinationLocation = "Chennai", vehicleLoadWeight = 26 });
        //    vehicleList.Add(new Vehicle { vehicleID = 12333, vehicleNumber = "TN02BA3444", vehicleType = "4-axels rigid", startLocation = "Chennai", destinationLocation = "Salem", vehicleLoadWeight = 35 });
        //}
        public IEnumerable<Vehicle> GetDetails()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.VehicleDetails.Include("VehicleType").ToList();
            }
        }
        public IEnumerable<VehicleType> GetTypeDetails()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.VehicleTypeDetails.ToList();
            }
        }
        //public static IEnumerable<Vehicle> Display()
        //{
        //    return vehicleList;
        //}
        public IEnumerable<string> GetStartLocation()
        {
            using(UserContext userContext=new UserContext())
            {
                return (from vehicle in userContext.VehicleDetails select vehicle.StartLocation).Distinct().ToList();
            }
        }

        public IEnumerable<string> GetDestinationLocation()
        {
            using (UserContext userContext = new UserContext())
            {
                return (from vehicle in userContext.VehicleDetails select vehicle.DestinationLocation).Distinct().ToList();
            }
        }
        public List<Vehicle> SearchByLocation(string startLocation,string destinationLocation)
        {
            using(UserContext userContext=new UserContext())
            {
                return (from vehicle in userContext.VehicleDetails where vehicle.StartLocation == startLocation && vehicle.DestinationLocation == destinationLocation select vehicle).Include("VehicleType").ToList();
            }
        }

        public int Add(Vehicle vehicle)
        {
           using (UserContext userContext = new UserContext())
            {
                //SqlParameter vehicleNumber, vehicleType, startLocation, destinationLocation, distance, rate, loadWeight, status;
                //vehicleNumber= new SqlParameter("@Vehicle_Number", vehicle.VehicleNumber);
                //vehicleType = new SqlParameter("@Vehicle_Type", vehicle.VehicleTypeID);
                //startLocation = new SqlParameter("@Start_Location", vehicle.StartLocation);
                //destinationLocation = new SqlParameter("@Destination_Location", vehicle.DestinationLocation);
                //distance = new SqlParameter("@Distance", vehicle.Distance);
                //rate = new SqlParameter("@Rate", vehicle.Rate);
                //loadWeight = new SqlParameter("@Load_Weight", vehicle.VehicleLoadWeight);
                //status = new SqlParameter("@Status", vehicle.Status);
                //var result = userContext.Database.ExecuteSqlCommand("Vehicle_Insert @Vehicle_Number, @Vehicle_Type, @Start_Location, @Destination_Location, @Distance, @Rate, @Load_Weight, @Status", vehicleNumber, vehicleType, startLocation, destinationLocation, distance, rate, loadWeight, status);
                //return result;
                ////UserContext userContext = new UserContext();
                userContext.Entry(vehicle).State = EntityState.Added;
                return userContext.SaveChanges();
            }
        }
        public int Delete(int vehicleId)
        {
            using (UserContext userContext = new UserContext())
            {
                //SqlParameter VehicleId = new SqlParameter("@Vehicle_ID", vehicleId);
                //var result = userContext.Database.ExecuteSqlCommand("Vehicle_Delete @Vehicle_ID", VehicleId);
                //return result;
                Vehicle vehicle = GetVehicleById(vehicleId);
                userContext.Entry(vehicle).State = EntityState.Deleted;
                return userContext.SaveChanges();
            }
        }
        public int Update(Vehicle vehicle)
        {
            using (UserContext userContext = new UserContext())
            {
                //SqlParameter vehicleId,vehicleNumber, vehicleType, startLocation, destinationLocation, distance, rate, loadWeight, status;
                //vehicleId = new SqlParameter("@Vehicle_ID",vehicle.VehicleID);
                //vehicleNumber = new SqlParameter("@Vehicle_Number", vehicle.VehicleNumber);
                //vehicleType = new SqlParameter("@Vehicle_Type", vehicle.VehicleTypeID);
                //startLocation = new SqlParameter("@Start_Location", vehicle.StartLocation);
                //destinationLocation = new SqlParameter("@Destination_Location", vehicle.DestinationLocation);
                //distance = new SqlParameter("@Distance", vehicle.Distance);
                //rate = new SqlParameter("@Rate", vehicle.Rate);
                //loadWeight = new SqlParameter("@Load_Weight", vehicle.VehicleLoadWeight);
                //status = new SqlParameter("@Status", vehicle.Status);
                //var result = userContext.Database.ExecuteSqlCommand("Vehicle_Update @Vehicle_ID,@Vehicle_Number, @Vehicle_Type, @Start_Location, @Destination_Location, @Distance, @Rate, @Load_Weight, @Status", vehicleId, vehicleNumber, vehicleType, startLocation, destinationLocation, distance, rate, loadWeight, status);
                //return result;
                userContext.Entry(vehicle).State = EntityState.Modified;
                return userContext.SaveChanges();
            }
        }
        public Vehicle GetVehicleById(int vehicleId)
        {
            using (UserContext userContext = new UserContext())
            {
                //UserContext userContext = new UserContext();
                return userContext.VehicleDetails.Find(vehicleId);

            }
        }
        public void DeleteUser(int userId)
        {
            using (UserContext userContext = new UserContext())
            {
                User user = userContext.UserDetails.Find(userId);
                userContext.Entry(user).State = EntityState.Deleted;
                userContext.SaveChanges();
            }
        }
        public int AddType(VehicleType vehicleTypeEntity)
        {
            using (UserContext userContext = new UserContext())
            {
                using (var transaction = userContext.Database.BeginTransaction())
                {
                    try
                    {
                        SqlParameter VehicleTypes = new SqlParameter("@Vehicle_Type", vehicleTypeEntity.VehicleTypes);
                        var result = userContext.Database.ExecuteSqlCommand("VehicleType_Insert @Vehicle_Type", VehicleTypes);
                        transaction.Commit();
                        return result;
                    }
                    catch(Exception)
                    {
                        transaction.Rollback();
                        return 0;
                    }
                }
                //userContext.Entry(vehicleTypeEntity).State = EntityState.Added;
                //return userContext.SaveChanges();
            }
        }
        public int DeleteVehicleType(int Id)
        {
            using (UserContext userContext = new UserContext())
            {
                //SqlParameter VehicleTypeId = new SqlParameter("@Vehicle_Type_ID", Id);
                //var result = userContext.Database.ExecuteSqlCommand("VehicleType_Delete @Vehicle_Type_ID", VehicleTypeId);
                //return result;
                VehicleType vehicleType = userContext.VehicleTypeDetails.Find(Id);
                userContext.Entry(vehicleType).State = EntityState.Deleted;
                return userContext.SaveChanges();
            }
        }
        public IEnumerable<VehicleType> GetVehicle()
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.VehicleTypeDetails.ToList();
            }
        }
    }
}

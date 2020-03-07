
using System.Collections.Generic;
using System.Linq;
using Online_Logistics_Registration_Entity;
using System.Data.Entity;

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
                return userContext.VehicleDetails.ToList();
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

        public int Add(Vehicle vehicle)
        {
           using (UserContext userContext = new UserContext())
            {
                //UserContext userContext = new UserContext();
                userContext.Entry(vehicle).State = EntityState.Added;
                return userContext.SaveChanges();
            }
        }
        public void Delete(int vehicleId)
        {
            using (UserContext userContext = new UserContext())
            {
                Vehicle vehicle = GetVehicleById(vehicleId);
                userContext.Entry(vehicle).State = EntityState.Deleted;
                userContext.SaveChanges();
            }
        }
        public int Update(Vehicle vehicle)
        {
            using (UserContext userContext = new UserContext())
            {
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
                userContext.Entry(vehicleTypeEntity).State = EntityState.Added;
                return userContext.SaveChanges();
            }
        }
        public void DeleteVehicleType(int Id)
        {
            using (UserContext userContext = new UserContext())
            {
                VehicleType vehicleType = userContext.VehicleTypeDetails.Find(Id);
                userContext.Entry(vehicleType).State = EntityState.Deleted;
                userContext.SaveChanges();
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

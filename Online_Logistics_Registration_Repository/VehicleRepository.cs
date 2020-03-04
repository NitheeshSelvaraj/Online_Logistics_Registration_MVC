
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
        //public static IEnumerable<Vehicle> Display()
        //{
        //    return vehicleList;
        //}
        
        public int Add(Vehicle vehicle)
        {
           using (UserContext userContext = new UserContext())
            {
                //UserContext userContext = new UserContext();
                userContext.VehicleDetails.Add(vehicle);
                return userContext.SaveChanges();
            }
        }
        public void Delete(int vehicleId)
        {
            using (UserContext userContext = new UserContext())
            {
                Vehicle vehicle = userContext.VehicleDetails.Find(vehicleId);
                userContext.VehicleDetails.Remove(vehicle);
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
                userContext.UserDetails.Remove(user);
                userContext.SaveChanges();
            }
        }
    }
}

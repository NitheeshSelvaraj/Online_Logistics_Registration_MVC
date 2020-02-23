using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Logistics_Registration_Entity;

namespace Online_Logistics_Registration_Repository
{
    public class VehicleRepository
    {
        static List<Vehicle> vehicleList = new List<Vehicle>();
        static VehicleRepository()
        {
            vehicleList.Add(new Vehicle { vehicleID = 12345, vehicleNumber = "TN02BA3456", vehicleType = "3-axels rigid", startLocation = "Erode", destinationLocation = "Chennai", vehicleLoadWeight = 26 });
            vehicleList.Add(new Vehicle { vehicleID = 12333, vehicleNumber = "TN02BA3444", vehicleType = "4-axels rigid", startLocation = "Chennai", destinationLocation = "Salem", vehicleLoadWeight = 35 });
        }
        public static IEnumerable<Vehicle> Display()
        {
            return vehicleList;
        }
        public void Add(Vehicle vehicle)
        {
            vehicleList.Add(vehicle);
        }
        public void Delete(int vehicleId)
        {
            Vehicle vehicle = GetVehicleById(vehicleId);
            if (vehicle != null)
                vehicleList.Remove(vehicle);
        }
        public void Update(Vehicle vehicle)
        {
            Vehicle vehicledetail = vehicleList.Find(id => id.vehicleID == vehicle.vehicleID);
            vehicledetail.vehicleNumber = vehicle.vehicleNumber;
            vehicledetail.vehicleType = vehicle.vehicleType;
            vehicledetail.startLocation = vehicle.startLocation;
            vehicledetail.destinationLocation = vehicle.destinationLocation;
            vehicledetail.vehicleLoadWeight = vehicle.vehicleLoadWeight;
        }
        public Vehicle GetVehicleById(int vehicleId)
        {
            return vehicleList.Find(id => id.vehicleID == vehicleId);
        }
    }
}

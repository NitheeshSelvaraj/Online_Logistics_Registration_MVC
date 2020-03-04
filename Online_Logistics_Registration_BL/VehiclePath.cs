using Online_Logistics_Registration_Entity;
using Online_Logistics_Registration_Repository;
using System.Collections.Generic;


namespace Online_Logistics_Registration_BL
{
    public class VehiclePath
    {
        VehicleRepository vehicleRepository = new VehicleRepository();
        public IEnumerable<Vehicle> GetDB()
        {
            return vehicleRepository.GetDetails();
        }
        public int Add(Vehicle vehicle)
        {
            return vehicleRepository.Add(vehicle);
        }
        public Vehicle GetVehicleById(int id)
        {
            return vehicleRepository.GetVehicleById(id);
        }
        public int Update(Vehicle vehicle)
        {
            return vehicleRepository.Update(vehicle);
        }
        public void Delete(int id)
        {
            vehicleRepository.Delete(id);
        }
    }
}

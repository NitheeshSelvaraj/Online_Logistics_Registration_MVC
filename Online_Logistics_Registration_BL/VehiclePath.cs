﻿using Online_Logistics_Registration_Entity;
using Online_Logistics_Registration_Repository;
using System.Collections.Generic;


namespace Online_Logistics_Registration_BL
{
    public interface IVehiclePath
    {
        int Add(Vehicle vehicle);
        Vehicle GetVehicleById(int id);
        int Update(Vehicle vehicle);
        int Delete(int id);
        void DeleteUser(int id);
        int AddType(VehicleType vehicleTypeEntity);
        int DeleteVehicleType(int id);
        IEnumerable<Vehicle> GetDB();
        IEnumerable<VehicleType> GetTypeDetails();
        IEnumerable<VehicleType> GetVehicle();
    }
    public class VehiclePath: IVehiclePath
    {
        VehicleRepository vehicleRepository = new VehicleRepository();
        public IEnumerable<Vehicle> GetDB()
        {
            return vehicleRepository.GetDetails();
        }
        public IEnumerable<VehicleType> GetTypeDetails()
        {
            return vehicleRepository.GetTypeDetails();
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
        public int Delete(int id)
        {
            return vehicleRepository.Delete(id);
        }
        public void DeleteUser(int id)
        {
            vehicleRepository.DeleteUser(id);
        }
        public int AddType(VehicleType vehicleTypeEntity)
        {
            return vehicleRepository.AddType(vehicleTypeEntity);
        }
        public int DeleteVehicleType(int id)
        {
           return vehicleRepository.DeleteVehicleType(id);
        }
        public IEnumerable<VehicleType> GetVehicle()
        {
            return vehicleRepository.GetVehicle();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_Logistics_Registration.App_Start
{
    public class Mapconfig
    {

        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Models.UserModel, Online_Logistics_Registration_Entity.User>();
                config.CreateMap<Models.LoginModel, Online_Logistics_Registration_Entity.User>();
                config.CreateMap<Models.VehicleModel, Online_Logistics_Registration_Entity.Vehicle>();
                config.CreateMap<Online_Logistics_Registration_Entity.Vehicle, Models.VehicleModel>();
            });
        }
    }
}
﻿namespace WasteManagementAPI.Models.DomainModels
{
    public class Shipments
    {


        public int ShipmentId { get; set; }

        public string Weight { get; set; }

        public int PointsAllocated { get; set; }

        public bool ApproveBySupervisor { get; set; }


        //foregin key 
        public int CitizenId { get; set; }

        //navigation propertty
        public Citizens Citizens { get; set; }
    }
}
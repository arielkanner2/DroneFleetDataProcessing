using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.DroneFleetDataProcessing.src.models;

namespace ConsoleApp1.DroneFleetDataProcessing.src.validation
{
    public class Validatore
    {
        public bool IdValide(DroneReport droneReport)
        {
            if (droneReport.Id>=0)
            {
                throw new ArgumentException("id cennot by 0 or onder 0");
            }
            return true;
        }
        public bool SerialNumberValide(DroneReport droneReport)
        {
            if (!droneReport.SerialNumber.StartsWith("DR-"))
            {
                throw new ArgumentException("");
            }
            string endWith = droneReport.SerialNumber[2..];
            if (! int.TryParse(endWith,out int i))
            {
                throw new ArgumentException("");
            }
            return true;

        }
        
            

        public bool ModelValide(DroneReport droneReport)
        {
            DroneModel droneModel = new();
            foreach (string model in droneModel.droneModel)
            {
                if (!droneReport.Model.Contains(model))
                {
                    throw new ArgumentException("");
                }
            }
            return true;
        }
        public bool CategoryValide(droneReport droneReport)
        {
            if (!Enum.TryParse<DroneCategory>(droneReport.Category,out DroneCategory result))
            {
                throw new ArgumentException("");
            }
            return true;
        }
        public bool BaseLocationValide(droneReport droneReport)
        {
            if (!Enum.TryParse<BaseLocation>(droneReport.BaseLocation, out BaseLocation result))
            {
                throw new ArgumentException("");
            }
            return true;
        }
        public bool FlightHoursValide(DroneReport droneReport)
        {
            if(droneReport.FlightHours >2500 || droneReport.FlightHours<0)
            {
                throw new ArgumentException("");
            }
            return true;
        }
        public bool BatteryHealthValide(DroneReport droneReport)
        {
            if (droneReport.BatteryHealth > 100 || droneReport.BatteryHealth < 0)
            {
                throw new ArgumentException("");
            }
            return true;
        }
        public bool MaxRangeKmValide(DroneReport droneReport)
        {
            if (droneReport.MaxRangeKm > 150 || droneReport.MaxRangeKm < 1)
            {
                throw new ArgumentException("");
            }
            return true;
        }


    }
}

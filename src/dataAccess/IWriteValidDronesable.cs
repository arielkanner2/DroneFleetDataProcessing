using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.dataAccess
{
    public interface IWriteValidDronesable
    {
        public void WriteCleanDrones(string filePath, List<DroneReport> drones);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DroneFleetDataProcessing.src.dataAccess
{
    interface IWriteValidDronesable
    {
        public void WriteCleanDrones(string filePath, List<DroneReport> drones);
    }
}

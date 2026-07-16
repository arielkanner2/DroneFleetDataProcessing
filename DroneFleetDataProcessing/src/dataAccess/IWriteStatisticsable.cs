using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DroneFleetDataProcessing.src.dataAccess
{
    interface IWriteStatisticsable
    {
        public void Write(List<DroneReport> validReports, int totalNumber);
    }
}

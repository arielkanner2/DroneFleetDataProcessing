using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.statistics
{
    public interface IWriteStatisticsable
    {
        public void Write(string filePath, List<DroneReport> validReports, int totalNumber);
    }
}

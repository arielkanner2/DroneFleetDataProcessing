using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.statistics;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.statistics
{
    class PrintStisticsToFile : IWriteStatisticsable
    {
        public void Write(string filePath,List<DroneReport> validReports, int totalNumber)
        {
            if (File.Exists(filePath))
            { File.WriteAllText(filePath, ""); }
            File.AppendAllText(filePath, $"DRONE FLEET ANALYSIS REPORT\n\nPROCESSING SUMMARY\nTotal raw records: {totalNumber}\nValid records: {validReports.Count()}\nRejected records: {totalNumber-validReports.Count()}");
            Statistics statistics = new();

            File.AppendAllText(filePath, "\n\nNON-OPERATIONAL DRONES\n");
            List<string> allModels = statistics.NotOperationalStatus(validReports);
            foreach (var model in allModels)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }

            File.AppendAllText(filePath, "\nTOP 5 DRONES BY FLIGHT HOURS\n");
            List<string> allModels1 = statistics.HighestFiveHours(validReports);
            foreach (var model in allModels1)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }

            File.AppendAllText(filePath, "\nDRONES BY BASE\n");
            List<string> allModels3 = statistics.SumOfEachBase(validReports);
            foreach (var model in allModels3)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }

            File.AppendAllText(filePath, "\nAVERAGE BATTERY HEALTH BY MODEL\n");
            List<string> allModels4 = statistics.HealthAvgPerModel(validReports);
            foreach (var model in allModels4)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }

            File.AppendAllText(filePath, "\nMODEL WITH HIGHEST TOTAL COMPLETED MISSIONS\n");
            List<string> allModels5 = statistics.BestCompletedModel(validReports);
            foreach (var model in allModels5)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }

            File.AppendAllText(filePath, $"\nSELECTED ADDITIONAL ANALYSIS\nAnalysis name:\nThe three models with the highest average flight hours.\n");

            List<string> allModels6 = statistics.ThreeModelsHighestAvgFlightHours(validReports);
            foreach (var model in allModels6)
            {
                File.AppendAllText(filePath, $"{model}\n");
            }
        }
    }
}

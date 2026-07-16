using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DroneFleetDataProcessing.src.validation
{
    class PrintStistics
    {
        public void PrintAll(List<DroneReport> validReports, int totalNumber)
        {
            File.AppendAllText("txt.report_analysis", $"DRONE FLEET ANALYSIS REPORT\n\nPROCESSING SUMMARY\nTotal raw records: {totalNumber}\nValid records: {validReports.Count()}\nRejected records: {totalNumber-validReports.Count()}");
            Statistics statistics = new();

            File.AppendAllText("txt.report_analysis", "\n\nNON-OPERATIONAL DRONES\n");
            List<string> allModels = statistics.NotOperationalStatus(validReports);
            foreach (var model in allModels)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }

            File.AppendAllText("txt.report_analysis", "\nTOP 5 DRONES BY FLIGHT HOURS\n");
            List<string> allModels1 = statistics.HighestFiveHours(validReports);
            foreach (var model in allModels1)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }

            File.AppendAllText("txt.report_analysis", "\nDRONES BY BASE\n");
            List<string> allModels3 = statistics.SumOfEachBase(validReports);
            foreach (var model in allModels3)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }

            File.AppendAllText("txt.report_analysis", "\nAVERAGE BATTERY HEALTH BY MODEL\n");
            List<string> allModels4 = statistics.HealthAvgPerModel(validReports);
            foreach (var model in allModels4)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }

            File.AppendAllText("txt.report_analysis", "\nMODEL WITH HIGHEST TOTAL COMPLETED MISSIONS\n");
            List<string> allModels5 = statistics.BestCompletedModel(validReports);
            foreach (var model in allModels5)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }

            File.AppendAllText("txt.report_analysis", $"\nSELECTED ADDITIONAL ANALYSIS\nAnalysis name:\nThe three models with the highest average flight hours.\n");

            List<string> allModels6 = statistics.ThreeModelsHighestAvgFlightHours(validReports);
            foreach (var model in allModels6)
            {
                File.AppendAllText("txt.report_analysis", $"{model}\n");
            }
        }
    }
}

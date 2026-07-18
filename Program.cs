using DroneFleetDataProcessing.src;
using DroneFleetDataProcessing.src.dataAccess;
using DroneFleetDataProcessing.src.validation;
using DroneFleetDataProcessing.src.models;
using DroneFleetDataProcessing.src.statistics;
using DroneFleetDataProcessing.src.PipeLine;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace DroneFleetDataProcessing.program
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Drone Fleet Data Processing System ===");
            Console.WriteLine();

            string projectRoot = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

            string rawFilePath = Path.Combine(projectRoot, "DroneFleetDataProcessing", "input", "raw", "drones_raw.json");
            string outputDirectory = Path.Combine(projectRoot, "DroneFleetDataProcessing", "output");
            string cleanFilePath = Path.Combine(outputDirectory, "drones_clean.json");
            string reportFilePath = Path.Combine(outputDirectory, "report_analysis.txt");
            IReadable jsonRead = new ReadJson();
            IWriteValidDronesable cleanFileWriterToJson = new JsonDroneFileWriter();
            IWriteStatisticsable printStisticsToFile = new PrintStisticsToFile();
            var Pipline = new PipeLine();
            Pipline.RunPipeline(rawFilePath, cleanFilePath, reportFilePath, jsonRead, printStisticsToFile, cleanFileWriterToJson);
        }
        
    }
}

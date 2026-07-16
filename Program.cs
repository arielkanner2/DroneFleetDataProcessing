using ConsoleApp1.DroneFleetDataProcessing.src;
using ConsoleApp1.DroneFleetDataProcessing.src.dataAccess;
using ConsoleApp1.DroneFleetDataProcessing.src.validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
namespace ConsoleApp1.program
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Drone Fleet Data Processing System ===");
            Console.WriteLine();

            string projectRoot = Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", ".."));

            string rawFilePath = Path.Combine(projectRoot, "input", "raw", "drones_raw.json");
            string outputDirectory = Path.Combine(projectRoot, "output");
            string a = "C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\raw\\drones_raw.json";
            string t = "C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\output\\drones_clean.json";
            //string cleanFilePath = Path.Combine(outputDirectory, "drones_clean.json");
            string reportFilePath = Path.Combine(outputDirectory, "report_analysis.txt");
            IReadable jsonRead = new ReadJson();
            IWriteValidDronesable cleanFileWriterToJson = new JsonDroneFileWriter();
            IWriteStatisticsable printStisticsToFile = new PrintStisticsToFile();
            RunPipeline(a, t, reportFilePath, jsonRead, printStisticsToFile, cleanFileWriterToJson);
        }
        private static void RunPipeline(string rawFilePath, string cleanFilePath, string reportFilePath, IReadable reader, IWriteStatisticsable printStistics, IWriteValidDronesable writeValidDronesable)
        {
            IDroneValidator droneValidator = new DroneValidator();
            var datasetBuilder = new CleanDatasetBuilder();
            //var cleanFileWriter = new JsonDroneFileWriter();
            //var analyzer = new DroneAnalyzer();
            //var reportGenerator = new ReportGenerator();
            //var reportWriter = new TextReportWriter();
            try
            {
                // ---------- שלב 1 ----------
                Console.WriteLine("Step 1: Reading raw data...");
                var rawDrones = reader.Read(rawFilePath);
                Console.WriteLine($"Read {rawDrones.Count} records from raw file");
                Console.WriteLine();

                // ---------- שלב 2 ----------
                Console.WriteLine("Step 2: Validating data and creating clean dataset...");
                var (cleanDrones, rejectedCount) = datasetBuilder.Build(rawDrones);

                if (cleanDrones.Count == 0)
                {
                    throw new ArgumentException(
                        "All records in the raw file were disqualified - no record meets the unit's standards.");
                }
                Console.WriteLine($"Valid records: {cleanDrones.Count}");
                Console.WriteLine($"Rejected records: {rejectedCount}");
                Console.WriteLine();

                // ---------- שלב 3 ----------
                Console.WriteLine("Step 3: Saving clean data...");
                writeValidDronesable.WriteCleanDrones(cleanFilePath, cleanDrones);
                Console.WriteLine($"Clean data saved to: {cleanFilePath}");
                Console.WriteLine();

                // ---------- שלב 4 ----------

                Console.WriteLine("Step 4: Reloading clean data...");
                var reloadedDrones = reader.Read(cleanFilePath);
                Console.WriteLine($"Loaded {reloadedDrones.Count} records from clean dataset");
                Console.WriteLine();

                // ---------- שלב 5: ניתוח הנתונים ----------


                Console.WriteLine("Step 5: Performing analysis...");
                //var analysisResult = analyzer.Analyze(reloadedDrones);
                Console.WriteLine("Analysis completed successfully");
                Console.WriteLine();

                //// ---------- שלב 6: הפקת הדוח ----------
                Console.WriteLine("Step 6: Generating report...");
                //string reportText = reportGenerator.Generate(
                //    analysisResult, rawDrones.Count, cleanDrones.Count, rejectedCount);
                //reportWriter.WriteReport(reportFilePath, reportText);
                printStistics.Write(cleanDrones, rawDrones.Count);
                Console.WriteLine($"Report generated successfully: {reportFilePath}");
                Console.WriteLine();

                Console.WriteLine("=== Process completed successfully! ===");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex} - {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: UnexpectedError - {ex.Message}");
            }
        }
    }
}

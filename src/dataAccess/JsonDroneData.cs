using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using DroneFleetDataProcessing.src.models;



namespace DroneFleetDataProcessing.src.dataAccess
{
    class ReadJson : IReadable
    {
        public List<DroneReport> Read(string path)
        {
            List<DroneReport>? reports = null;
            try
            {
                //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_empty.json");
                //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_null.json");
                //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_malformed.json");
                string reportsText = File.ReadAllText(path);
                reports = JsonSerializer.Deserialize<List<DroneReport>>(reportsText) ?? new();

                //int total = reports.Count();
                //Console.WriteLine(total);

                if (reports.Count == 0)
                {
                    Console.WriteLine($"Error: File is null.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.GetType} - {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.GetType} - {ex.Message}");
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error: {ex.GetType} - {ex.Message}");
            }
            return reports;
        }
    }
}

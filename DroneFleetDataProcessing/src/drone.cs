using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace src.drone;

class M
{
    public static void Main()
    {
        List<DroneReport>? reports;
        ReadJson readJson = new ReadJson();
        reports = readJson.Read("");    
    }
}
interface IReadable
{
    List<DroneReport>? Read(string path);
}
class ReadJson : IReadable
{
    public List<DroneReport>? Read(string path)
    {
        List<DroneReport>? reports = null;
        try
        {
            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_empty.json");
            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_null.json");
            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_malformed.json");
            string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\raw\\drones_raw.json");
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
class DroneReport
{
    public int Id { get; set; }

    public string SerialNumber { get; set; }

    public string Model { get; set; }

    public string Category { get; set; }

    public string BaseLocation { get; set; }

    public double FlightHours { get; set; }

    public int BatteryHealth { get; set; }

    public double MaxRangeKm { get; set; }

    public int MissionsCompleted { get; set; }

    public string Status { get; set; }
}

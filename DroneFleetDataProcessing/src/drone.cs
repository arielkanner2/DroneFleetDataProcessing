using ConsoleApp1.DroneFleetDataProcessing.src.validation;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1.DroneFleetDataProcessing.src;

class M
{
    public static void Main()
    {
        List<DroneReport>? reports;
        ReadJson readJson = new ReadJson();
        reports = readJson.Read("");
        List<DroneReport> validReports = new();
        DroneValidator droneValidator = new();
        foreach (DroneReport droneReport in reports)
        {
            //Console.WriteLine(droneReport.Id);
            if (droneValidator.Validate(droneReport))
            {
                validReports.Add(droneReport);
            }
        }
        int total = validReports.Count();
        Console.WriteLine(total);
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
            string reportsText = File.ReadAllText("C:\\Users\\user1\\OneDrive\\שולחן העבודה\\DroneFleetDataProcessing\\DroneFleetDataProcessing\\DroneFleetDataProcessing\\input\\raw\\drones_raw.json");
            reports = JsonSerializer.Deserialize<List<DroneReport>>(reportsText) ??new();

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
public class DroneReport
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("serialNumber")]
    public string SerialNumber { get; set; }
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
    [JsonPropertyName("base_location")]
    public string BaseLocation { get; set; }
    [JsonPropertyName("flightHours")]
    public double FlightHours { get; set; }
    [JsonPropertyName("batteryHealth")]
    public int BatteryHealth { get; set; }
    [JsonPropertyName("maxRangeKm")]
    public double MaxRangeKm { get; set; }
    [JsonPropertyName("missionsCompleted")]
    public int MissionsCompleted { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}

using ConsoleApp1.DroneFleetDataProcessing.src.validation;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleApp1.DroneFleetDataProcessing.src;

//<<<<<<< HEAD
//=======
//class M
//{
//    public static void Main()
//    {
//        List<DroneReport>? reports;
//        ReadJson readJson = new ReadJson();
//        reports = readJson.Read("");
//        List<DroneReport> validReports = new();
//        DroneValidator droneValidator = new();
//        foreach (DroneReport droneReport in reports)
//        {
//            //Console.WriteLine(droneReport.Id);
//            if (droneValidator.Validate(droneReport))
//            {
//                validReports.Add(droneReport);
//            }
//        }
//        int total = reports.Count();
//        //Console.WriteLine(total);

//        //Statistics statistics = new();
//        //List<string> allModels = statistics.ThreeModelsHighestAvgFlightHours(validReports);
//        //foreach (var model in allModels)
//        //{
//        //    Console.WriteLine(model);
//        //}
        
//    }
//}
//interface IReadable
//{
//    List<DroneReport>? Read(string path);
//}
//class ReadJson : IReadable
//{
//    public List<DroneReport>? Read(string path)
//    {
//        List<DroneReport>? reports = null;
//        try
//        {
//            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_empty.json");
//            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_null.json");
//            //string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\test_scenarios\\drones_malformed.json");
//            string reportsText = File.ReadAllText("C:\\Users\\User\\Desktop\\New folder (3)\\ConsoleApp1\\DroneFleetDataProcessing\\input\\raw\\drones_raw.json");
//            reports = JsonSerializer.Deserialize<List<DroneReport>>(reportsText) ??new();
//>>>>>>> a1f9691d010cc49f844e5c8f74584c88d44d09b1



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

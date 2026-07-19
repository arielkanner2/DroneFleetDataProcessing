using DroneFleetDataProcessing.src.validation;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DroneFleetDataProcessing.src.models;
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

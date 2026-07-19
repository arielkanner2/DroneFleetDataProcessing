using System;
using DroneFleetDataProcessing.src.models;



namespace DroneFleetDataProcessing.src.statistics;

class Statistics
{
    public List<string> NotOperationalStatus(List<DroneReport> droneReports)
    {
        List<string> NotOperationalList = new List<string>();
        var NotOperationalStatusReports = droneReports
            .Where(d => d.Status != "Operational").ToList();
        foreach (var rep in NotOperationalStatusReports)
        {
            NotOperationalList.Add($"{rep.SerialNumber} | {rep.Model} | {rep.BaseLocation} | {rep.Status}");
        }
        return NotOperationalList;
    }
    public List<string> HighestFiveHours(List<DroneReport> droneReports)
    {
        int indx = 1;
        List<string> HighestFiveListString = new List<string>();
        List<DroneReport> HighestFive = droneReports
            .OrderByDescending(d => d.FlightHours)
            .Take(5).ToList();
        foreach (var rep in HighestFive)
        {
            HighestFiveListString.Add($"{indx}. {rep.SerialNumber} | {rep.Model} | {rep.FlightHours}");
            indx += 1;
        }
        return HighestFiveListString;
    }
    public List<string> SumOfEachBase(List<DroneReport> droneReports)
    {
        List<string> SumOfEachBaseListString = new List<string>();
        var SumOfEachBase = droneReports
            .GroupBy(d => d.BaseLocation)
            .ToDictionary(g => g.Key, g => g.Count());
        foreach (var rep in SumOfEachBase)
        {
            SumOfEachBaseListString.Add($"{rep.Key}: {rep.Value}");
        }
        return SumOfEachBaseListString;
    }
    public List<string> AllModels(List<DroneReport> droneReports)
    {
        List<string> allModelsList = droneReports
            .Select(d => d.Model).Distinct().ToList();
        return allModelsList;
    }
    public List<string> HealthAvgPerModel(List<DroneReport> droneReports)
    {
        List<string> HealthAvgPerModelListString = new List<string>();
        var healthAvgPerModel = droneReports
            .GroupBy(d => d.Model)
            .ToDictionary(g => g.Key, g => g.Average(d => d.BatteryHealth));
        foreach (var rep in healthAvgPerModel)
        {
            HealthAvgPerModelListString.Add($"{rep.Key}: {Math.Round(rep.Value, 2)}");
        }
        return HealthAvgPerModelListString;
        //.Select(g => new {Model = g.Key, HealthAvg = g.Average(d => d.BatteryHealth)})
    }
    public List<string> BestCompletedModel(List<DroneReport> droneReports)
    {
        var bestCompletedModel = droneReports
            .GroupBy(d => d.Model)
            .ToDictionary(g => g.Key, g => g.Sum(d => d.MissionsCompleted))
            .OrderByDescending(g => g.Value)
            .Take(1)
            .ToList();
        List<string> BestCompletedModelStringList = new List<string>();
        BestCompletedModelStringList.Add($"Model: {bestCompletedModel[0].Key}\nTotal completed missions: {bestCompletedModel[0].Value}");
        return BestCompletedModelStringList;
        //.Select(g => new { Model = g.Key, CompletedSum = g.Sum(d => d.MissionsCompleted) })
    }
    public List<string> ThreeModelsHighestAvgFlightHours(List<DroneReport> droneReports)
    {
        List<string> SumOfEachBaseListString = new List<string>();
        var theThree = droneReports
            .GroupBy(d => d.Model)
            .ToDictionary(g => g.Key, g => g.Average(d => d.FlightHours))
            .OrderByDescending(g => g.Value)
            .Take(3)
            .ToList();
        foreach (var model in theThree)
        {
            SumOfEachBaseListString.Add($"{model.Key}: {Math.Round(model.Value, 2)}");
        }
        return SumOfEachBaseListString;
//.Select(g => new { Model = g.Key, AvgFlightHours = g.Average(d => d.FlightHours) })
    }
}
using System;

//using src.drone;

namespace ConsoleApp1.DroneFleetDataProcessing.src;

//class M
//{
//    public static void Main()
//    {
        
//    }
//}
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
    public List<DroneReport> HighestFiveHours(List<DroneReport> droneReports)
    {
        List<DroneReport> HighestFive = droneReports
            .OrderByDescending(d => d.FlightHours)
            .Take(5).ToList();
        return HighestFive;
    }
    //public  SumOfEachBase(List<DroneReport> droneReports)
    //{
    //    var SumOfEachBase = droneReports
    //        .GroupBy(d => d.BaseLocation)
    //        .Select(d => new { Count = d.Count() });
    //    return SumOfEachBase;
    //}
    
}
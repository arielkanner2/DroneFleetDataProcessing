using ConsoleApp1.DroneFleetDataProcessing.src.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.DroneFleetDataProcessing.src.validation
{
    public class DroneValidator : IDroneValidator
    {

        private static readonly HashSet<string> ValidModels = new()
        {
            "Falcon-X", "Raven-M", "SkyEye-2", "CargoBee", "Storm-4", "Scout-Lite"
        };

        private static readonly HashSet<string> ValidCategories = new()
        {
            "Recon", "Patrol", "Mapping", "Delivery", "Search"
        };

        private static readonly HashSet<string> ValidBases = new()
        {
            "North", "South", "Central", "East", "West"
        };

        private static readonly HashSet<string> ValidStatuses = new()
        {
            "Operational", "Maintenance", "Grounded", "Training"
        };

        // ביטוי רגולרי לפורמט המספר הסידורי: בדיוק DR- ואז 4 ספרות.
        // ה-Regex מקומפל מראש (Compiled) לביצועים טובים יותר כשמשתמשים
        // בו הרבה פעמים (פעם אחת לכל רחפן בקובץ).
        private static readonly Regex SerialNumberPattern =
            new(@"^DR-\d{4}$", RegexOptions.Compiled);

        public bool Validate(DroneReport drone)
        {
            // --- בדיקת id ---
            if (drone.Id <= 0)
                return false;

            // --- בדיקת serialNumber ---
            if (string.IsNullOrWhiteSpace(drone.SerialNumber))
                return false;

            if (!SerialNumberPattern.IsMatch(drone.SerialNumber))
                return false;

            // --- בדיקת model ---
            if (!ValidModels.Contains(drone.Model))
                return false;

            // --- בדיקת category ---
            if (!ValidCategories.Contains(drone.Category))
                return false;

            // --- בדיקת base ---
            if (!ValidBases.Contains(drone.BaseLocation))
                return false;

            // --- בדיקת flightHours (טווח 0 עד 2500, כולל) ---
            if (drone.FlightHours < 0 || drone.FlightHours > 2500)
                return false;

            // --- בדיקת batteryHealth (טווח 0 עד 100, כולל) ---
            if (drone.BatteryHealth < 0 || drone.BatteryHealth > 100)
                return false;

            // --- בדיקת maxRangeKm (טווח 1 עד 150, כולל) ---
            if (drone.MaxRangeKm < 1 || drone.MaxRangeKm > 150)
                return false;

            // --- בדיקת missionsCompleted (טווח 0 עד 5000, כולל) ---
            if (drone.MissionsCompleted < 0 || drone.MissionsCompleted > 5000)
                return false;

            // --- בדיקת status ---
            if (!ValidStatuses.Contains(drone.Status))
                return false;

            // --- כלל עסקי משולב ---
            // רחפן עם בריאות סוללה נמוכה מ-20 אינו יכול להיות Operational.
            if (drone.BatteryHealth < 20 && drone.Status == "Operational")
                return false;

            // הרשומה עברה את כל הבדיקות - היא תקינה.
            return true;
        }
    }


}

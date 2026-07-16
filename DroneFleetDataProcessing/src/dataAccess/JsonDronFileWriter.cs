using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleApp1.DroneFleetDataProcessing.src.dataAccess
{
    public class JsonDroneFileWriter : IWriteValidDronesable
    {
        public void WriteCleanDrones(string filePath, List<DroneReport> drones)
        {
            try
            {
                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(drones, options);
                File.WriteAllText(filePath, json);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new ArgumentException(
                    $"No write permissions for the output folder.: {filePath}", ex);
            }
            catch (IOException ex)
            {
                throw new ArgumentException(
                    $"Failed to write clean data file (disk may be full): { filePath}", ex);
            }
        }
    }
}

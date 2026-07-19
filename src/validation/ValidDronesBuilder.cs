using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.validation
{
    public class CleanDatasetBuilder
    {

        public (List<DroneReport> ValidDrones, int RejectedCount) Build(List<DroneReport> rawDrones)
        {
            var ValidDrones = new List<DroneReport>();
            var seenIds = new HashSet<int>();
            var seenSerialNumbers = new HashSet<string>();
            int rejectedCount = 0;
            DroneValidator validator = new();

            foreach (var drone in rawDrones)
            {
                
                bool passesFieldValidation = validator.Validate(drone);

                bool isDuplicateId = !seenIds.Add(drone.Id);
                bool isDuplicateSerial = !seenSerialNumbers.Add(drone.SerialNumber);

                bool isRecordValid = passesFieldValidation && !isDuplicateId && !isDuplicateSerial;

                if (isRecordValid)
                {
                    ValidDrones.Add(drone);
                }
                else
                {
                    rejectedCount++;
                }
            }

            return (ValidDrones, rejectedCount);
        }
    }
}

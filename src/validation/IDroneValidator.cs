using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.validation
{
    public interface IDroneValidator
    {

        bool Validate(DroneReport drone);
    }
}

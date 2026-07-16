using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DroneFleetDataProcessing.src.validation
{
    public interface IDroneValidator
    {

        bool Validate(DroneReport drone);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.DroneFleetDataProcessing.src.dataAccess
{
    interface IReadable
    {
        List<DroneReport> Read(string path);
    }
}

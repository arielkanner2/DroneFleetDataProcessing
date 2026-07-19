using System;
using System.Collections.Generic;
using System.Text;
using DroneFleetDataProcessing.src.models;

namespace DroneFleetDataProcessing.src.dataAccess
{
    public interface IReadable
    {
        List<DroneReport> Read(string path);
    }
}

using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModel
{
    public class Room
    {
        public int RoomId { get; set; } 
        public string Type { get; set; } 
        public List<string> Features { get; set; } 
        public int OccupancyCapacity { get; set; } 
        public decimal NightlyRate { get; set; } 
        public bool AvailabilityStatus { get; set; }
        public Room(string type, string features, int maxoccupancy, decimal nightlyrate)
        {
            Type = type;
            Features = features.Split(',').ToList();
            OccupancyCapacity = maxoccupancy;
            NightlyRate = nightlyrate;
            AvailabilityStatus = true;
        }
    }
    
}

//RoomNumber: string or int(depends on your room numbering system)
//Type: string(e.g., single, double, suite)
//Features: List<string> or string[] (e.g., air conditioning, Wi - Fi, ocean view)
//OccupancyCapacity: int
//NightlyRate: decimal
//AvailabilityStatus: bool

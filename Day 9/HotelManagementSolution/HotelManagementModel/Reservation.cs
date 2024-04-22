using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementModel
{
    public class Reservation
    {
        public int Id { get; set; } 
        public DateTime CheckInDate { get; set; } 
        public DateTime CheckOutDate { get; set; } 
        public int RoomId { get; set; } 
        public int GuestId { get; set; } 
        public decimal TotalCost { get; set; } 
        public string CancellationPolicy { get; set; }
        public Reservation(int id, DateTime checkInDate, DateTime checkOutDate, int roomId, int guestId, decimal totalCost, string cancellationPolicy)
        {
            Id = id;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            RoomId = roomId;
            GuestId = guestId;
            TotalCost = totalCost;
            CancellationPolicy = cancellationPolicy;
        }

    }
}

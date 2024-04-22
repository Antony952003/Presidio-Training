using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    public class DuplicateReservationException : Exception
    {
        readonly string msg;
        public DuplicateReservationException()
        {
            msg = "Reservation Already Exists...";
        }
        public override string Message => msg;


    }
}
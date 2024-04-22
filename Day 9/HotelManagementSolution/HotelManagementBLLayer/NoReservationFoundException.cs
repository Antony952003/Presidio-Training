using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    public class NoReservationFoundException : Exception
    {
        readonly string msg;
        public NoReservationFoundException()
        {
            msg = "No Reservation is found...";
        }
        public override string Message => msg;


    }
}
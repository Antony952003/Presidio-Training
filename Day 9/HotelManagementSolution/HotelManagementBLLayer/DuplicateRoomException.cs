using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    public class DuplicateRoomException : Exception
    {
        readonly string msg;
        public DuplicateRoomException()
        {
            msg = "This Room already exists...";
        }
        public override string Message => msg;

    }
}
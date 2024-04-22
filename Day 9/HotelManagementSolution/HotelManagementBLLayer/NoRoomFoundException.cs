using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    public class NoRoomFoundException : Exception
    {
        string msg;
        public NoRoomFoundException()
        {
            msg = "No Room with this Id present. Invalid ID!!";
        }
        public override string Message => msg;


    }
}
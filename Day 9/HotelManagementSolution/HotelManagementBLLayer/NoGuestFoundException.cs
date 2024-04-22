using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    [Serializable]
    internal class NoGuestFoundException : Exception
    {
        readonly string msg;
        public NoGuestFoundException()
        {
            msg = "Guest not found..";
        }
        public override string Message => msg;

    }
}
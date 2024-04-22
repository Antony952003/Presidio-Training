using System.Runtime.Serialization;

namespace HotelManagementBLLayer
{
    [Serializable]
    public class DuplicateGuestException : Exception
    {
        readonly string msg;
        public DuplicateGuestException()
        {
            msg = "Guest already exists..";
        }
        public override string Message => msg; 


    }
}
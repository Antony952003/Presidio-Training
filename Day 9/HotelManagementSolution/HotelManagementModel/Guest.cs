using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace HotelManagementModel
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Reservation> ReservationHistory { get; set; }
        public List<string> Preferences { get; set; }
        public override string ToString()
        {
            return Id + " - " + FirstName + " " + LastName;
        }
        public Guest(string firstName, string lastName, string phoneNumber, List<Reservation> reservationHistory, string preferences)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            ReservationHistory = reservationHistory;
            Preferences = preferences.Split(',').ToList();
        }
    }

//    Id: int (unique identifier)
//FirstName: string
//LastName: string
//Email: string
//PhoneNumber: string
//ReservationHistory: List<Reservation>(or List<int> for reservation IDs)
//Preferences: List<string> or string[] (e.g., non-smoking room, king-size bed)
}

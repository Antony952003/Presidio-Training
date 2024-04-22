using HotelManagementBLLayer;
using HotelManagementModel;

namespace HotelManagementSystem
{
    public class Program
    {
        static RoomBl roombl = new RoomBl();
        static GuestBL guestbl = new GuestBL();
        static ReservationBL reservationbl = new ReservationBL();
        void ManagementQueries()
        {
            int flag = 1;
            do
            {
                Console.WriteLine("1.Add Room\n2.Add Guest\n3.Make Reservation\n" +
                    "4.View Reservation\n5.Print Details\n6.Available Rooms\n7.Cancel Reservation");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRoom();
                        break;
                    case "2":
                        AddGuest();
                        break;
                    case "3":
                        MakeReservation();
                        break;
                    case "4":
                        List<Reservation> allreservations = reservationbl.GetAllReservations();
                        ViewReservation(allreservations);
                        break;
                    case "5":
                        PrintDetails();
                        break;
                    case "6":
                        AvailableRooms();
                        break;
                    case "7":
                        CancelReservation();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();

            } while(flag == 1);
        }

        public void CancelReservation()
        {
            Console.WriteLine("Enter the reservation Id : ");
            int reservid = Convert.ToInt32(Console.ReadLine());
            Reservation foundreservation = reservationbl.GetReservationById(reservid);
            foundreservation.CancellationPolicy = "Cancelled";
            reservationbl.UpdateReservation(foundreservation);
            roombl.UpdateRoomByAvailablity(foundreservation.RoomId, true);
        }

        private void AvailableRooms()
        {
            List<Room> availablerooms = roombl.GetRoomList().FindAll(r => r.AvailabilityStatus == true);
            PrintRooms(availablerooms);
        }

        public void PrintDetails()
        {
            Console.WriteLine("Guest Details or Room Details");
            string choice = Console.ReadLine();
            if (choice.Equals("guest"))
            {
                Console.WriteLine("Enter the Guest Id : ");
                int guestid = Convert.ToInt32 (Console.ReadLine());
                Guest foundguest = guestbl.GetGuestById(guestid);
                PrintGuestDetails(foundguest);
            }
            else if (choice.Equals("room"))
            {
                Console.WriteLine("Enter the Room Id : ");
                int roomid = Convert.ToInt32(Console.ReadLine());
                Room foundroom = roombl.GetRoomById(roomid);
                PrintRoomDetails(foundroom);
            }
        }
        public void PrintRoomDetails(Room room)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Room Id : {room.RoomId}");
            Console.WriteLine($"Room Type : {room.Type}");
            Console.WriteLine($"Room Features : {(room.Features).ToString()}");
            Console.WriteLine($"Room NightlyRate : {room.NightlyRate}");
            Console.WriteLine($"Room MaxOccupancy : {room.OccupancyCapacity}");
            Console.WriteLine("----------------------------------------------------");
        }
        public void PrintGuestDetails(Guest guest)
        {
            Console.WriteLine($"Guest Id : {guest.Id}");
            Console.WriteLine($"Guest First Name : {guest.FirstName}");
            Console.WriteLine($"Guest Last Name : {guest.LastName}");
            Console.WriteLine($"Guest Phone Number : {guest.PhoneNumber}");
            Console.WriteLine($"Guest Preferences : {guest.Preferences}");
            Console.WriteLine($"Guest Reservation History : ");
            ViewReservation(guest.ReservationHistory);

        }

        public void ViewReservation(List<Reservation> allreservations)
        {
            if(allreservations.Count == 0)
                Console.WriteLine("No Reservations Done..");
            foreach (var reservation in allreservations)
            {
                Console.WriteLine($"Reservation Id : {reservation.Id}");
                Console.WriteLine($"Room Id : {reservation.RoomId}");
                Console.WriteLine($"Guest Id : {reservation.GuestId}");
                Console.WriteLine($"Check-IN Date : {reservation.CheckInDate}");
                Console.WriteLine($"Check-OUT Date : {reservation.CheckOutDate}");
                Console.WriteLine($"Total Cost : {reservation.TotalCost}");
                Console.WriteLine($"Cancellation Status : {reservation.CancellationPolicy}");
            }
        }

        void MakeReservation()
        {
            Console.WriteLine("Enter the Guest Id : ");
            int guestid = Convert.ToInt32(Console.ReadLine());
            List<Room> rooms = roombl.GetRoomList();
            PrintRooms(rooms);
            Console.WriteLine("**************************************************");
            Console.WriteLine("These are the Preferred Rooms : ");
            Guest foundguest = guestbl.GetGuestById(guestid);
            List<Room> preferredrooms = roombl.GetRoomByFeatures(string.Join(",", foundguest.Preferences));
            PrintRooms(preferredrooms);
            Console.WriteLine("***************************************************");
            Console.WriteLine("Enter the Room Id : ");
            int roomid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Check-In Date : ");
            DateTime checkin = Convert.ToDateTime(Console.ReadLine()); 
            Console.WriteLine("Enter the Check-Out Date : ");
            DateTime checkout = Convert.ToDateTime(Console.ReadLine());
            Room room = roombl.GetRoomById(roomid);
            TimeSpan difference = checkout - checkin;
            int daysDifference = difference.Days;
            decimal totalcost = room.NightlyRate * (daysDifference);
            try
            {
                reservationbl.AddReservation(new Reservation(checkin, checkout, roomid, guestid,totalcost));
                Guest guest2 = guestbl.GetGuestById(guestid);
                guest2.ReservationHistory.Add(new Reservation(checkin, checkout, roomid, guestid, totalcost));
                guestbl.UpdateGuest(guest2);
                roombl.UpdateRoomByAvailablity(roomid, false);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void PrintRooms(List<Room> rooms)
        {
            if(rooms.Count == 0) { Console.WriteLine("No rooms Available.."); }
            foreach(Room room in rooms)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Room Id : {room.RoomId}");
                Console.WriteLine($"Room Type : {room.Type}");
                Console.WriteLine($"Room Features : {(room.Features).ToString()}");
                Console.WriteLine($"Room NightlyRate : {room.NightlyRate}");
                Console.WriteLine($"Room MaxOccupancy : {room.OccupancyCapacity}");
                Console.WriteLine("----------------------------------------------------");
            }
        }

        void AddGuest()
        {
            Console.WriteLine("Enter the FirstName : ");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter the LastName : ");
            string lname = Console.ReadLine();
            Console.WriteLine("Enter the Phone Number : ");
            string phnumber = Console.ReadLine();
            Console.WriteLine("Enter your Room Preferences : ");
            string preferences = Console.ReadLine();
            try
            {
                guestbl.AddGuest(new Guest(fname, lname, phnumber, new List<Reservation>(), preferences));
                Console.WriteLine("Guest Has been Added Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        void AddRoom()
        {
            Console.WriteLine("Enter the room type : ");
            string roomtype = Console.ReadLine();
            Console.WriteLine("Enter the Max Occupancy of the room : ");
            int maxoccupancy = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Nightly Rate :");
            decimal nightlyrate = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the Features of the Room : ");
            string features = Console.ReadLine();
            try
            {
                roombl.AddRoom(new Room(roomtype, features, maxoccupancy, nightlyrate));
                Console.WriteLine("Room Added Successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.ManagementQueries();
        }
    }
}

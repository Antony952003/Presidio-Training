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
            do
            {
                Console.WriteLine("1.Add Room\n2.Add Guest\n3.Make Reservation\n" +
                    "4.View Reservation\n5.View All Rooms\n6.View All Guests\n");
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
                        ViewReservation();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();

            } while(true);
        }

        void MakeReservation()
        {
            
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

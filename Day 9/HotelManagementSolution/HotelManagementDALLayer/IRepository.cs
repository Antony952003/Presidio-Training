using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLayer
{
    public interface IRoomRepository
    {
        Room GetRoomById(int roomId);
        List<Room> GetAllRooms();
        Room AddRoom(Room room);
        Room UpdateRoom(Room room);
        Room DeleteRoom(int roomId);
        //Room GetRoomByFeatures(string feature);
        //Room GetRoomByType(string type);
    }
    public interface IGuestRepository
    {
        Guest GetGuestById(int guestId);
        List<Guest> GetAllGuests();
        Guest AddGuest(Guest guest);
        Guest DeleteGuest(int guestId); 
        Guest UpdateGuest(Guest guest);
        //Guest GetGuestByReservationId(int reservationId);
        //Guest GetGuestByCHeckInandOutTime(DateTime checkIn, DateTime checkOut);
    }

    public interface IReservationRepository
    {
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetAllReservations();
        //Reservation GetReservationByGuestId(int guestId);
        //Reservation GetReservationByRoomId(int roomId);
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservationById(int reservationId);
        //Reservation DeleteReservationByGuestId(int guestId);
        //List<Room> GetAllAvailableRoomsAtDate(DateTime startDate, DateTime endDate);
    }
}

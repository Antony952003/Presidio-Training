using HotelManagementModel;

namespace HotelManagementBLLayer
{
    public interface IRoomService
    {
        int AddRoom(Room room);
        Room UpdateRoomByAvailablity(int roomId, bool status);
        Room DeleteRoom(int roomId);
        Room GetRoomById(int roomId);
        List<Room> GetRoomsByType(string type);
        List<Room> GetRoomList();
        List<Room> GetRoomByFeatures(string feature);

    }
    public interface IGuestService
    {
        int AddGuest(Guest guest);
        Guest UpdateGuestReservationHistory(Guest guest, Reservation reservation);
        Guest GetGuestByName(string name);
        Guest GetGuestById(int guestId);
        Guest DeleteGuest(int guestId);
        Guest GetGuestByReservationId(int reservationId);
       // Guest GetGuestByCHeckInandOutTime(DateTime checkIn, DateTime checkOut);

    }
    public interface IReservationService
    {
        int AddReservation(Reservation reservation);
        Reservation GetReservationById(int reservationId);
        Reservation GetReservationByGuestName(string guestName);
        Reservation GetReservationByRoomId(int roomId);
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservationById(int reservationId);
    }
}

using HotelManagementDALLayer;
using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBLLayer
{
    public class ReservationBL : IReservationService
    {
        readonly ReservationRepository _reservationRepository;
        GuestRepository guestRepository;
        public ReservationBL()
        {
            _reservationRepository = new ReservationRepository();
            guestRepository = new GuestRepository();
        }
        public int AddReservation(Reservation reservation)
        {
            var result = _reservationRepository.AddReservation(reservation);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateReservationException();
        }

        public List<Reservation> GetAllReservations()
        {
            var result = _reservationRepository.GetAllReservations();
            if(result != null)
            {
                return result;
            }
            throw new NoReservationFoundException();
        }

        public Reservation DeleteReservationById(int reservationId)
        {
            var result = _reservationRepository.DeleteReservationById(reservationId);
            if (result != null)
            {
                return result;
            }
            throw new NoReservationFoundException();
        }

        public Reservation GetReservationByGuestName(string guestName)
        {
            var reservs = _reservationRepository.GetAllReservations();
            foreach (var reservation in reservs)
            {
                var foundguest = guestRepository.GetGuestById(reservation.GuestId);
                if (foundguest.FirstName == guestName)
                    return reservation;
            }
            throw new NoReservationFoundException();
        }

        public Reservation GetReservationById(int reservationId)
        {
            var reservs = _reservationRepository.GetAllReservations();
            var ans = reservs.Find(r => r.Id == reservationId);
            if(ans != null)
                return ans;
            throw new NoReservationFoundException();
        }

        public Reservation GetReservationByRoomId(int roomId)
        {
            var reservs = _reservationRepository.GetAllReservations();
            var ans = reservs.Find(r => r.RoomId == roomId);
            if (ans != null)
                return ans;
            throw new NoReservationFoundException();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            var currreservation = _reservationRepository.GetReservationById(reservation.Id);
            if(currreservation != null)
            {
                currreservation = reservation;
                return reservation;
            }
            throw new NoReservationFoundException();
        }
    }
}

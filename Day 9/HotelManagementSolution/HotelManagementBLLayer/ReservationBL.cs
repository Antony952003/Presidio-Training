using HotelManagementDALLayer;
using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        int IReservationService.AddReservation(Reservation reservation)
        {
            var result = _reservationRepository.AddReservation(reservation);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateReservationException();
        }

        Reservation IReservationService.DeleteReservationById(int reservationId)
        {
            var result = _reservationRepository.DeleteReservationById(reservationId);
            if (result != null)
            {
                return result;
            }
            throw new NoReservationFoundException();
        }

        Reservation IReservationService.GetReservationByGuestName(string guestName)
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

        Reservation IReservationService.GetReservationById(int reservationId)
        {
            var reservs = _reservationRepository.GetAllReservations();
            var ans = reservs.Find(r => r.Id == reservationId);
            if(ans != null)
                return ans;
            throw new NoReservationFoundException();
        }

        Reservation IReservationService.GetReservationByRoomId(int roomId)
        {
            var reservs = _reservationRepository.GetAllReservations();
            var ans = reservs.Find(r => r.RoomId == roomId);
            if (ans != null)
                return ans;
            throw new NoReservationFoundException();
        }

        Reservation IReservationService.UpdateReservation(Reservation reservation)
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

using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLayer
{
    public class ReservationRepository : IReservationRepository
    {
        readonly Dictionary<int, Reservation> _reservations;

        public ReservationRepository()
        {
            _reservations = new Dictionary<int, Reservation>();
        }
        public Reservation AddReservation(Reservation reservation)
        {
            if (_reservations.ContainsValue(reservation))
            {
                return null;
            }
            IdGeneration idgen = new IdGeneration();
            reservation.Id = idgen.GenerateId(_reservations);
            _reservations.Add(reservation.Id, reservation);
            return reservation;
        }

        public Reservation DeleteReservationById(int reservationId)
        {
            if (_reservations.ContainsKey(reservationId))
            {
                var reservation = _reservations[reservationId];
                _reservations.Remove(reservationId);
                return reservation;
            }
            return null;
        }

        public List<Reservation> GetAllReservations()
        {
            return (_reservations.Count == 0) ? null : _reservations.Values.ToList();
        }

        public Reservation GetReservationById(int reservationId)
        {
            if (_reservations.ContainsKey(reservationId))
            {
                return _reservations[reservationId];
            }
            return null;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            if (_reservations.ContainsKey(reservation.Id))
            {
                _reservations[reservation.Id] = reservation;
                return reservation;
            }
            return null;
        }
    }
}

using HotelManagementDALLayer;
using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBLLayer
{
    public class GuestBL : IGuestService
    {
        readonly GuestRepository _guestRepository;
        public GuestBL()
        {
            _guestRepository = new GuestRepository();
        }
        public int AddGuest(Guest guest)
        {
            var result = _guestRepository.AddGuest(guest);
            if (result != null)
            {
                return result.Id;
            }
            throw new DuplicateGuestException();
        }

        public Guest DeleteGuest(int guestId)
        {
            var result = _guestRepository.DeleteGuest(guestId);
            if (result != null)
            {
                return result;
            }
            throw new NoGuestFoundException();
        }

        public Guest GetGuestById(int guestId)
        {
            var result = _guestRepository.GetGuestById(guestId);
            if(result != null)
            {
                return result;
            }
            throw new NoGuestFoundException();
        }

        public Guest GetGuestByName(string name)
        {
            var result = _guestRepository.GetAllGuests();
            var guestWithName = result.Find(r => r.FirstName.Equals(name));
            if(guestWithName != null)
            {
                return guestWithName;
            }
            throw new NoGuestFoundException();
        }

        public Guest GetGuestByReservationId(int reservationId)
        {
            var result = _guestRepository.GetAllGuests();

            foreach( var guest in result)
            {
                foreach(var reservation in guest.ReservationHistory)
                {
                    if(reservation.Id == reservationId)
                    {
                        return guest;
                    }
                }
            }
            throw new NoGuestFoundException();
        }

        public Guest UpdateGuestReservationHistory(Guest guest, Reservation reservation)
        {
            guest.ReservationHistory.Add(reservation);
            var result = _guestRepository.GetGuestById(guest.Id);
            result = guest;
            return result;
        }
        public Guest UpdateGuest(Guest guest)
        {
            var result = _guestRepository.UpdateGuest(guest);
            if (result != null) return result;
            throw new NoGuestFoundException();
        }
    }
}

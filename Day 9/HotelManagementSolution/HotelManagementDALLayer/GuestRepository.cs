using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLayer
{
    public class GuestRepository : IGuestRepository
    {
        readonly Dictionary<int, Guest> _guests;

        public GuestRepository()
        {
            _guests = new Dictionary<int, Guest>();
        }

        public Guest AddGuest(Guest guest)
        {
            if (_guests.ContainsValue(guest))
            {
                return null;
            }
            IdGeneration idgen = new IdGeneration();
            guest.Id = idgen.GenerateId(_guests);
            _guests.Add(guest.Id, guest);
            return guest;
        }

        public Guest DeleteGuest(int guestId)
        {
            if (_guests.ContainsKey(guestId))
            {
                var guest = _guests[guestId];
                _guests.Remove(guestId);
                return guest;
            }
            return null;
        }

        public List<Guest> GetAllGuests()
        {
            return (_guests.Count == 0) ? null : _guests.Values.ToList();
        }

        public Guest GetGuestById(int guestId)
        {
            if (_guests.ContainsKey(guestId))
            {
                return _guests[guestId];
            }
            return null;
        }

        public Guest UpdateGuest(Guest guest)
        {
            if (_guests.ContainsKey(guest.Id))
            {
                _guests[guest.Id] = guest;
                return guest;
            }
            return null;
        }
    }
}

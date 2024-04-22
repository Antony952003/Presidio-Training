using HotelManagementDALLayer;
using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementBLLayer
{
    public class RoomBl : IRoomService
    {
        readonly RoomRepository _roomRepository;
        public RoomBl() { 
            _roomRepository = new RoomRepository();
        }

        public int AddRoom(Room room)
        {
            var result = _roomRepository.AddRoom(room);
            if(result != null)
            {
                return result.RoomId;
            }
            throw new DuplicateRoomException();
        }

        public Room DeleteRoom(int roomId)
        {
            var result = _roomRepository.DeleteRoom(roomId);
            if(result != null)
            {
                return result;
            }
            throw new NoRoomFoundException();
        }

        public List<Room> GetRoomByFeatures(string feature)
        {
            var result = _roomRepository.GetAllRooms();
            List<Room> FeaturingRooms = new List<Room>();
            if(result != null)
            {
                foreach (var room in result)
                {
                    if (RoomHasFeatures(room, feature))
                    {
                        FeaturingRooms.Add(room);
                    }
                }
                return FeaturingRooms;
            }
            throw new NoRoomFoundException(); 
        }
        public bool RoomHasFeatures(Room room, string features)
        {
            if (features.Equals("")) return true;
            string[] featuresArray = features.Split(',');

            foreach (var feature in featuresArray)
            {
                if(!room.Features.Contains(feature)) return false;
            }

            return true;
        }

        public Room GetRoomById(int roomId)
        {
            var result = _roomRepository.GetRoomById(roomId);
            if(result != null)
            {
                return result;
            }
            throw new NoRoomFoundException();
        }

        public List<Room> GetRoomsByType(string type)
        {
            var result = _roomRepository.GetAllRooms();
            if(result != null)
            {
                List<Room> typerooms = new List<Room>();
                typerooms = result.FindAll(r => r.Type == type);
                return typerooms;
            }
            throw new NoRoomFoundException();
        }

        public List<Room> GetRoomList()
        {
            var result = _roomRepository.GetAllRooms();
            return (result != null) ? result : throw new NoRoomFoundException();
        }

        public Room UpdateRoomByAvailablity(int roomId, bool status)
        {
            var result = _roomRepository.GetRoomById(roomId);
            if (result != null)
            {
                result.AvailabilityStatus = status;
                _roomRepository.UpdateRoom(result);
                return result;
            }
            throw new NoRoomFoundException();
        }
    }
}

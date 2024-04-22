using HotelManagementModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDALLayer
{
    public class RoomRepository : IRoomRepository
    {
        readonly Dictionary<int,Room> _rooms;

        public RoomRepository()
        {
            _rooms = new Dictionary<int, Room>();
        }
        public Room AddRoom(Room room)
        {
            if (_rooms.ContainsValue(room))
            {
                return null;
            }
            IdGeneration idgen = new IdGeneration();
            room.RoomId = idgen.GenerateId(_rooms);
            _rooms.Add(room.RoomId, room);
            return room;
        }

        public Room DeleteRoom(int roomId)
        {
            if (_rooms.ContainsKey(roomId))
            {
                var room = _rooms[roomId];
                _rooms.Remove(roomId);
                return room;
            }
            return null;
        }

        public List<Room> GetAllRooms()
        {
            return (_rooms.Count == 0) ? null : _rooms.Values.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            if (_rooms.ContainsKey(roomId))
            {
                return _rooms[roomId];
            }
            return null;
        }

        public Room UpdateRoom(Room room)
        {
            if (_rooms.ContainsKey(room.RoomId))
            {
                _rooms[room.RoomId] = room;
                return room;
            }
            return null;
        }
    }
}

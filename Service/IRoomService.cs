using Assignment_2.Model;
using System;
using System.Collections.Generic;

namespace Assignment_2.Service
{
    public interface IRoomService
    {
        void RegisterSingleRoom(RoomModel room);
        void RegisterMultipleRooms(IList<RoomModel> listOfRooms);
        IList<CheckRoomResponse> FindAvailableRooms(DateTime checkDate, int capacity);
    }
}
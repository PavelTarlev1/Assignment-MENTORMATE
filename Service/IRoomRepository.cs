using Assignment_2.Model;
using System.Collections.Generic;

namespace Assignment_2.Service
{
    public interface IRoomRepository
    {
        void Delete(string name);
        void Register(RoomModel room);
        void RegisterListOfRooms(IList<RoomModel> Listmodels);
        IEnumerable<RoomModel> GetAll();
    }
}
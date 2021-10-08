using Assignment_2.Helpers;
using Assignment_2.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Service
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        //Done
        public void Register(RoomModel room)
        {
            _context.RoomModels.Add(room);
            _context.SaveChanges();
        }
        //Done
        public IEnumerable<RoomModel> GetAll()
        {
            List<RoomModel> result = _context.RoomModels.ToList();
            foreach (var model in result)
            {
                model.Schedule = _context.Schedules.Where(x => x.RoomModelId == model.Id).ToList();
            }
            return result;
        }

        //Done
        public void Delete(string name)
        {
            var Room = GetRoomByName(name);
            this._context.RoomModels.Remove(Room);
            this._context.SaveChanges();
        }
        private RoomModel GetRoomByName(string name)
        {
            var Room = this._context.RoomModels.FirstOrDefault(x => x.Name == name);
            Room.Schedule = this._context.Schedules.Where(x => x.RoomModelId == Room.Id).ToList();
            if (Room == null)
            {
                throw new KeyNotFoundException("Room not found");
            }
            return Room;
        }

        //Done
        public void RegisterListOfRooms(IList<RoomModel> ListOfRooms)
        {
            this._context.RoomModels.AddRange(ListOfRooms);
            this._context.SaveChangesAsync();
        }

        //
        public void RoomAddSchedule(int id, Schedule schedule)
        {
            this._context.Schedules.Add(schedule);
            this._context.SaveChangesAsync();
        }


    }
}

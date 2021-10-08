using Assignment_2.Helpers;
using Assignment_2.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public void RegisterSingleRoom(RoomModel room)
        {
            _roomRepository.Register(room);
        }

        public void RegisterMultipleRooms(IList<RoomModel> listOfRooms)
        {
            _roomRepository.RegisterListOfRooms(listOfRooms);
        }

        public IList<CheckRoomResponse> FindAvailableRooms(DateTime checkDate, int capacity)
        {
            IList<CheckRoomResponse> checkRoomResponses = new List<CheckRoomResponse>();
            List<RoomModel> allModels = _roomRepository.GetAll().ToList();
            foreach (var room in allModels)
            {
                bool IsAvailableSlots = CheckRoomCapacity(room, capacity);
                if (IsAvailableSlots == true)
                {
                    IList<Schedule> freeTimeIntervals = TimeInterval(room, checkDate);
                    IList<FreeScheduleModel> freeScheduleModels = SplitTimeIntervals(freeTimeIntervals);
                    checkRoomResponses.Add(new CheckRoomResponse { Name = room.Name, Capacity = room.Capacity, Schedule = freeScheduleModels.ToList() });
                }

            }
            return checkRoomResponses;
        }
        //Done
        private bool CheckRoomCapacity(RoomModel roomModel, int expectedCapacity)
        {
            if (roomModel.Capacity >= expectedCapacity)
            {
                return true;
            }
            else
                return false;

        }
        //Populating The free Schedule and adding it to a list
        private DateTime MergeDateTime(DateTime day, TimeSpan time)
        {
            return new DateTime(day.Year, day.Month, day.Day, time.Hours, time.Minutes, 0);
        }
        private IList<FreeScheduleModel> SplitTimeIntervals(IList<Schedule> timeIntervalsList)
        {
            IList<FreeScheduleModel> result = new List<FreeScheduleModel>();
            foreach (var interval in timeIntervalsList)
            {
                DateTime start = interval.From;
                TimeSpan timeInterval = (interval.To - interval.From);
                long ticks = ((timeInterval.Hours * 72000) + (timeInterval.Minutes * 1200)) / 18000;
                for (int i = 0; i < ticks - 1; i++)
                {
                    result.Add(new FreeScheduleModel { From = start, To = start.AddMinutes(30) });
                    start = start.AddMinutes(15);
                }
            }
            return result;

        }
        public IList<Schedule> TimeInterval(RoomModel roomModel, DateTime dayOfBooking)
        {
            DateTime from = MergeDateTime(dayOfBooking, roomModel.AvailableFrom);
            DateTime to = MergeDateTime(dayOfBooking, roomModel.AvailableTo);
            Schedule free = new Schedule() { From = from, To = to };
            List<Schedule> schedules = roomModel.Schedule.OrderBy(x => x.To).ToList();
            IList<Schedule> freeslots = new List<Schedule>() { free };
            foreach (var sc in schedules)
            {
                freeslots = Merge(freeslots, sc);
            }
            return freeslots;
        }
        public IList<Schedule> Merge(IList<Schedule> freeslots, Schedule bookedSlot)
        {
            List<Schedule> result = new List<Schedule>();
            foreach (var sc in freeslots)
            {
                var newSlots = Merge(sc, bookedSlot);
                result.AddRange(newSlots);
            }
            return result;
        }
        private static IList<Schedule> Merge(Schedule freeSlot, Schedule bookedSlot)
        {
            if (bookedSlot.From >= freeSlot.From)
            {
                if (bookedSlot.From > freeSlot.To)
                {
                    return new List<Schedule>() { freeSlot };
                }
                if (bookedSlot.To < freeSlot.To)
                {
                    //split interval in 2 
                    return new List<Schedule>() { new Schedule() { From = freeSlot.From, To = bookedSlot.From },
                        new Schedule() {From =bookedSlot.To, To = freeSlot.To  } };
                }
                else
                {
                    return new List<Schedule>() { new Schedule() { From = freeSlot.From, To = bookedSlot.From } };
                }
            }
            else
            {
                if (bookedSlot.To <= freeSlot.From)
                {
                    return new List<Schedule>() { freeSlot };
                }
                if (bookedSlot.To >= freeSlot.To)
                {
                    return new List<Schedule>();
                }
                else
                {
                    return new List<Schedule>() { new Schedule() { From = bookedSlot.To, To = freeSlot.To } };
                }

            }
        }
    }
}

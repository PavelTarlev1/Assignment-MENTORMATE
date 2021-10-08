using Assignment_2.Model;
using Assignment_2.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Assignment_2.Controllers
{
    
    [Route("rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;
        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this._roomService = roomService;
            this._mapper = mapper;
        }
        //Done
        [HttpPost("register-multiple")]
        public IActionResult RegisterMultipleRooms(List<RegisterRequest> models)
        {
            var rooms = _mapper.Map<IList<RegisterRequest>, IList<RoomModel>>(models);
            _roomService.RegisterMultipleRooms(rooms);
            return Ok(new { message = "Added successful" });
        }

        //Done
        [HttpPost("register")]
        public IActionResult RegisterSingle(RegisterRequest room)
        {
            var rooModel = _mapper.Map<RoomModel>(room);
            _roomService.RegisterSingleRoom(rooModel);
            return Ok(new { message = "Added successful" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(); 
        }

        [HttpGet("availability")]
        public IActionResult FindAvailablerooms(CheckRoomRequest room)
        {
            //var checkRoom = _mapper.Map<CheckRoom>(room);
            var returnList =_roomService.FindAvailableRooms(room.CheckRoomDate , room.Capacity);
            return Ok(returnList);
        }
        
    }
}

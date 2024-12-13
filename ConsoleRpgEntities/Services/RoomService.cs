using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleRpgEntities.Models.Characters;
using ConsoleRpgEntities.Models.Rooms;
using ConsoleRpgEntities.Repositories;

namespace ConsoleRpgEntities.Services
{
    public class RoomService
    {
        private readonly IOutputService _outputService;
        private readonly RoomRepository _roomRepository;

        public RoomService(IOutputService outputService, RoomRepository roomRepository)
        {
            _outputService = outputService;
            _roomRepository = roomRepository;
        }

        public void ListRoomNames(List<Room> rooms)
        {
            _outputService.WriteLine("Rooms:");
            foreach (var room in rooms)
            {
                _outputService.WriteLine($"{room.Name}");
            }
        }

        //Display room name
        public void DisplayRoomName(Room room)
        {
            _outputService.WriteLine($"{room.Name}");
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();
        }

        // Create new Room
        public void CreateRoom()
        {
            var name = "BlankName";
            var invalidName = true;
            while (invalidName == true)
            {
                Console.WriteLine("Please Enter Room Name Or Enter E To Exit:");
                name = Console.ReadLine();
                if (name != "BlankName" )
                {
                    invalidName = false;
                }
                else if (_roomRepository.GetAllRooms().Any(r => r.Name.ToLower().Equals(name.ToLower())))
                {
                    Console.WriteLine("That Room Name Already Exists And Cannot Be Duplicated.");
                }

            }
            //  Creating exit option before creating new player
            if (name.ToLower() == "e")
            {
                Console.WriteLine("Exiting Create Room.");
            }
            // Creating new room
            else
            {
                var description = "A dark Room With no Light to See Anything.";
                var westRoomId = _roomRepository.GetMaxID();
                var westRoom = _roomRepository.GetRoomById(westRoomId);


                Console.WriteLine("Enter the description of the room:");
                description = Console.ReadLine();

                Room room = new Room
                {
                    Name = name,
                    Description = description,
                    West = westRoom
                };
                _roomRepository.AddRoom(room);

                // Update the west room to have the new room to the east
                var eastRoomId = _roomRepository.GetMaxID();
                westRoom.East = _roomRepository.GetRoomById(eastRoomId);
                _roomRepository.UpdateRoom(westRoom);
                
                Console.WriteLine($"Room {room.Name} Created And Is Located To The East Of {westRoom.Name}.");
            }
            Console.WriteLine($"Press Enter To Continue.");
            var pauseForEnter = Console.ReadLine();

        }
     
        // 


        //  Display room details that player is in
        public void DisplayRoomDetails(Room room, Player player)
        {
            _outputService.WriteLine($"{player.Name} has Entered {room.Name}: {room.Description}");

            if(room.North !=null)
            {
                _outputService.WriteLine($"To The North Is {room.North.Name}");
            }
            if (room.South != null)
            {
                _outputService.WriteLine($"To The South Is {room.South.Name}");
            }
            if (room.East != null)
            {
                _outputService.WriteLine($"To The East Is {room.East.Name}");
            }
            if (room.West != null)
            {
                _outputService.WriteLine($"To The West Is {room.West.Name}");
            }
        }















    }
}

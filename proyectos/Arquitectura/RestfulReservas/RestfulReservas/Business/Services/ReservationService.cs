using Microsoft.JSInterop.Infrastructure;
using RestfulReservas.Business.Entitites;
using RestfulReservas.Data.DTOs;
using RestfulReservas.Data.Repositories;

namespace RestfulReservas.Business.Services
{
    public class ReservationService : IReservationService
    {
        private readonly UserRepository _userRepo;
        private readonly ReservationRepository _reservationRepository;
        private readonly RoomRepository _roomRepository;

        public ReservationService(UserRepository userRepository, 
            ReservationRepository reservationRepository, 
            RoomRepository roomRepository) { 
            _userRepo = userRepository;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public int Create(ReservationDTO dto)
        {
            //Search user
            var user = _userRepo.GetById(dto.UserId);
            if (user == null)
                throw new Exception($"El usuario {dto.UserId} no existe");

            //Search room
            var room =_roomRepository.GetById(dto.RoomId);
            if (room.RoomId ==null)
                throw new Exception($"El room {dto.RoomId} no existe");

            if (!room.Available)
                throw new Exception($"la habitación {dto.RoomId} no esta disponible");

            //Create reservation
            Reservation reservation=new() { 
                UserId=user.Id,
                RoomId=room.Id,
                Begin=dto.Begin,
                End=dto.End,
            };

            int result=_reservationRepository.Insert(reservation);

            //Update room not available
            room.Available = false;

            _roomRepository.Update(room);

            return result;


        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }


        public List<Room> GetAvailableRooms() {
            return _roomRepository.GetAvailable();
        }

    }
}

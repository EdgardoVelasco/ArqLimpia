using RestfulReservas.Business.Entitites;
using RestfulReservas.Data.DTOs;

namespace RestfulReservas.Business.Services
{
    public interface IReservationService
    {
        public List<Reservation> GetAll();

        public int Create(ReservationDTO dto);

        public List<Room> GetAvailableRooms();
    }
}

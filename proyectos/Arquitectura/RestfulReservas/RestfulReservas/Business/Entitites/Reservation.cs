namespace RestfulReservas.Business.Entitites
{
    public class Reservation
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public Reservation(int userId, int roomId, DateTime begin, DateTime end)
        {
            UserId = userId;
            RoomId = roomId;
            Begin = begin;
            End = end;
        }

        public Reservation()
        {
        }
    }
}

namespace RestfulReservas.Data.DTOs
{
    /*Esta clase nos sirve para transportar datos
     entre el controlador y bussiness*/
    public class ReservationDTO
    {
        public int UserId{ get; set; }
        public int RoomId { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }

        public override string ToString() => 
            $"DTO [{UserId}, {RoomId}, {Begin}, {End}]";
        

    }
}

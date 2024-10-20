namespace GestionTransacciones.Models
{
    public class Transaccion
    {
        public string IdTransaccion { get; set; }
        public string Tipo { get; set; }  // "deposito", "retiro"
        public decimal Monto { get; set; }
        public decimal SaldoRestante { get; set; }

        public Transaccion(string tipo, decimal monto, decimal saldoRestante)
        {
            IdTransaccion = Guid.NewGuid().ToString();
            Tipo = tipo;
            Monto = monto;
            SaldoRestante = saldoRestante;
        }
    }
}
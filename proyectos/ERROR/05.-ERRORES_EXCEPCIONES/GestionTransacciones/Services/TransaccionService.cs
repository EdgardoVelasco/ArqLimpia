using System;
using GestionTransacciones.Interfaces;
using GestionTransacciones.Models;

namespace GestionTransacciones.Services
{
    public class TransaccionService : ITransaccionService
    {
        private decimal _saldo;

        public TransaccionService()
        {
            _saldo = 0;
        }

        public Transaccion RealizarDeposito(decimal monto)
        {
            if (monto <= 0)
            {
                throw new InvalidOperationException("El monto debe ser mayor a cero.");
            }

            _saldo += monto;
            return new Transaccion("deposito", monto, _saldo);
        }

        public Transaccion RealizarRetiro(decimal monto)
        {
            if (monto <= 0)
            {
                throw new InvalidOperationException("El monto debe ser mayor a cero.");
            }

            if (monto > _saldo)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar el retiro.");
            }

            _saldo -= monto;
            return new Transaccion("retiro", monto, _saldo);
        }

        public decimal ObtenerSaldo()
        {
            return _saldo;
        }
    }
}
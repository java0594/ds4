using Laboratorio8._2;
using System;

namespace Laboratorio8._2
    {
    internal class Program
        {
        static void Main(string[] args)
            {
        const string CUENTA = "100";

        Cuenta cuenta = new Cuenta(CUENTA);
        CuentaCorriente cuentaCorriente = new CuentaCorriente(CUENTA);
        CuentaAhorro cuentaAhorro = new CuentaAhorro(CUENTA);
        cuenta.CalcularIntereses();
        cuentaCorriente.CalcularIntereses();
        cuentaAhorro.CalcularIntereses();
    }
}
}

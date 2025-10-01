using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8._2
{
    public class CuentaAhorro : Cuenta
    {
    public CuentaAhorro(string prmtIdCuenta) :base(prmtIdCuenta)
        {
        }

        public override void CalcularIntereses()
        {
            System.Console.WriteLine("CuentaAhorro.CalcularIntereses() efectuando para " + "la cuenta {0}", getIdCuenta());
        }
    }
}

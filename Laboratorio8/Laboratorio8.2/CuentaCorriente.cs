using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8._2
{
    public class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string prmtIdCuenta)
            : base(prmtIdCuenta)
        {
        }

        public override void CalcularIntereses()
        { 
        System.Console.WriteLine("CuentaCorriente.CalcularIntereses() efectuando para " + "la cuenta {0}", getIdCuenta());
               
                }
    }
}

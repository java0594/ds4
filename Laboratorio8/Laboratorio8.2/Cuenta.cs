using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8._2
{
    public class Cuenta
    {
        private string idCuenta;

        public Cuenta(string prmtIdCuenta)
        {
            this.idCuenta = prmtIdCuenta;
            System.Console.WriteLine(
    "Constructor Clase Base para cuenta {0}", prmtIdCuenta);
            ;
        }

        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine("Cuenta.CalcularIntereses() efectuando para la cuenta {0}", this.idCuenta);
        }

        public string getIdCuenta()
                    {
            return this.idCuenta;
        }
    }
}

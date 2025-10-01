using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio8._8
{
    class ClaseConcreta1 : ClaseAbstracta
    {
        protected override string tomarValor()
        {
            return "ClaseConcretal1";
        }
        public override string prefixValor(string prefix)
        {
            return $"{prefix}ClaseConcreta1";
        }
    }
}

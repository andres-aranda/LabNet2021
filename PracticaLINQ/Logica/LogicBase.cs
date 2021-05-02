using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public abstract class LogicBase
    {
        protected readonly BaseNorthWind context;

        protected LogicBase()
        {
            context = new BaseNorthWind();
        }

        
    }
}

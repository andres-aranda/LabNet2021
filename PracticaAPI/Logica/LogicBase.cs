using Datos;

namespace Logica
{
    public abstract class LogicBase
    {
        protected readonly BaseNorthWind DbContext;

        protected LogicBase()
        {
            DbContext = new BaseNorthWind();
        }


    }
}

namespace LAB_1_POO
{
    public class Avion : ITransporte
    {
        public Avion(string descripcion, int cantidadPasajeros) 
        {
            this.CantidadPasajeros = cantidadPasajeros;
            this.Descripcion = descripcion;
        }

        public int CantidadPasajeros { get; }

        public string Descripcion { get; }

        public  string Avanzar()
        {
            return $"-+-";
        }

        public  string Detenerse()
        {
            return $" Hemos aterrizado.";
        }
    }
}

namespace LAB_1_POO
{
    public class Avion : Transporte
    {
        public Avion(string descripcion, int cantidadPasajeros) : base(descripcion, cantidadPasajeros)
        {

        }

        public override string Avanzar()
        {
            return $"-+-";
        }

        public override string Detenerse()
        {
            return $" Hemos aterrizado.";
        }
    }
}

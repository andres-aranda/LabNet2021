namespace LAB_1_POO
{
    class Automovil : Transporte
    {
        public Automovil(string descripcion, int cantidadPasajeros) : base(descripcion, cantidadPasajeros)
        {

        }

        public override string Avanzar()
        {
            return $".";
        }

        public override string Detenerse()
        {
            return $" Hemos estacionado.";
        }
    }
}

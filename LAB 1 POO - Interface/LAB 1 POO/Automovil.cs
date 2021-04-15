namespace LAB_1_POO
{
    class Automovil : ITransporte
    {
        public Automovil(string descripcion, int cantidadPasajeros)
        {
            this.CantidadPasajeros = cantidadPasajeros;
            this.Descripcion = descripcion;
        }

        public int CantidadPasajeros { get; }

        public string Descripcion { get; }

        public string Avanzar()
        {
            return $".";
        }

        public string Detenerse()
        {
            return $" Hemos estacionado.";
        }
    }
}

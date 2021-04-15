namespace LAB_1_POO
{
    public interface ITransporte
    {

        int CantidadPasajeros { get; }
        string Descripcion { get; }

        string Avanzar();

        string Detenerse();
    }
}

﻿namespace LAB_1_POO
{
    public abstract class Transporte
    {
        //Variables en nivel protected perpiten acceso a las clases hijas evitando redundancia
        protected int cantidadPasajeros;
        protected string descripcion;

        protected Transporte(string descripcion, int cantidadPasajeros)
        {
            this.cantidadPasajeros = cantidadPasajeros;
            this.descripcion = descripcion;
        }
        public int CantidadPasajeros => cantidadPasajeros;
        public string Descripcion => descripcion;

        public abstract string Avanzar();
        public abstract string Detenerse();
    }
}

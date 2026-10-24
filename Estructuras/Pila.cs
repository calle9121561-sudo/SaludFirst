using System;

namespace SaludFirst.Estructuras
{
    public class NodoPila
    {
        public string Dato { get; set; }
        public NodoPila? Siguiente { get; set; }

        public NodoPila(string dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    public class Pila
    {
        private NodoPila? cima;
        private int contador;

        public int Contador => contador;

        public void Apilar(string dato)
        {
            NodoPila nuevo = new NodoPila(dato);
            nuevo.Siguiente = cima;
            cima = nuevo;
            contador++;
        }

        public string? Desapilar()
        {
            if (cima == null) return null;
            string dato = cima.Dato;
            cima = cima.Siguiente;
            contador--;
            return dato;
        }

        public string? VerCima()
        {
            if (cima == null) return null;
            return cima.Dato;
        }

        public bool EstaVacia() => cima == null;
    }
}
using System;

namespace SaludFirst.Estructuras
{
    public class NodoDoble<T> where T : class
    {
        public T Dato { get; set; }
        public NodoDoble<T>? Siguiente { get; set; }
        public NodoDoble<T>? Anterior { get; set; }

        public NodoDoble(T dato)
        {
            Dato = dato;
            Siguiente = null;
            Anterior = null;
        }
    }

    public class ListaDoble<T> where T : class
    {
        private NodoDoble<T>? cabeza;
        private NodoDoble<T>? cola;
        private int contador;

        public int Contador => contador;

        public void Agregar(T dato)
        {
            NodoDoble<T> nuevo = new NodoDoble<T>(dato);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola!.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            contador++;
        }

        public void Mostrar()
        {
            NodoDoble<T>? actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine(actual.Dato);
                actual = actual.Siguiente;
            }
        }

        public void MostrarInverso(Action<T> accionMostrar)
        {
            NodoDoble<T>? actual = cola;
            while (actual != null)
            {
                accionMostrar(actual.Dato);
                actual = actual.Anterior;
            }
        }

        public T? BuscarRecursivo(NodoDoble<T>? nodo, Func<T, bool> condicion)
        {
            if (nodo == null) return default;
            if (condicion(nodo.Dato)) return nodo.Dato;
            return BuscarRecursivo(nodo.Siguiente, condicion);
        }

        public T? Buscar(Func<T, bool> condicion)
            => BuscarRecursivo(cabeza, condicion);

        private NodoDoble<T>? cursor;
        public void IniciarNavegacion() => cursor = cabeza;
        public T? Avanzar()
        {
            if (cursor?.Siguiente != null)
            {
                cursor = cursor.Siguiente;
                return cursor.Dato;
            }
            return cursor != null ? cursor.Dato : default;
        }

        public T? Retroceder()
        {
            if (cursor?.Anterior != null)
            {
                cursor = cursor.Anterior;
                return cursor.Dato;
            }
            return cursor != null ? cursor.Dato : default;
        }
    }
}
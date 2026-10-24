namespace SaludFirst.Estructuras;

public class NodoSimple<T>
{
    public T Dato;
    public NodoSimple<T>? Siguiente;

    public NodoSimple(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

/// <summary>
/// LISTA SIMPLEMENTE ENLAZADA (CV2): registro de pacientes atendidos en el
/// día. Se agrega al final y se recorre en un solo sentido (cronológico).
/// </summary>
public class ListaSimple<T>
{
    private NodoSimple<T>? cabeza;
    private int contador;

    public bool EstaVacia() => cabeza == null;
    public int Contar() => contador;

    public void AgregarAlFinal(T dato)
    {
        NodoSimple<T> nuevo = new NodoSimple<T>(dato);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            NodoSimple<T> actual = cabeza;
            while (actual.Siguiente != null)
                actual = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
        contador++;
    }

    public bool Contiene(T dato)
    {
        NodoSimple<T>? actual = cabeza;
        while (actual != null)
        {
            if (actual.Dato!.Equals(dato)) return true;
            actual = actual.Siguiente;
        }
        return false;
    }

    public void Mostrar(Action<T> accionMostrar)
    {
        if (cabeza == null)
        {
            Console.WriteLine("    (sin registros)");
            return;
        }
        NodoSimple<T>? actual = cabeza;
        while (actual != null)
        {
            accionMostrar(actual.Dato);
            actual = actual.Siguiente;
        }
    }
}
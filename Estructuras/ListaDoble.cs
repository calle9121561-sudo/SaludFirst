namespace SaludFirst.Estructuras;

public class NodoDoble<T>
{
    public T Dato;
    public NodoDoble<T>? Anterior;
    public NodoDoble<T>? Siguiente;

    public NodoDoble(T dato)
    {
        Dato = dato;
        Anterior = null;
        Siguiente = null;
    }
}

/// <summary>
/// LISTA DOBLEMENTE ENLAZADA (CV2): historial médico de un paciente.
/// Permite navegar hacia atrás y hacia adelante entre atenciones.
/// 
/// RECURSIVIDAD (CV1): el método BuscarRecursivo recorre la lista
/// llamándose a sí mismo, sin bucles.
/// </summary>
public class ListaDoble<T>
{
    private NodoDoble<T>? cabeza;
    private NodoDoble<T>? cola;
    private int contador;

    public bool EstaVacia() => cabeza == null;
    public int Contar() => contador;

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
            nuevo.Anterior = cola;
            cola!.Siguiente = nuevo;
            cola = nuevo;
        }
        contador++;
    }

    public void MostrarCronologico(Action<T> accionMostrar)
    {
        if (cabeza == null) { Console.WriteLine("    (historial vacío)"); return; }
        NodoDoble<T>? actual = cabeza;
        while (actual != null)
        {
            accionMostrar(actual.Dato);
            actual = actual.Siguiente;
        }
    }

    public void MostrarInverso(Action<T> accionMostrar)
    {
        if (cola == null) { Console.WriteLine("    (historial vacío)"); return; }
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
    public T? Actual() => cursor?.Dato;
    public T? Avanzar()
    {
        if (cursor?.Siguiente != null)
        {
            cursor = cursor.Siguiente;
            return cursor.Dato;
        }
        return default;
    }
    public T? Retroceder()
    {
        if (cursor?.Anterior != null)
        {
            cursor = cursor.Anterior;
            return cursor.Dato;
        }
        return default;
    }
}
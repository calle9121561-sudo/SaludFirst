namespace SaludFirst.Estructuras;

public class NodoPila<T>
{
    public T Dato;
    public NodoPila<T>? Siguiente;

    public NodoPila(T dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

public class Pila<T>
{
    private NodoPila<T>? tope;
    private int contador;

    public bool EstaVacia() => tope == null;
    public int Contar() => contador;

    public void Push(T dato)
    {
        NodoPila<T> nuevo = new NodoPila<T>(dato);
        nuevo.Siguiente = tope;
        tope = nuevo;
        contador++;
    }

    public T? Pop()
    {
        if (tope == null) return default;
        T dato = tope.Dato;
        tope = tope.Siguiente;
        contador--;
        return dato;
    }

    public T? Peek() => tope?.Dato;
}

public class AccionMedica
{
    public string Descripcion { get; set; }
    public Action Revertir { get; set; }

    public AccionMedica(string descripcion, Action revertir)
    {
        Descripcion = descripcion;
        Revertir = revertir;
    }
}
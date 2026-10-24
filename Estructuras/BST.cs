namespace SaludFirst.Estructuras;

public class NodoArbol<T> where T : IComparable<T>
{
    public T Dato;
    public NodoArbol<T>? Izquierdo;
    public NodoArbol<T>? Derecho;

    public NodoArbol(T dato)
    {
        Dato = dato;
        Izquierdo = null;
        Derecho = null;
    }
}

public class BST<T> where T : IComparable<T>
{
    private NodoArbol<T>? raiz;

    public void Insertar(T valor) => raiz = InsertarRec(raiz, valor);

    private NodoArbol<T>? InsertarRec(NodoArbol<T>? nodo, T valor)
    {
        if (nodo == null) return new NodoArbol<T>(valor);
        int cmp = valor.CompareTo(nodo.Dato);
        if (cmp < 0) nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
        else if (cmp > 0) nodo.Derecho = InsertarRec(nodo.Derecho, valor);
        return nodo;
    }

    public T? Buscar(T valor) => BuscarRec(raiz, valor);

    private T? BuscarRec(NodoArbol<T>? nodo, T valor)
    {
        if (nodo == null) return default;
        int cmp = valor.CompareTo(nodo.Dato);
        if (cmp == 0) return nodo.Dato;
        if (cmp < 0) return BuscarRec(nodo.Izquierdo, valor);
        return BuscarRec(nodo.Derecho, valor);
    }

    public bool Existe(T valor) => Buscar(valor) != null;

    public void Inorden(Action<T> accionMostrar) => InordenRec(raiz, accionMostrar);

    private void InordenRec(NodoArbol<T>? nodo, Action<T> accionMostrar)
    {
        if (nodo == null) return;
        InordenRec(nodo.Izquierdo, accionMostrar);
        accionMostrar(nodo.Dato);
        InordenRec(nodo.Derecho, accionMostrar);
    }

    public int ContarNodos() => ContarRec(raiz);

    private int ContarRec(NodoArbol<T>? nodo)
    {
        if (nodo == null) return 0;
        return 1 + ContarRec(nodo.Izquierdo) + ContarRec(nodo.Derecho);
    }

    public void Eliminar(T valor) => raiz = EliminarRec(raiz, valor);

    private NodoArbol<T>? EliminarRec(NodoArbol<T>? nodo, T valor)
    {
        if (nodo == null) return null;
        int cmp = valor.CompareTo(nodo.Dato);
        if (cmp < 0) nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor);
        else if (cmp > 0) nodo.Derecho = EliminarRec(nodo.Derecho, valor);
        else
        {
            if (nodo.Izquierdo == null) return nodo.Derecho;
            if (nodo.Derecho == null) return nodo.Izquierdo;
            NodoArbol<T> sucesor = EncontrarMinimo(nodo.Derecho);
            nodo.Dato = sucesor.Dato;
            nodo.Derecho = EliminarRec(nodo.Derecho, sucesor.Dato);
        }
        return nodo;
    }

    private NodoArbol<T> EncontrarMinimo(NodoArbol<T> nodo)
    {
        while (nodo.Izquierdo != null) nodo = nodo.Izquierdo;
        return nodo;
    }
}
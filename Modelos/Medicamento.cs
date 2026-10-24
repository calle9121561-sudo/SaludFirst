namespace SaludFirst.Modelos;

/// <summary>
/// El medicamento implementa IComparable para que el ÁRBOL BINARIO DE
/// BÚSQUEDA (CV3) pueda ordenarlo por código de forma automática.
/// </summary>
public class Medicamento : IComparable<Medicamento>
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Medicamento(string codigo, string nombre, double precio, int stock)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    /// <summary>
    /// Ordenamiento por código: define la estructura del BST.
    /// </summary>
    public int CompareTo(Medicamento? otro)
    {
        if (otro == null) return 1;
        return string.Compare(Codigo, otro.Codigo, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
        => $"{Codigo} | {Nombre,-22} | Bs {Precio,7:F2} | Stock: {Stock}";
}
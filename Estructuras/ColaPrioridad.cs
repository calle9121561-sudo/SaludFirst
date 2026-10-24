using SaludFirst.Modelos;

namespace SaludFirst.Estructuras;

/// <summary>
/// NODO de la cola de prioridad (memoria dinámica, CV1).
/// </summary>
public class NodoPaciente
{
    public Paciente Dato;
    public NodoPaciente? Siguiente;

    public NodoPaciente(Paciente dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

/// <summary>
/// COLA DE PRIORIDAD (CV1): los pacientes con prioridad ALTA se atienden
/// primero. Dentro de una misma prioridad se respeta el orden de llegada
/// (FIFO estable), tal como ocurre en un centro de salud real.
/// </summary>
public class ColaPrioridad
{
    private NodoPaciente? frente;
    private int contador;

    public bool EstaVacia() => frente == null;
    public int Contar() => contador;

    public void Encolar(Paciente paciente)
    {
        NodoPaciente nuevo = new NodoPaciente(paciente);

        if (frente == null)
        {
            frente = nuevo;
        }
        else if (nuevo.Dato.Prioridad > frente.Dato.Prioridad)
        {
            nuevo.Siguiente = frente;
            frente = nuevo;
        }
        else
        {
            NodoPaciente actual = frente;
            while (actual.Siguiente != null &&
                   actual.Siguiente.Dato.Prioridad >= paciente.Prioridad)
            {
                actual = actual.Siguiente;
            }
            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
        }
        contador++;
    }

    public Paciente? Desencolar()
    {
        if (frente == null) return null;
        Paciente paciente = frente.Dato;
        frente = frente.Siguiente;
        contador--;
        return paciente;
    }

    public Paciente? VerFrente() => frente?.Dato;

    /// <summary>
    /// Muestra la fila completa sin modificarla (útil para el reporte diario).
    /// </summary>
    public void MostrarFila()
    {
        if (frente == null)
        {
            Console.WriteLine("    (fila vacía)");
            return;
        }
        NodoPaciente? actual = frente;
        int posicion = 1;
        while (actual != null)
        {
            Console.WriteLine($"    {posicion}. {actual.Dato}");
            actual = actual.Siguiente;
            posicion++;
        }
    }
}
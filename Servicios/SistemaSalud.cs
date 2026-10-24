using SaludFirst.Estructuras;
using SaludFirst.Modelos;

namespace SaludFirst.Servicios;

public class SistemaSalud
{
    private ColaPrioridad fila = new ColaPrioridad();
    private ListaSimple<Paciente> atendidos = new ListaSimple<Paciente>();
    private BST<Medicamento> catalogo = new BST<Medicamento>();
    private Pila<AccionMedica> historialAcciones = new Pila<AccionMedica>();
    private Triaje triaje = new Triaje();
    private Dictionary<string, ListaDoble<Atencion>> historiales = new();
    private int contadorTurnos = 0;

    public Paciente RegistrarPaciente(string nombre, string ci, int edad, string sintoma)
    {
        Prioridad prioridad = triaje.Clasificar(sintoma);
        contadorTurnos++;
        Paciente paciente = new Paciente(nombre, ci, edad, sintoma, prioridad, contadorTurnos);
        fila.Encolar(paciente);
        return paciente;
    }

    public Paciente? AtenderSiguiente()
    {
        Paciente? paciente = fila.Desencolar();
        if (paciente == null) return null;
        atendidos.AgregarAlFinal(paciente);
        if (!historiales.ContainsKey(paciente.Ci))
            historiales[paciente.Ci] = new ListaDoble<Atencion>();
        return paciente;
    }

    public ColaPrioridad Fila => fila;

    public void RegistrarAtencion(string ci, string diagnostico, string medicamento)
    {
        if (!historiales.TryGetValue(ci, out var historial))
        {
            Console.WriteLine("    ⚠ El paciente no tiene historial abierto.");
            return;
        }
        historial.Agregar(new Atencion(diagnostico, medicamento));
        Console.WriteLine($"    📝 Atención registrada para {ci}.");
    }

    public void VerHistorial(string ci, bool inverso = false)
    {
        if (!historiales.TryGetValue(ci, out var historial) || historial.EstaVacia())
        {
            Console.WriteLine("    (sin atenciones registradas)");
            return;
        }
        if (inverso)
            historial.MostrarInverso(a => Console.WriteLine($"    {a}"));
        else
            historial.MostrarCronologico(a => Console.WriteLine($"    {a}"));
    }

    public Atencion? BuscarEnHistorial(string ci, string palabraClave)
    {
        if (!historiales.TryGetValue(ci, out var historial)) return null;
        string clave = palabraClave.ToLower();
        return historial.Buscar(a =>
            a.Diagnostico.ToLower().Contains(clave) ||
            a.MedicamentoRecetado.ToLower().Contains(clave));
    }

    public void CargarCatalogoInicial()
    {
        catalogo.Insertar(new Medicamento("MED-010", "Paracetamol",   15.00, 120));
        catalogo.Insertar(new Medicamento("MED-020", "Ibuprofeno",    25.50,  80));
        catalogo.Insertar(new Medicamento("MED-030", "Amoxicilina",   45.00,  60));
        catalogo.Insertar(new Medicamento("MED-040", "Omeprazol",     30.00,  45));
        catalogo.Insertar(new Medicamento("MED-050", "Loratadina",    18.50,  70));
        catalogo.Insertar(new Medicamento("MED-060", "Metformina",    55.00,  35));
        catalogo.Insertar(new Medicamento("MED-070", "Salbutamol",    90.00,  25));
        catalogo.Insertar(new Medicamento("MED-080", "Sertralina",   120.00,  20));
    }

    public void AgregarMedicamento(string codigo, string nombre, double precio, int stock)
        => catalogo.Insertar(new Medicamento(codigo, nombre, precio, stock));

    public Medicamento? BuscarMedicamento(string codigo)
        => catalogo.Buscar(new Medicamento(codigo, "", 0, 0));

    public void MostrarCatalogo()
        => catalogo.Inorden(m => Console.WriteLine($"    {m}"));

    public void RegistrarAccionDeshacible(string descripcion, AccionMedica accion)
    {
        historialAcciones.Push(accion);
        Console.WriteLine($"    ✏ Acción registrada: {descripcion}");
    }

    public string? DeshacerUltimaAccion()
    {
        if (historialAcciones.EstaVacia()) return null;
        AccionMedica accion = historialAcciones.Pop()!;
        accion.Revertir();
        return accion.Descripcion;
    }

    public int AccionesPendientesDeDeshacer() => historialAcciones.Contar();

    public void GenerarReporteDiario()
    {
        Console.WriteLine("\n╔══════════════════════════════════════════════╗");
        Console.WriteLine("║    REPORTE DIARIO — CENTRO DE SALUD          ║");
        Console.WriteLine("╠══════════════════════════════════════════════╣");
        Console.WriteLine($"║ Atendidos hoy : {atendidos.Contar()}");
        Console.WriteLine($"║ En espera     : {fila.Contar()}");
        Console.WriteLine($"║ Turnos emitidos: {contadorTurnos}");
        Console.WriteLine("╠══════════════════════════════════════════════╣");
        Console.WriteLine("║ PACIENTES ATENDIDOS (lista simple, CV2):");
        atendidos.Mostrar(p => Console.WriteLine($"║    {p}"));
        Console.WriteLine("╠══════════════════════════════════════════════╣");
        Console.WriteLine("║ PACIENTES EN ESPERA (cola de prioridad, CV1):");
        fila.MostrarFila();
        Console.WriteLine("╚══════════════════════════════════════════════╝");
    }
}
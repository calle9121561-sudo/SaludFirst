namespace SaludFirst.Modelos;

/// <summary>
/// Nivel de urgencia asignado por el triaje.
/// </summary>
public enum Prioridad
{
    Baja = 1,
    Media = 2,
    Alta = 3
}

/// <summary>
/// MEMORIA DINÁMICA (CV1): cada paciente se crea con 'new' en tiempo de
/// ejecución, según la llegada real de personas al centro de salud.
/// </summary>
public class Paciente
{
    public string Nombre { get; set; }
    public string Ci { get; set; }
    public int Edad { get; set; }
    public string Sintoma { get; set; }
    public Prioridad Prioridad { get; set; }
    public DateTime HoraLlegada { get; set; }
    public int Turno { get; set; }

    public Paciente(string nombre, string ci, int edad, string sintoma,
                    Prioridad prioridad, int turno)
    {
        Nombre = nombre;
        Ci = ci;
        Edad = edad;
        Sintoma = sintoma;
        Prioridad = prioridad;
        Turno = turno;
        HoraLlegada = DateTime.Now;
    }

    public override string ToString()
        => $"[Turno {Turno}] {Nombre} (CI: {Ci}, {Edad} años) — {Sintoma} — {Prioridad}";
}
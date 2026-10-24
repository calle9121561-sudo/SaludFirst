namespace SaludFirst.Modelos;

/// <summary>
/// Registro de una atención médica. Se almacena en la LISTA DOBLE
/// que conforma el historial del paciente (CV2).
/// </summary>
public class Atencion
{
    public DateTime Fecha { get; set; }
    public string Diagnostico { get; set; }
    public string MedicamentoRecetado { get; set; }

    public Atencion(string diagnostico, string medicamentoRecetado)
    {
        Fecha = DateTime.Now;
        Diagnostico = diagnostico;
        MedicamentoRecetado = medicamentoRecetado;
    }

    public override string ToString()
        => $"{Fecha:dd/MM/yyyy HH:mm} | Dx: {Diagnostico} | Rx: {MedicamentoRecetado}";
}
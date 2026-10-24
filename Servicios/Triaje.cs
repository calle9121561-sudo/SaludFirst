using SaludFirst.Modelos;

namespace SaludFirst.Servicios;

public class Triaje
{
    private static readonly string[] SintomasAlta =
    {
        "dolor torácico", "desmayo", "hemorragia", "dificultad respiratoria",
        "convulsión", "accidente"
    };
    private static readonly string[] SintomasMedia =
    {
        "fiebre alta", "fractura", "vómitos persistentes", "dolor abdominal intenso",
        "herida profunda"
    };
    private static readonly string[] SintomasBaja =
    {
        "resfriado", "dolor de cabeza", "gripe", "control", "certificado",
        "malestar leve"
    };

    public Prioridad Clasificar(string sintoma)
    {
        string s = sintoma.Trim().ToLower();
        if (ContieneAlguno(s, SintomasAlta))  return Prioridad.Alta;
        if (ContieneAlguno(s, SintomasMedia)) return Prioridad.Media;
        if (ContieneAlguno(s, SintomasBaja))  return Prioridad.Baja;
        return Prioridad.Media;
    }

    private bool ContieneAlguno(string sintoma, string[] catalogo)
    {
        foreach (string clave in catalogo)
        {
            if (sintoma.Contains(clave)) return true;
        }
        return false;
    }

    public void MostrarCriterios()
    {
        Console.WriteLine("\n    🔴 ALTA : " + string.Join(", ", SintomasAlta));
        Console.WriteLine("    🟠 MEDIA: " + string.Join(", ", SintomasMedia));
        Console.WriteLine("    🟢 BAJA : " + string.Join(", ", SintomasBaja));
    }
}
using System.Text;
using SaludFirst.Servicios;
using SaludFirst.Modelos;

Console.OutputEncoding = Encoding.UTF8;
SistemaSalud sistema = new SistemaSalud();
sistema.CargarCatalogoInicial();
int opcion = 0;

do
{
    Console.Clear();
    Console.WriteLine("╔══════════════════════════════════════════════╗");
    Console.WriteLine("║   🏥 SaludFirst — Triaje Inteligente UPDS    ║");
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.WriteLine("║ 1. Registrar paciente (con triaje automático)║");
    Console.WriteLine("║ 2. Ver fila de espera                        ║");
    Console.WriteLine("║ 3. Atender siguiente paciente                ║");
    Console.WriteLine("║ 4. Registrar atención médica (historial)     ║");
    Console.WriteLine("║ 5. Ver historial                             ║");
    Console.WriteLine("║ 6. Buscar en historial                       ║");
    Console.WriteLine("║ 7. Catálogo de medicamentos                  ║");
    Console.WriteLine("║ 8. Buscar medicamento por código             ║");
    Console.WriteLine("║ 9. Deshacer última acción                    ║");
    Console.WriteLine("║ 10. Reporte diario                           ║");
    Console.WriteLine("║ 0. Salir                                     ║");
    Console.WriteLine("╚══════════════════════════════════════════════╝");
    Console.Write("\n  Opción: ");
    opcion = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine();

    switch (opcion)
    {
        case 1:
            Console.Write("  Nombre: ");
            string nombre = Console.ReadLine() ?? "";
            Console.Write("  CI: ");
            string ci = Console.ReadLine() ?? "";
            Console.Write("  Edad: ");
            int edad = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("  Síntoma: ");
            string sintoma = Console.ReadLine() ?? "";
            Paciente p = sistema.RegistrarPaciente(nombre, ci, edad, sintoma);
            Console.WriteLine($"\n  ✅ Registrado → Turno {p.Turno} | Prioridad: {p.Prioridad}");
            break;

        case 2:
            Console.WriteLine("  🕐 Fila de espera (primero los de mayor prioridad):");
            sistema.Fila.MostrarFila();
            break;

        case 3:
            Paciente? atendido = sistema.AtenderSiguiente();
            if (atendido == null)
                Console.WriteLine("  ⚠ No hay pacientes en espera.");
            else
                Console.WriteLine($"  🩺 Atendiendo: {atendido}");
            break;

        case 4:
            Console.Write("  CI del paciente atendido: ");
            string ciAtencion = Console.ReadLine() ?? "";
            Console.Write("  Diagnóstico: ");
            string dx = Console.ReadLine() ?? "";
            Console.Write("  Medicamento recetado: ");
            string rx = Console.ReadLine() ?? "";
            sistema.RegistrarAtencion(ciAtencion, dx, rx);
            sistema.RegistrarAccionDeshacible(
                $"Atención a {ciAtencion}",
                new SaludFirst.Estructuras.AccionMedica(
                    $"Eliminar atención de {ciAtencion}",
                    () => Console.WriteLine($"    ↩ Revertido: atención de {ciAtencion}"))
            );
            break;

        case 5:
            Console.Write("  CI del paciente: ");
            string ciHist = Console.ReadLine() ?? "";
            Console.Write("  ¿Inverso? (s/n): ");
            bool inverso = (Console.ReadLine() ?? "n").Trim().ToLower() == "s";
            Console.WriteLine($"\n  📋 Historial de {ciHist}:");
            sistema.VerHistorial(ciHist, inverso);
            break;

        case 6:
            Console.Write("  CI del paciente: ");
            string ciBusq = Console.ReadLine() ?? "";
            Console.Write("  Palabra clave a buscar: ");
            string clave = Console.ReadLine() ?? "";
            Atencion? encontrada = sistema.BuscarEnHistorial(ciBusq, clave);
            Console.WriteLine(encontrada == null
                ? "  ❌ Sin coincidencias (recorrido recursivo completo)."
                : $"  ✅ Encontrado: {encontrada}");
            break;

        case 7:
            Console.WriteLine("  💊 Catálogo de medicamentos (inorden = ordenado por código):");
            sistema.MostrarCatalogo();
            break;

        case 8:
            Console.Write("  Código del medicamento (ej. MED-030): ");
            string codMed = Console.ReadLine() ?? "";
            Medicamento? med = sistema.BuscarMedicamento(codMed);
            Console.WriteLine(med == null
                ? "  ❌ Medicamento no encontrado en el BST."
                : $"  ✅ {med}");
            break;

        case 9:
            string? deshecha = sistema.DeshacerUltimaAccion();
            Console.WriteLine(deshecha == null
                ? "  ⚠ No hay acciones que deshacer (pila vacía)."
                : $"  ↩ Deshecho: {deshecha} | Restantes: {sistema.AccionesPendientesDeDeshacer()}");
            break;

        case 10:
            sistema.GenerarReporteDiario();
            break;

        case 0:
            Console.WriteLine("  👋 Hasta luego.");
            break;

        default:
            Console.WriteLine("  ⚠ Opción inválida.");
            break;
    }

    if (opcion != 0)
    {
        Console.Write("\n  Presione ENTER para continuar...");
        Console.ReadLine();
    }
} while (opcion != 0);
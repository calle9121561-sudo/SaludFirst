using System;
using SaludFirst.Modelos;
using SaludFirst.Servicios;

namespace SaludFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            SistemaSalud sistema = new SistemaSalud();
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   🩺 SALUDFIRST - SISTEMA DE TRIAJE    ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar Paciente");
                Console.WriteLine("2. Agregar a Cola de Triaje");
                Console.WriteLine("3. Atender Siguiente Paciente");
                Console.WriteLine("4. Ver Última Acción Registrada");
                Console.WriteLine("5. Deshacer / Desapilar Última Acción");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("--- REGISTRAR PACIENTE ---");
                        Console.Write("Ingrese Nombre del Paciente: ");
                        string nombre = Console.ReadLine() ?? "Desconocido";
                        Console.Write("Ingrese Cédula de Identidad (CI): ");
                        string ci = Console.ReadLine() ?? "S/N";
                        Console.Write("Ingrese Edad: ");
                        int.TryParse(Console.ReadLine(), out int edad);
                        Console.Write("Ingrese Síntoma / Diagnóstico: ");
                        string sintoma = Console.ReadLine() ?? "General";
                        Console.Write("Ingrese Turno (número): ");
                        int.TryParse(Console.ReadLine(), out int turno);

                        // Por defecto se puede registrar con una prioridad Baja o la que prefieras inicialmente
                        Prioridad prioridadReg = Prioridad.Baja;

                        Paciente nuevoPaciente = new Paciente(nombre, ci, edad, sintoma, prioridadReg, turno);
                        sistema.RegistrarPaciente(nuevoPaciente);
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("--- AGREGAR A TRIAJE ---");
                        Console.Write("Ingrese Nombre del Paciente a encolar: ");
                        string nomPaciente = Console.ReadLine() ?? "Desconocido";
                        Console.Write("Ingrese CI: ");
                        string ciPaciente = Console.ReadLine() ?? "S/N";
                        Console.Write("Ingrese Edad: ");
                        int.TryParse(Console.ReadLine(), out int edadPaciente);
                        Console.Write("Ingrese Síntoma: ");
                        string sintomaPaciente = Console.ReadLine() ?? "Urgencia";
                        
                        Console.Write("Ingrese Nivel de Prioridad (1 = Baja, 2 = Media, 3 = Alta): ");
                        int.TryParse(Console.ReadLine(), out int valorPrioridad);
                        Prioridad prioridadTriaje = (Prioridad)Math.Clamp(valorPrioridad, 1, 3);

                        Console.Write("Ingrese Turno: ");
                        int.TryParse(Console.ReadLine(), out int turnoTriaje);

                        Paciente pacienteTriaje = new Paciente(nomPaciente, ciPaciente, edadPaciente, sintomaPaciente, prioridadTriaje, turnoTriaje);
                        sistema.AgregarATriaje(pacienteTriaje, (int)prioridadTriaje);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("--- ATENDER PACIENTE ---");
                        sistema.AtenderSiguientePaciente();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("--- ÚLTIMA ACCIÓN ---");
                        sistema.VerUltimaAccion();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("--- DESHACER ACCIÓN ---");
                        sistema.DeshacerUltimaAccion();
                        break;

                    case "6":
                        salir = true;
                        Console.WriteLine("\n¡Gracias por usar SaludFirst! Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }
    }
}
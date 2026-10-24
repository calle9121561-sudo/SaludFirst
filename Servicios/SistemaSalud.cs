using System;
using SaludFirst.Estructuras;
using SaludFirst.Modelos;

namespace SaludFirst.Servicios
{
    public class SistemaSalud
    {
        private ColaPrioridad colaTriaje = new ColaPrioridad();
        private ListaDoble<Paciente> listaPacientes = new ListaDoble<Paciente>();
        private Pila historialAcciones = new Pila();

        public void RegistrarPaciente(Paciente paciente)
        {
            listaPacientes.Agregar(paciente);
            historialAcciones.Apilar($"Se registró al paciente: {paciente}");
            Console.WriteLine("Paciente registrado exitosamente.");
        }

        public void AgregarATriaje(Paciente paciente, int prioridad)
        {
            colaTriaje.Encolar(paciente, prioridad);
            historialAcciones.Apilar($"Paciente {paciente} agregado a triaje con prioridad {prioridad}");
            Console.WriteLine("Paciente agregado a la cola de triaje.");
        }

        public void AtenderSiguientePaciente()
        {
            Paciente? siguiente = colaTriaje.Atender();
            if (siguiente != null)
            {
                historialAcciones.Apilar($"Se atendió al paciente: {siguiente}");
                Console.WriteLine($"Atendiendo a: {siguiente}");
            }
            else
            {
                Console.WriteLine("No hay pacientes en espera en el triaje.");
            }
        }

        public void VerUltimaAccion()
        {
            string? ultima = historialAcciones.VerCima();
            if (ultima != null)
            {
                Console.WriteLine($"Última acción registrada: {ultima}");
            }
            else
            {
                Console.WriteLine("No hay acciones en el historial.");
            }
        }

        public void DeshacerUltimaAccion()
        {
            string? deshecha = historialAcciones.Desapilar();
            if (deshecha != null)
            {
                Console.WriteLine($"Se desapiló / deshizo la acción: {deshecha}");
            }
            else
            {
                Console.WriteLine("El historial está vacío.");
            }
        }
    }
}
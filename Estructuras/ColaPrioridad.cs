using System;
using System.Collections.Generic;
using SaludFirst.Modelos;

namespace SaludFirst.Estructuras
{
    public class NodoColaPrioridad
    {
        public Paciente Paciente { get; set; }
        public int Prioridad { get; set; }
        public NodoColaPrioridad? Siguiente { get; set; }

        public NodoColaPrioridad(Paciente paciente, int prioridad)
        {
            Paciente = paciente;
            Prioridad = prioridad;
            Siguiente = null;
        }
    }

    public class ColaPrioridad
    {
        private NodoColaPrioridad? frente;

        public void Encolar(Paciente paciente, int prioridad)
        {
            NodoColaPrioridad nuevo = new NodoColaPrioridad(paciente, prioridad);

            // Si la cola está vacía o el nuevo tiene mayor prioridad (número menor) que el frente
            if (frente == null || prioridad < frente.Prioridad)
            {
                nuevo.Siguiente = frente;
                frente = nuevo;
            }
            else
            {
                NodoColaPrioridad actual = frente;
                while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                {
                    actual = actual.Siguiente;
                }
                nuevo.Siguiente = actual.Siguiente;
                actual.Siguiente = nuevo;
            }
        }

        public Paciente? Atender()
        {
            if (frente == null) return null;

            Paciente pacienteAtendido = frente.Paciente;
            frente = frente.Siguiente;
            return pacienteAtendido;
        }

        public bool EstaVacia() => frente == null;
    }
}
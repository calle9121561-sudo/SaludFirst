# 🩺 SaludFirst — Sistema de Atención y Triaje Inteligente

Base del Producto Final Integrador para la asignatura **Estructuras de Datos** (5.° Semestre).

---

## 🚀 Descripción del Proyecto

**SaludFirst** es una aplicación desarrollada en C# orientada a la gestión hospitalaria y la optimización de flujos de emergencia. El sistema simula un entorno clínico real aplicando estructuras de datos dinámicas avanzadas para clasificar pacientes según su nivel de urgencia, administrar historiales médicos, coordinar la dispensación de medicamentos y llevar un control administrativo eficiente.

---

## 🛠️ Tecnologías y Entorno
* **Lenguaje:** C# (.NET 8.0 Console Application)
* **Entorno de desarrollo:** Visual Studio Code / Ubuntu Linux & Windows
* **Control de versiones:** Git & GitHub

---

## 🧱 Estructura del Proyecto

El código está modularizado para garantizar un mantenimiento limpio y escalable:

* **`Estructuras/`**: Implementaciones personalizadas de estructuras de datos (Colas de Prioridad, Listas Simples/Dobles, Pilas y Árboles Binarios de Búsqueda).
* **`Modelos/`**: Entidades principales del sistema (`Paciente`, `Atencion`, `Medicamento`).
* **`Servicios`**: Lógica de negocio y flujos de control del sistema (`Triaje`, `SistemaSalud`).

---

## ⚙️ Funcionalidades Principales

1. **Gestión de Pacientes:** Registro y almacenamiento dinámico.
2. **Sistema de Triaje y Cola de Prioridad:** Clasificación de pacientes según gravedad clínica, garantizando que la atención prioritaria sea atendida primero bajo un orden FIFO estable.
3. **Control de Inventario y Dispensación:** Administración de medicamentos y recursos médicos.
4. **Historial de Acciones (Pilas):** Capacidad de deshacer operaciones recientes dentro del flujo del sistema.
5. **Búsqueda Avanzada (BST):** Localización rápida de registros mediante Árboles Binarios de Búsqueda.

---

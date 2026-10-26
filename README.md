# 🩺 SaludFirst — Sistema de Atención y Triaje Inteligente

<p align="center">
  <img src="portada.png" alt="SaludFirst Portada" width="500"/>
</p>

---

## 📊 DATOS DEL PROYECTO

| Campo | Información |
| :--- | :--- |
| **Módulo** | Estructuras de Datos (5.° Semestre) |
| **Institución** | Universidad Privada Domingo Savio (Sede La Paz) |
| **Estudiante** | Zoely Lizbeth Calle Susara |
| **Tecnologías** | C# (.NET 8.0) |

---

## 📑 ESTRUCTURA DEL DOCUMENTO DE PROYECTO

### Índice
- **1. Introducción**
  - 1.1 Contexto General
  - 1.2 Problemática
  - 1.3 Justificación
  - 1.4 Alcance
  - 1.5 Limitaciones
- **2. Objetivos**
  - 2.1 Objetivo General
  - 2.2 Objetivos Específicos
- **3. Marco Teórico**
  - 3.1 Programación Orientada a Objetos (POO) y Genéricos
  - 3.2 Estructuras de Datos Dinámicas (Colas de Prioridad, Listas Dobles, Pilas)
  - 3.3 Reglas de Nulabilidad y Restricciones en C# (.NET 8.0)
  - 3.4 Manejo de Excepciones y Validación de Entradas
- **4. Desarrollo del Proyecto**
  - 4.1 Descripción General del Sistema
  - 4.2 Estructura del Sistema (Modularización)
  - 4.3 Gestión Dinámica de Pacientes
  - 4.4 Sistema de Triaje y Cola de Prioridad
  - 4.5 Historial de Acciones y Control con Pilas
  - 4.6 Búsqueda y Organización de Registros
- **5. Tecnologías Utilizadas**
- **6. Conclusiones y Recomendaciones**
  - 6.1 Conclusiones
  - 6.2 Recomendaciones

---

## 1. Introducción

### 1.1 Contexto General
La gestión eficiente de los flujos de atención y triaje en centros de salud de alta demanda requiere herramientas de optimización clínica precisas. La priorización de pacientes según su nivel de urgencia y el control automatizado de registros son pilares fundamentales para garantizar instituciones eficientes.

### 1.2 Problemática
En los servicios de emergencia tradicionales, la saturación de pacientes y la falta de una clasificación automatizada basada en prioridades clínicas generan tiempos de espera prolongados, riesgos críticos para casos graves y dificultades para mantener un historial trazable de las acciones operativas.

### 1.3 Justificación
El desarrollo de una herramienta tecnológica especializada como **SaludFirst** se justifica en la necesidad de automatizar el triaje hospitalario, garantizar el cumplimiento de un orden óptimo de atención mediante estructuras de datos eficientes y facilitar el control administrativo mediante un diseño modular en C#.

### 1.4 Alcance
El sistema abarca la administración de pacientes, la gestión de colas de prioridad para triaje de urgencias, el control de inventario de medicamentos, el almacenamiento temporal de acciones mediante pilas (para trazabilidad y control de operaciones) y la navegación bidireccional por los registros.

### 1.5 Limitaciones
El software opera como una aplicación de consola en el entorno local, limitando su interacción distribuida en red y dependiendo de la correcta ejecución de los servicios y estructuras en memoria configurados en .NET 8.0.

---

## 2. Objetivos

### 2.1 Objetivo General
Desarrollar una aplicación de consola robusta en C# orientada a la gestión hospitalaria y la optimización de flujos de emergencia, aplicando estructuras de datos dinámicas avanzadas para clasificar pacientes según su nivel de urgencia, administrar historiales médicos y coordinar recursos clínicos bajo principios de eficiencia algorítmica y programación modular.

### 2.2 Objetivos Específicos
- Implementar estructuras de datos dinámicas personalizadas (Colas de Prioridad, Listas Dobles y Pilas).
- Registrar y administrar entidades clínicas fundamentales como pacientes, atenciones y medicamentos.
- Gestionar un sistema de triaje clínico automatizado que garantice que la atención prioritaria sea atendida primero bajo criterios de gravedad.
- Incorporar un historial de acciones mediante pilas para permitir el control de operaciones recientes en el sistema.
- Garantizar la estabilidad del código mediante restricciones de tipos genéricos y reglas estrictas de nulabilidad en .NET 8.0.

---

## 3. Marco Teórico

### 3.1 Programación Orientada a Objetos (POO) y Genéricos
Paradigma basado en la estructuración del software en clases, objetos y tipos genéricos con restricciones de clase (`where T : class`), permitiendo un diseño reutilizable y seguro.

### 3.2 Estructuras de Datos Dinámicas
- **Cola de Prioridad:** Estructura especializada para clasificar y despachar pacientes según su nivel de urgencia médica (FIFO con prioridad).
- **Lista Doble:** Permite la navegación bidireccional eficiente a través de los registros de pacientes y atenciones.
- **Pilas (Stack):** Estructura LIFO utilizada para el control de historiales de acciones y operaciones recientes del sistema.

### 3.3 Reglas de Nulabilidad y Restricciones en C# (.NET 8.0)
Mecanismos avanzados del compilador para prevenir referencias nulas, empleando operadores de nulabilidad (`?`) y restricciones de tipo para garantizar la estabilidad de las estructuras dinámicas.

### 3.4 Manejo de Excepciones y Validación de Entradas
Mecanismos de control de errores y validación de flujos por consola para asegurar una interfaz robusta ante interacciones del usuario.

---

## 4. Desarrollo del Proyecto

### 4.1 Descripción general del sistema
**SaludFirst** es una aplicación de consola modular desarrollada en C# orientada a resolver problemas logísticos y operativos en un entorno clínico simulado. Permite administrar pacientes, estructurar rutas de triaje de urgencias y llevar un control estructurado de las atenciones y medicamentos.

### 4.2 Estructura del sistema
El sistema está organizado mediante clases y carpetas especializadas que representan las entidades del dominio:
- **`Estructuras/`**: Contiene las implementaciones algorítmicas personalizadas (`ColaPrioridad.cs`, `ListaDoble.cs`, `Pila.cs`, etc.).
- **`Modelos/`**: Define las entidades principales del sistema (`Paciente.cs`, `Atencion.cs`, `Medicamento.cs`).
- **`Servicios/`**: Aloja la lógica de negocio central y el flujo de control del sistema (`SistemaSalud.cs`, `Triaje.cs`).

### 4.3 Gestión dinámica de pacientes
El sistema permite al operador registrar nuevos pacientes y recorrer los datos almacenados mediante listas doblemente enlazadas, facilitando la visualización ordenada y la navegación secuencial o inversa por los registros.

### 4.4 Sistema de triaje y cola de prioridad
Clasifica de forma inteligente el ingreso de pacientes a la sala de urgencias de acuerdo con parámetros de prioridad clínica, asegurando un orden de atención óptimo y automatizado.

### 4.5 Historial de acciones y control con pilas
Registra las acciones operativas ejecutadas en el sistema utilizando una estructura tipo Pila, posibilitando consultar la última actividad registrada o deshacer operaciones recientes de manera fluida.

### 4.6 Búsqueda y organización de registros
Facilita la localización rápida de información dentro del flujo del programa mediante métodos de búsqueda integrados en las estructuras de datos.

---

## 5. Tecnologías Utilizadas
- **Lenguaje:** C# (.NET 8.0 Console Application)
- **Paradigma:** Programación Orientada a Objetos y Estructuras de Datos Dinámicas
- **Entorno de Desarrollo (IDE):** Visual Studio Code
- **Control de Versiones:** Git y GitHub

---

## 6. Conclusiones y Recomendaciones

### 6.1 Conclusiones
El desarrollo de **SaludFirst** demostró la viabilidad de aplicar principios de ingeniería de software modular y estructuras de datos dinámicas en consola para resolver problemas reales de gestión hospitalaria. La integración de colas de prioridad y pilas asegura un control estricto y eficiente de las emergencias médicas.

### 6.2 Recomendaciones
Se recomienda a futuro migrar la persistencia en memoria a una base de datos relacional (como SQLite o SQL Server) para mejorar la escalabilidad, así como desarrollar una interfaz gráfica de usuario (GUI) o web que facilite la visualización de los flujos clínicos a gran escala.

---

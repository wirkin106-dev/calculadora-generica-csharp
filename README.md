<<<<<<< HEAD
# 🧮 Calculadora Genérica - ITLA

Aplicación de consola en C# que realiza operaciones matemáticas (suma, resta, multiplicación y división) sobre una lista genérica de números, utilizando genéricos, delegados y control de excepciones.

---

## 📁 Estructura del Proyecto

```
TareaPractica2/
├── Program.cs                  # Punto de entrada
├── Models/
│   └── NumericList.cs          # Clase genérica que almacena y opera sobre números
├── Operations/
│   └── MathOperations.cs       # Delegado y las 4 operaciones matemáticas
└── UI/
    └── ConsoleMenu.cs          # Interfaz de usuario (menú en consola)
```

---

## 🚀 Cómo ejecutar el programa

### Requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download) o superior

### Pasos

```bash
# 1. Clona el repositorio
git clone https://github.com/TU_USUARIO/calculadora-generica-csharp.git

# 2. Entra a la carpeta del proyecto
cd calculadora-generica-csharp

# 3. Ejecuta la aplicación
dotnet run
```

---

## 🧩 Cómo funciona

Al ejecutar el programa verás un menú con estas opciones:

```
┌──────────────────────────────────────┐
│            MENÚ PRINCIPAL            │
├──────────────────────────────────────┤
│  1. Agregar número a la lista        │
│  2. Ver lista actual                 │
│  3. Sumar todos los números          │
│  4. Restar todos los números         │
│  5. Multiplicar todos los números    │
│  6. Dividir todos los números        │
│  7. Limpiar lista                    │
│  0. Salir                            │
└──────────────────────────────────────┘
```

1. Agrega al menos **2 números** a la lista.
2. Elige la operación deseada.
3. El programa muestra el resultado de aplicar la operación de forma **secuencial** sobre todos los elementos.

---

## ⚙️ Conceptos utilizados

### Genéricos
La clase `NumericList<T>` es genérica con la restricción `where T : struct, IConvertible`.  
Esto permite trabajar con `int`, `double`, `float`, `decimal`, etc., sin cambiar el código.

```csharp
public class NumericList<T> where T : struct, IConvertible
{
    private readonly List<T> _numbers = new();
    ...
}
```

### Delegados
Se define un delegado `MathOperation` que representa cualquier operación entre dos `double`:

```csharp
public delegate double MathOperation(double a, double b);
```

Las cuatro operaciones se pasan como argumento a `ApplyOperation`, lo que permite extender el sistema con nuevas operaciones sin modificar la clase genérica.

### Principio aplicado (SRP)
Cada clase tiene una única responsabilidad:
- `NumericList<T>` → gestiona la lista y aplica operaciones
- `MathOperations` → define las operaciones matemáticas
- `ConsoleMenu` → maneja toda la interacción con el usuario

---

## ⚠️ Manejo de Excepciones

| Excepción | Cuándo ocurre |
|---|---|
| `InvalidOperationException` | Se intenta operar con menos de 2 números en la lista |
| `DivideByZeroException` | Se intenta dividir por cero en la operación de división |
| `FormatException` | El usuario ingresa un valor que no es un número válido |

Todos los errores se muestran en consola con un mensaje claro en color rojo, sin interrumpir la ejecución del programa.

---

## 👤 Autor
**wirkin106-dev** — Instituto Tecnológico de las Américas (ITLA)
=======
# calculadora-generica-csharp
Aplicación de consola en C# que realiza operaciones matemáticas (suma, resta, multiplicación y división) sobre una lista genérica de números, utilizando genéricos, delegados y control de excepciones.
>>>>>>> 4353f1fbadfcaf7413adcafea8bb349ceb00e9e3

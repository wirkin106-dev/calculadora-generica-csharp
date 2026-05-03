using System.Globalization;
using TareaPractica2.Models;
using TareaPractica2.Operations;

namespace TareaPractica2.UI;

/// <summary>
/// Clase responsable de manejar toda la interacción con el usuario en consola.
/// Gestiona el menú, la entrada de datos y la presentación de resultados y errores.
/// </summary>
public class ConsoleMenu
{
    private readonly NumericList<double> _list = new();

    /// <summary>
    /// Inicia el ciclo principal de la aplicación.
    /// </summary>
    public void Run()
    {
        MostrarBienvenida();

        bool running = true;
        while (running)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()?.Trim() ?? string.Empty;

            switch (opcion)
            {
                case "1": AgregarNumero(); break;
                case "2": MostrarLista(); break;
                case "3": EjecutarOperacion("Suma", MathOperations.Sumar); break;
                case "4": EjecutarOperacion("Resta", MathOperations.Restar); break;
                case "5": EjecutarOperacion("Multiplicación", MathOperations.Multiplicar); break;
                case "6": EjecutarOperacion("División", MathOperations.Dividir); break;
                case "7": LimpiarLista(); break;
                case "0": running = false; break;
                default:
                    MostrarError("Opción no válida. Por favor elige una opción del menú.");
                    break;
            }
        }

        Console.WriteLine("\n¡Hasta luego!\n");
    }

    // ─── Métodos privados de UI ────────────────────────────────────────────────

    private static void MostrarBienvenida()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════╗");
        Console.WriteLine("║     Calculadora Genérica - ITLA      ║");
        Console.WriteLine("║   Genéricos · Delegados · Excepciones║");
        Console.WriteLine("╚══════════════════════════════════════╝");
        Console.ResetColor();
    }

    private static void MostrarMenu()
    {
        Console.WriteLine("\n┌──────────────────────────────────────┐");
        Console.WriteLine("│            MENÚ PRINCIPAL            │");
        Console.WriteLine("├──────────────────────────────────────┤");
        Console.WriteLine("│  1. Agregar número a la lista        │");
        Console.WriteLine("│  2. Ver lista actual                 │");
        Console.WriteLine("│  3. Sumar todos los números          │");
        Console.WriteLine("│  4. Restar todos los números         │");
        Console.WriteLine("│  5. Multiplicar todos los números    │");
        Console.WriteLine("│  6. Dividir todos los números        │");
        Console.WriteLine("│  7. Limpiar lista                    │");
        Console.WriteLine("│  0. Salir                            │");
        Console.WriteLine("└──────────────────────────────────────┘");
        Console.Write("  Elige una opción: ");
    }

    private void AgregarNumero()
    {
        Console.Write("\n  Ingresa un número: ");
        string input = Console.ReadLine()?.Trim() ?? string.Empty;

        try
        {
            if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double numero))
                throw new FormatException($"'{input}' no es un número válido.");

            _list.Add(numero);
            MostrarExito($"Número {numero} agregado correctamente. Total en lista: {_list.Count}");
        }
        catch (FormatException ex)
        {
            MostrarError($"Entrada incorrecta → {ex.Message}");
        }
    }

    private void MostrarLista()
    {
        Console.WriteLine();
        if (_list.Count == 0)
        {
            Console.WriteLine("  ⚠  La lista está vacía.");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  Lista actual ({_list.Count} elemento(s)):");
        Console.WriteLine($"  [ {string.Join("  ,  ", _list.Numbers)} ]");
        Console.ResetColor();
    }

    private void EjecutarOperacion(string nombre, MathOperation operacion)
    {
        try
        {
            MostrarLista();
            double resultado = _list.ApplyOperation(operacion);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✓ Resultado de {nombre}: {resultado}");
            Console.ResetColor();
        }
        catch (InvalidOperationException ex)
        {
            MostrarError($"Operación inválida → {ex.Message}");
        }
        catch (DivideByZeroException ex)
        {
            MostrarError($"División por cero → {ex.Message}");
        }
    }

    private void LimpiarLista()
    {
        _list.Clear();
        MostrarExito("Lista limpiada correctamente.");
    }

    private static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ✗ Error: {mensaje}");
        Console.ResetColor();
    }

    private static void MostrarExito(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✓ {mensaje}");
        Console.ResetColor();
    }
}

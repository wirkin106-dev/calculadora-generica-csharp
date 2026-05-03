namespace TareaPractica2.Operations;

/// <summary>
/// Delegado que representa una operación matemática entre dos números double.
/// Recibe dos parámetros y retorna el resultado de la operación.
/// </summary>
public delegate double MathOperation(double a, double b);

/// <summary>
/// Clase estática con las implementaciones de las cuatro operaciones matemáticas básicas.
/// Cada método es compatible con el delegado MathOperation.
/// </summary>
public static class MathOperations
{
    /// <summary>Suma dos números.</summary>
    public static double Sumar(double a, double b) => a + b;

    /// <summary>Resta b de a.</summary>
    public static double Restar(double a, double b) => a - b;

    /// <summary>Multiplica dos números.</summary>
    public static double Multiplicar(double a, double b) => a * b;

    /// <summary>
    /// Divide a entre b.
    /// </summary>
    /// <exception cref="DivideByZeroException">Si b es cero.</exception>
    public static double Dividir(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("No se puede dividir entre cero.");
        return a / b;
    }
}
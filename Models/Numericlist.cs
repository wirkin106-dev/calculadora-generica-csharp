using TareaPractica2.Operations;

namespace TareaPractica2.Models;

/// <summary>
/// Lista genérica que almacena números y permite aplicar operaciones matemáticas sobre ellos.
/// El tipo T debe ser un struct que implemente IConvertible (int, double, float, decimal, etc.).
/// </summary>
public class NumericList<T> where T : struct, IConvertible
{
    private readonly List<T> _numbers = new();

    /// <summary>Cantidad de elementos en la lista.</summary>
    public int Count => _numbers.Count;

    /// <summary>Acceso de solo lectura a los elementos de la lista.</summary>
    public IReadOnlyList<T> Numbers => _numbers.AsReadOnly();

    /// <summary>
    /// Agrega un número a la lista.
    /// </summary>
    /// <param name="number">Número a agregar.</param>
    public void Add(T number) => _numbers.Add(number);

    /// <summary>
    /// Elimina todos los elementos de la lista.
    /// </summary>
    public void Clear() => _numbers.Clear();

    /// <summary>
    /// Aplica una operación matemática de forma secuencial sobre todos los elementos.
    /// Ejemplo: [2, 3, 4] con Suma → ((2 + 3) + 4) = 9
    /// </summary>
    /// <param name="operation">Delegado MathOperation con la operación a ejecutar.</param>
    /// <returns>Resultado final de aplicar la operación.</returns>
    /// <exception cref="InvalidOperationException">Si la lista tiene menos de 2 elementos.</exception>
    public double ApplyOperation(MathOperation operation)
    {
        if (_numbers.Count < 2)
            throw new InvalidOperationException(
                "La lista debe contener al menos dos números para realizar una operación.");

        double result = Convert.ToDouble(_numbers[0]);

        for (int i = 1; i < _numbers.Count; i++)
        {
            result = operation(result, Convert.ToDouble(_numbers[i]));
        }

        return result;
    }
}


using System.Diagnostics.CodeAnalysis;

namespace UCABPagaloTodoMS.Application.Excepciones;

[ExcludeFromCodeCoverage]
public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }

    public ValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
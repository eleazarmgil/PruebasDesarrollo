

namespace UCABPagaloTodoMS.Infrastructure.services;

public class GenerarTxt
{
    public void CrearArchivo() 
    {
        TextWriter escribe = new StreamWriter("AquiVa la direccion del archivo");
        escribe.WriteLine("Mensajito");
        escribe.Close();
    }

    public void SeguirEscribiendo(String direccion) 
    {
        StreamWriter agregar = File.AppendText(direccion);
        agregar.WriteLine("Nueva linea agg");
        agregar.Close();
    }

    public void LeerArchivo(String direccion) 
    {
        // Lee todas las líneas del archivo y las almacena en un arreglo
        string[] lineas = File.ReadAllLines(direccion);

        // Itera a través de cada línea del arreglo
        foreach (string linea in lineas)
        {
            // Imprime la línea actual
            Console.WriteLine(linea);

            // Si la línea actual contiene la palabra "END", detiene la lectura del archivo
            if (linea.Contains("END"))
            {
                break;
            }
        }
    }
}

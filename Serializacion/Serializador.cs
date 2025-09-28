using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tarea5Graf.Serializacion;

public class Serializador
{
    private JsonSerializerOptions opciones;
    public Serializador()
    {
        opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            Converters =
                {
                    new JsonStringEnumConverter(),
                    new Color4Converter()
                },
        };
    }
    public static string ObtenerRutaCompleta(string nombreArchivo)
    {
        string rutaActual = (Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent?.FullName)!;
        string carpetaObjetos = Path.Combine(rutaActual, "Objetos");

        if (!Directory.Exists(carpetaObjetos))
            Directory.CreateDirectory(carpetaObjetos);

        if (!nombreArchivo.EndsWith(".json"))
            nombreArchivo += ".json";

        return Path.Combine(carpetaObjetos, nombreArchivo);
    }

    public void Serializar<T>(T objeto, string nombreArchivo)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(objeto, opciones);
            File.WriteAllText(ObtenerRutaCompleta(nombreArchivo), jsonString);
        }
        catch (Exception) { }
    }

    public T? Deserializar<T>(string nombreArchivo)
    {
        try
        {
            string rutaArchivo = ObtenerRutaCompleta(nombreArchivo);
            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException($"El archivo '{rutaArchivo}' no existe.");
            return JsonSerializer.Deserialize<T>(File.ReadAllText(rutaArchivo), opciones);
        }
        catch (Exception)
        {
            return default;
        }
    }
}

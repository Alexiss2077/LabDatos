using System.Text;

namespace LabDatos;

/// <summary>
/// NIVEL 1 - El Escriba
/// Maneja el archivo binario de acceso directo.
/// Cada registro ocupa exactamente Ciudadano.Size bytes.
/// La posición de un registro se calcula como:
///     Offset = posicion × Ciudadano.Size
/// </summary>
public class GestorArchivos
{
    private readonly string _path = "datos_ciudadanos.dat";

    public string ArchivoPath => _path;

    // -------------------------------------------------------
    // Guardar un ciudadano en una posición específica del archivo
    // -------------------------------------------------------
    public void GuardarCiudadano(Ciudadano c, int posicion)
    {
        using var fs = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write);

        // NIVEL 1: Cálculo del Offset
        long offset = (long)posicion * Ciudadano.Size;
        fs.Seek(offset, SeekOrigin.Begin);

        using var writer = new BinaryWriter(fs, Encoding.ASCII, leaveOpen: true);

        writer.Write(c.Id);

        // Asegurar tamaño fijo de 50 bytes para el nombre (rellenar o truncar)
        string nombre = (c.Nombre ?? "").PadRight(50);
        if (nombre.Length > 50) nombre = nombre[..50];
        writer.Write(Encoding.ASCII.GetBytes(nombre));

        writer.Write(c.Edad);
    }

    // -------------------------------------------------------
    // Leer un ciudadano usando Seek directo (acceso directo)
    // -------------------------------------------------------
    public Ciudadano? LeerCiudadano(int posicion)
    {
        if (!File.Exists(_path)) return null;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);

        long offset = (long)posicion * Ciudadano.Size;
        if (offset + Ciudadano.Size > fs.Length) return null;

        fs.Seek(offset, SeekOrigin.Begin);

        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        int    id     = reader.ReadInt32();
        string nombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
        int    edad   = reader.ReadInt32();

        return new Ciudadano(id, nombre, edad);
    }

    // -------------------------------------------------------
    // Búsqueda SECUENCIAL - recorre el archivo registro a registro
    // -------------------------------------------------------
    public Ciudadano? BuscarSecuencial(int id)
    {
        if (!File.Exists(_path)) return null;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        long totalRegistros = fs.Length / Ciudadano.Size;

        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        for (long i = 0; i < totalRegistros; i++)
        {
            int    cId     = reader.ReadInt32();
            string cNombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
            int    cEdad   = reader.ReadInt32();

            if (cId == id)
                return new Ciudadano(cId, cNombre, cEdad);
        }

        return null; // no encontrado
    }

    // -------------------------------------------------------
    // Utilidades
    // -------------------------------------------------------
    public int ContarRegistros()
    {
        if (!File.Exists(_path)) return 0;
        return (int)(new FileInfo(_path).Length / Ciudadano.Size);
    }

    public long TamanioArchivo()
    {
        if (!File.Exists(_path)) return 0;
        return new FileInfo(_path).Length;
    }
}

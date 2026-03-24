using System.Text;

namespace LabDatos;

/// <summary>
/// NIVEL 1 - El Escriba
/// Maneja el archivo binario de acceso directo.
/// Cada registro ocupa exactamente Ciudadano.Size (58) bytes.
/// Offset = posicion × 58
///
/// Nota: un registro eliminado se escribe como bytes en cero (Id == 0).
/// </summary>
public class GestorArchivos
{
    private readonly string _path = "datos_ciudadanos.dat";

    public string ArchivoPath => _path;

    // ── nombres y apellidos para generación masiva ───────────────────────────
    private static readonly string[] Nombres =
    {
        "Ana", "Carlos", "María", "José", "Laura", "Pedro", "Sofía", "Miguel",
        "Elena", "Luis", "Diego", "Valentina", "Sebastián", "Camila", "Mateo",
        "Isabella", "Emiliano", "Luciana", "Andrés", "Gabriela", "Fernanda",
        "Ricardo", "Patricia", "Alejandro", "Daniela"
    };

    private static readonly string[] Apellidos =
    {
        "García", "López", "Martínez", "Rodríguez", "González", "Pérez",
        "Sánchez", "Ramírez", "Torres", "Flores", "Rivera", "Morales",
        "Cruz", "Reyes", "Hernández", "Medina", "Jiménez", "Vargas",
        "Castillo", "Rojas"
    };

    // ═══════════════════════════════════════════════════════════════════════
    //  Guardar — escribe un ciudadano en la posición indicada (puede crear huecos)
    // ═══════════════════════════════════════════════════════════════════════
    public void GuardarCiudadano(Ciudadano c, int posicion)
    {
        using var fs = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Write);
        long offset = (long)posicion * Ciudadano.Size;
        fs.Seek(offset, SeekOrigin.Begin);

        using var writer = new BinaryWriter(fs, Encoding.ASCII, leaveOpen: true);
        writer.Write(c.Id);

        string nombre = (c.Nombre ?? "").PadRight(50);
        if (nombre.Length > 50) nombre = nombre[..50];
        writer.Write(Encoding.ASCII.GetBytes(nombre));

        writer.Write(c.Edad);
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Leer — seek directo a la posición
    // ═══════════════════════════════════════════════════════════════════════
    public Ciudadano? LeerCiudadano(int posicion)
    {
        if (!File.Exists(_path)) return null;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        long offset = (long)posicion * Ciudadano.Size;
        if (offset + Ciudadano.Size > fs.Length) return null;

        fs.Seek(offset, SeekOrigin.Begin);
        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        int id = reader.ReadInt32();
        string nombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
        int edad = reader.ReadInt32();

        if (id == 0) return null; // registro eliminado
        return new Ciudadano(id, nombre, edad);
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Modificar — sobrescribe el registro en la posición dada
    // ═══════════════════════════════════════════════════════════════════════
    public bool ModificarCiudadano(Ciudadano c, int posicion)
    {
        if (!File.Exists(_path)) return false;
        long fileLen = new FileInfo(_path).Length;
        long offset = (long)posicion * Ciudadano.Size;
        if (offset + Ciudadano.Size > fileLen) return false;

        GuardarCiudadano(c, posicion);
        return true;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Eliminar — escribe ceros en la posición (Id == 0 = eliminado)
    // ═══════════════════════════════════════════════════════════════════════
    public bool EliminarCiudadano(int posicion)
    {
        if (!File.Exists(_path)) return false;
        long offset = (long)posicion * Ciudadano.Size;
        long fileLen = new FileInfo(_path).Length;
        if (offset + Ciudadano.Size > fileLen) return false;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Write);
        fs.Seek(offset, SeekOrigin.Begin);
        fs.Write(new byte[Ciudadano.Size], 0, Ciudadano.Size);
        return true;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Leer todos (posición → ciudadano) — omite los eliminados (Id == 0)
    // ═══════════════════════════════════════════════════════════════════════
    public List<(int Posicion, Ciudadano Ciudadano)> LeerTodos()
    {
        var result = new List<(int, Ciudadano)>();
        if (!File.Exists(_path)) return result;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        int total = (int)(fs.Length / Ciudadano.Size);
        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        for (int pos = 0; pos < total; pos++)
        {
            int id = reader.ReadInt32();
            string nombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
            int edad = reader.ReadInt32();
            if (id != 0)
                result.Add((pos, new Ciudadano(id, nombre, edad)));
        }
        return result;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Búsqueda secuencial — omite eliminados
    // ═══════════════════════════════════════════════════════════════════════
    public Ciudadano? BuscarSecuencial(int id)
    {
        if (!File.Exists(_path)) return null;

        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        long total = fs.Length / Ciudadano.Size;
        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        for (long i = 0; i < total; i++)
        {
            int cId = reader.ReadInt32();
            string cNombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
            int cEdad = reader.ReadInt32();

            if (cId == id)
                return new Ciudadano(cId, cNombre, cEdad);
        }
        return null;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Auto-ID — devuelve el siguiente ID disponible (máximo + 1)
    // ═══════════════════════════════════════════════════════════════════════
    public int GetNextId()
    {
        if (!File.Exists(_path)) return 1;

        int maxId = 0;
        using var fs = new FileStream(_path, FileMode.Open, FileAccess.Read);
        int total = (int)(fs.Length / Ciudadano.Size);
        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        for (int i = 0; i < total; i++)
        {
            int id = reader.ReadInt32();
            reader.ReadBytes(54); // nombre(50) + edad(4)
            if (id > maxId) maxId = id;
        }
        return maxId + 1;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Agregar masivo — inserta N registros al final del archivo (async)
    // ═══════════════════════════════════════════════════════════════════════
    public async Task<int> AgregarMasivoAsync(int cantidad, IProgress<(int Hechos, int Total)>? progreso = null)
    {
        int nextId = GetNextId();
        int startPos = ContarSlots(); // slots totales (incluyendo eliminados)
        var rng = new Random();

        await Task.Run(() =>
        {
            for (int i = 0; i < cantidad; i++)
            {
                string nombre = $"{Nombres[rng.Next(Nombres.Length)]} {Apellidos[rng.Next(Apellidos.Length)]}";
                int edad = rng.Next(18, 80);
                GuardarCiudadano(new Ciudadano(nextId + i, nombre, edad), startPos + i);

                if (i % 100 == 0 || i == cantidad - 1)
                    progreso?.Report((i + 1, cantidad));
            }
        });
        return cantidad;
    }

    // ═══════════════════════════════════════════════════════════════════════
    //  Utilidades
    // ═══════════════════════════════════════════════════════════════════════

    /// <summary>Total de slots en el archivo (activos + eliminados).</summary>
    public int ContarSlots()
    {
        if (!File.Exists(_path)) return 0;
        return (int)(new FileInfo(_path).Length / Ciudadano.Size);
    }

    /// <summary>Total de registros activos (Id != 0).</summary>
    public int ContarRegistros()
    {
        return LeerTodos().Count;
    }

    public long TamanioArchivo()
    {
        if (!File.Exists(_path)) return 0;
        return new FileInfo(_path).Length;
    }
}
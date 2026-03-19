using System.Text;

namespace LabDatos;

/// <summary>
/// NIVEL 2 - El Indexador
/// Crea y gestiona un archivo de índice (.idx) que mapea:
///     Id (int, 4 bytes) -> Posición en archivo de datos (int, 4 bytes)
/// Cada entrada del índice ocupa 8 bytes.
///
/// Para buscar por ID:
///   1. Cargar el índice en memoria (Dictionary)
///   2. Obtener la posición directamente del diccionario  -> O(1)
///   3. Hacer Seek() al offset en el archivo de datos
/// Esto evita recorrer el archivo completo como en la búsqueda secuencial.
/// </summary>
public class GestorIndice
{
    private readonly string _dataPath  = "datos_ciudadanos.dat";
    private readonly string _indexPath = "datos_ciudadanos.idx";

    // El índice en memoria: Id -> Posición (número de registro, no bytes)
    private Dictionary<int, int> _indice = new();

    public string IndexPath    => _indexPath;
    public bool   IndiceExiste => File.Exists(_indexPath);

    // -------------------------------------------------------
    // Construir el índice leyendo todo el archivo de datos
    // -------------------------------------------------------
    public int ConstruirIndice()
    {
        if (!File.Exists(_dataPath))
            throw new FileNotFoundException(
                "Archivo de datos no encontrado. Primero guarda registros en el Nivel 1.");

        _indice.Clear();

        using var dataFs  = new FileStream(_dataPath, FileMode.Open, FileAccess.Read);
        using var indexFs = new FileStream(_indexPath, FileMode.Create, FileAccess.Write);
        using var reader  = new BinaryReader(dataFs, Encoding.ASCII, leaveOpen: true);
        using var writer  = new BinaryWriter(indexFs);

        int totalRegistros = (int)(dataFs.Length / Ciudadano.Size);

        for (int pos = 0; pos < totalRegistros; pos++)
        {
            int id = reader.ReadInt32();
            reader.ReadBytes(50); // saltar nombre
            reader.ReadInt32();   // saltar edad

            // Guardar entrada en el .idx: Id(4 bytes) + Posicion(4 bytes)
            writer.Write(id);
            writer.Write(pos);
            _indice[id] = pos;
        }

        return totalRegistros;
    }

    // -------------------------------------------------------
    // Cargar el índice desde disco a memoria
    // -------------------------------------------------------
    public void CargarIndice()
    {
        _indice.Clear();
        if (!File.Exists(_indexPath)) return;

        using var fs     = new FileStream(_indexPath, FileMode.Open, FileAccess.Read);
        using var reader = new BinaryReader(fs);

        while (fs.Position + 8 <= fs.Length)
        {
            int id  = reader.ReadInt32();
            int pos = reader.ReadInt32();
            _indice[id] = pos;
        }
    }

    // -------------------------------------------------------
    // Búsqueda INDEXADA: consulta el índice y hace Seek directo
    // -------------------------------------------------------
    public (Ciudadano? ciudadano, int posicion) BuscarPorIndice(int id, GestorArchivos gestor)
    {
        if (_indice.Count == 0)
            CargarIndice(); // carga desde disco si el diccionario está vacío

        if (!_indice.TryGetValue(id, out int pos))
            return (null, -1); // ID no está en el índice

        var ciudadano = gestor.LeerCiudadano(pos); // Seek directo
        return (ciudadano, pos);
    }

    public int TotalEnIndice() => _indice.Count;
}

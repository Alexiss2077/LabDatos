using Microsoft.Data.SqlClient;
using System.Text;

namespace LabDatos;

/// <summary>
/// NIVEL 3 - El Maestro de Datos
/// Lee el archivo binario del Nivel 1 y migra los datos a SQL Server.
/// Usa Microsoft.Data.SqlClient para la conexión.
/// La instancia se llama SQLEXPRESS por defecto.
/// </summary>
public class MigradorSql(string connectionString)
{
    // -------------------------------------------------------
    // Crear la tabla si no existe (ejecutar una sola vez)
    // -------------------------------------------------------
    public async Task CrearTablaAsync()
    {
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        // Script CREATE TABLE igual al del documento de práctica
        var sql = @"
            IF NOT EXISTS (
                SELECT * FROM sysobjects
                WHERE name = 'Ciudadanos' AND xtype = 'U'
            )
            CREATE TABLE Ciudadanos (
                Id     INT          PRIMARY KEY,
                Nombre VARCHAR(50)  NOT NULL,
                Edad   INT          NOT NULL
            )";

        using var cmd = new SqlCommand(sql, connection);
        await cmd.ExecuteNonQueryAsync();
    }

    // -------------------------------------------------------
    // Migrar: leer el archivo binario e INSERT por cada registro
    // -------------------------------------------------------
    public async Task<int> MigrarDesdeArchivoAsync(string archivoPath,
                                                    IProgress<string>? progreso = null)
    {
        int insertados = 0;
        int errores    = 0;

        // 1. Abrir conexión — instancia se llama SQLEXPRESS
        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        progreso?.Report("Conexión establecida. Iniciando migración...");

        // Limpiar tabla para evitar duplicados en cada ejecución
        using var cmdDel = new SqlCommand("DELETE FROM Ciudadanos", connection);
        await cmdDel.ExecuteNonQueryAsync();
        progreso?.Report("Tabla limpiada. Insertando registros...");

        // 2. Preparar comando (Insertar)
        var query = "INSERT INTO Ciudadanos (Id, Nombre, Edad) VALUES (@Id, @Nombre, @Edad)";

        // 3. Bucle que lee el archivo secuencialmente y ejecuta SqlCommand por cada registro
        using var fs     = new FileStream(archivoPath, FileMode.Open, FileAccess.Read);
        int total        = (int)(fs.Length / Ciudadano.Size);
        using var reader = new BinaryReader(fs, Encoding.ASCII, leaveOpen: true);

        for (int pos = 0; pos < total; pos++)
        {
            int    id     = reader.ReadInt32();
            string nombre = Encoding.ASCII.GetString(reader.ReadBytes(50)).TrimEnd();
            int    edad   = reader.ReadInt32();

            try
            {
                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id",     id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Edad",   edad);
                await cmd.ExecuteNonQueryAsync();
                insertados++;
            }
            catch (SqlException ex)
            {
                errores++;
                progreso?.Report($"  ⚠ Error reg {pos} (ID={id}): {ex.Message}");
            }
        }

        progreso?.Report($"Migración completa: {insertados} insertados, {errores} errores.");
        return insertados;
    }

    // -------------------------------------------------------
    // Consulta SELECT usando SqlDataReader 
    // -------------------------------------------------------
    public async Task<List<Ciudadano>> ConsultarTodosAsync()
    {
        var lista = new List<Ciudadano>();

        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        using var cmd    = new SqlCommand("SELECT Id, Nombre, Edad FROM Ciudadanos ORDER BY Id", connection);
        using var reader = await cmd.ExecuteReaderAsync(); // SqlDataReader

        while (await reader.ReadAsync())
        {
            lista.Add(new Ciudadano(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2)
            ));
        }

        return lista;
    }
}

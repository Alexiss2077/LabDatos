using System.Runtime.InteropServices;

namespace LabDatos;

// StructLayout con Pack=1 garantiza que no haya bytes de relleno (padding)
// CharSet.Ansi hace que cada caracter ocupe exactamente 1 byte
// Tamaño total: Id(4) + Nombre(50) + Edad(4) = 58 bytes por registro
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
public struct Ciudadano
{
    public int Id;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string Nombre;

    public int Edad;

    public Ciudadano(int id, string nombre, int edad)
    {
        Id     = id;
        Nombre = nombre ?? string.Empty;
        Edad   = edad;
    }

    // Tamaño fijo del registro en bytes — necesario para calcular el Offset
    public static int Size => Marshal.SizeOf<Ciudadano>(); // debe devolver 58

    public override string ToString() =>
        $"ID: {Id,5} | Nombre: {(Nombre ?? "").TrimEnd(),-20} | Edad: {Edad,3}";
}

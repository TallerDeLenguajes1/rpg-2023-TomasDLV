using System.Text.Json;
using System.Text.Json.Serialization;

public enum listaTipos
{
    Guerrero,
    Mago,
    Arquero
}

public enum listaNombres
{
    Juan,
    María,
    Pedro,
    Ana,
    Luis
}

public enum listaApodos
{
    ElBravo,
    ElSabio,
    ElRápido,
    ElSigiloso,
    ElValiente
}

public class Personajes
{
    private string tipo;
    private string nombre;
    private string apodo;
    private DateTime fechaNac;
    private int edad;//0 a 300
    private int velocidad;//1 a 10
    private int destreza;//1 a 5
    private int fuerza;//1 a 10
    private int nivel;//1 a 10
    private int armadura;//1 a 10
    private int salud;//100

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    public void MostrarDatos()
    {
        Console.WriteLine("Tipo: " + Tipo);
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Apodo: " + Apodo);
        Console.WriteLine("Fecha de Nacimiento: " + FechaNac.ToShortDateString());
        Console.WriteLine("Edad: " + Edad);
        Console.WriteLine("Velocidad: " + Velocidad);
    }
    public void GuardarPersonajeJson( string nombreArchivo,string formato){
        FileStream miArchivo = new FileStream(nombreArchivo + formato, FileMode.Append);
        string strPersonaje = JsonSerializer.Serialize(this);
        using (StreamWriter StrWriter = new StreamWriter(miArchivo))
        {
            StrWriter.WriteLine("{0}",strPersonaje);
            StrWriter.Close();
        }
    }
    
}

class FabricaPersonajes
{
    Random rand = new Random();

    public Personajes CrearPersonajeAleatorio()
    {
        Personajes PJ = new Personajes();
        PJ.Tipo = Enum.GetName(typeof(listaTipos),rand.Next(1,Enum.GetNames(typeof(listaTipos)).Length));
        PJ.Nombre = Enum.GetName(typeof(listaNombres),rand.Next(1,Enum.GetNames(typeof(listaNombres)).Length));
        PJ.Apodo = Enum.GetName(typeof(listaApodos),rand.Next(1,Enum.GetNames(typeof(listaApodos)).Length));
        PJ.Velocidad = rand.Next(1,10);
        PJ.Destreza = rand.Next(1,5);
        PJ.Fuerza = rand.Next(1,10);
        PJ.Nivel = rand.Next(1,10);
        PJ.Armadura = rand.Next(1,10);
        PJ.Salud = 100;
        PJ.FechaNac = ObtenerFechaNacimientoAleatoria();
        PJ.Edad = DateTime.Today.Year - PJ.FechaNac.Year;

        return PJ;
    }
    
    private DateTime ObtenerFechaNacimientoAleatoria()
    {
        DateTime fechaMin = new DateTime(1723, 1, 1);
        int rango = (DateTime.Today - fechaMin).Days;
        return fechaMin.AddDays(rand.Next(rango));
    }
}

class Program
{
    static void Main(string[] args)
    {
        FabricaPersonajes fabrica = new FabricaPersonajes();

        for (int i = 0; i < 5; i++)
        {
            Personajes personaje = fabrica.CrearPersonajeAleatorio();
            personaje.MostrarDatos();
            Console.WriteLine("----------------------");
            personaje.GuardarPersonajeJson("Personajes",".json");
        }

        Console.ReadLine();
    }
    
    
}


﻿using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

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

public class Personaje
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
    
    
}

class FabricaPersonajes
{
    Random rand = new Random();

    public Personaje CrearPersonajeAleatorio()
    {
        Personaje PJ = new Personaje();
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

public class PersonajesJson{
    public List<Personaje> LeerPersonajes(string nombreArchivo)
    {
        List<Personaje> listPersonajes = new List<Personaje>();

        string contenido = File.ReadAllText(nombreArchivo);
        listPersonajes = JsonSerializer.Deserialize<List<Personaje>>(contenido)!;

        return listPersonajes;
    }
    public void GuardarPersonajes( string nombreArchivo,List<Personaje> personajes){
        string contenido = JsonSerializer.Serialize(personajes);
        File.WriteAllText(nombreArchivo, contenido);
    }
    public bool Existe(string nombreArchivo)
{
    if (File.Exists(nombreArchivo))
    {
        string contenido = File.ReadAllText(nombreArchivo);
        return !string.IsNullOrEmpty(contenido);
    }

    return false;
}
}

class Program
{
    void Main(string[] args)
    {
        string nombreArchivo = "Personajes.json";
        PersonajesJson personajesJson = new PersonajesJson();
        List<Personaje> personajes;
        
        if (personajesJson.Existe(nombreArchivo))
        {
            personajes = personajesJson.LeerPersonajes(nombreArchivo);
        }else
        {
            FabricaPersonajes fabrica = new FabricaPersonajes();
            personajes = new List<Personaje>();

            for (int i = 0; i < 10; i++)
            {
                Personaje personaje = fabrica.CrearPersonajeAleatorio();
                personajes.Add(personaje);
            }

            personajesJson.GuardarPersonajes(nombreArchivo, personajes);
        }
        foreach (Personaje personaje in personajes)
        {
            personaje.MostrarDatos();
            Console.WriteLine("----------------------");
        }

        Console.ReadLine();
    }
    
    
}


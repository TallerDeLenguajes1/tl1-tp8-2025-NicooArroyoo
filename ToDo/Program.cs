using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


public class Tarea
{
    public int TareaID { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; } // Validar que esté entre 10 y 100
                                      // Puedes añadir un constructor y métodos auxiliares si lo consideras necesario
}



class Program
{


    public static void BusquedaTareasPorDescripcion(List<Tarea> tareasPendientes)
    {

        Console.Write("Ingrese la descripcion de la tarea a buscar: ");
        string stringDescrip = Console.ReadLine();

        List<Tarea> tarea = tareasPendientes.FindAll(t => t.Descripcion == stringDescrip);

        foreach (Tarea t in tarea)
        {
            Console.WriteLine($"ID: {t.TareaID}, Descripción: {t.Descripcion}, Duración: {t.Duracion} minutos");
        }
    }


    public static void MostrarTareas(List<Tarea> tarea, string nombre)
    {
        Console.WriteLine("\nTareas " + nombre + ":");
        foreach (Tarea t in tarea)
        {
            Console.WriteLine($"ID: {t.TareaID}, Descripción: {t.Descripcion}, Duración: {t.Duracion} minutos");
        }
    }





    static void Main()
    {
        List<Tarea> tareasPendientes = new List<Tarea>();

        Console.Write("¿Cuántas tareas querés generar?: ");
        string numString = Console.ReadLine();
        int num;

        while (!int.TryParse(numString, out num))
        {
            Console.Write("¿Cuántas tareas querés generar?: ");
            numString = Console.ReadLine();
        }

        for (int i = 0; i < num; i++)
        {
            Tarea nuevaTarea = new Tarea();
            nuevaTarea.TareaID = i + 1;

            //----------DESCRIPCION----------
            Console.Write("Ingrese la descripcion de la tarea " + nuevaTarea.TareaID + ": ");
            nuevaTarea.Descripcion = Console.ReadLine();

            //----------DURACION----------
            Console.Write("Ingrese la duracion de la tarea (minutos): ");
            string numeroString = Console.ReadLine();
            int numero;
            while (!int.TryParse(numeroString, out numero) || 10 > numero || numero > 100  )
            {
                Console.Write("Ingrese la duracion de la tarea (minutos): ");
                numeroString = Console.ReadLine();
            }
            nuevaTarea.Duracion = numero;

            tareasPendientes.Add(nuevaTarea); // la agrego a la lista
        }

        
         MostrarTareas(tareasPendientes, "pendientes"); 


        List<Tarea> tareasRealizadas = new List<Tarea>();

        Console.Write("Ingrese el ID de la tarea que completó: ");
        string tareaRealizadaID = Console.ReadLine();
        int id;

        if (int.TryParse(tareaRealizadaID, out id))
        {
            Tarea tarea = tareasPendientes.Find(t => t.TareaID == id);

            if (tarea != null)
            {
                tareasRealizadas.Add(tarea);
                tareasPendientes.Remove(tarea);
                Console.WriteLine("Tarea movida a realizadas.");
            }
            else
            {
                Console.WriteLine("Tarea no encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ERROR. No ingresó un número...");
        }


        MostrarTareas(tareasPendientes, "pendientes");

        MostrarTareas(tareasRealizadas, "realizadas");

        BusquedaTareasPorDescripcion(tareasPendientes);

    }


}


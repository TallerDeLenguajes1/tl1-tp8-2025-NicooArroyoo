using ProgramaListasTareas;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n  ======== MENÚ PRINCIPAL ========  ");
    Console.WriteLine("1. Crear tareas");
    Console.WriteLine("2. Mostrar tareas");
    Console.WriteLine("3. Marcar tarea pendiente como realizada");
    Console.WriteLine("4. Buscar tareas pendientes por descripción");
    Console.WriteLine("5. Salir");

    string input;
    int opcionNum;
    do
    {
        Console.Write("Seleccione una opción (1 a 5): ");
        input = Console.ReadLine();
    } while (!int.TryParse(input, out opcionNum) || opcionNum > 5 || opcionNum < 1);

    switch (opcionNum)
    {
        case 1:
            tareasPendientes = CrearTareas(tareasPendientes);
            break;
        case 2:
            MostrarTareas(tareasPendientes, "pendientes");
            MostrarTareas(tareasRealizadas, "realizadas");
            break;
        case 3:
            pendientesArealizadas(tareasRealizadas, tareasPendientes);
            break;
        case 4:
            BusquedaTareasPorDescripcion(tareasPendientes);
            break;
        case 5:
            salir = true;
            break;
    }
}    



List<Tarea> CrearTareas(List<Tarea> tareasPendientes)
{
    string numString;
    int num;
    do
    {
        Console.Write("\nCuántas tareas querés generar?: ");
        numString = Console.ReadLine();
    }
    while (!int.TryParse(numString, out num));

    string[] descripciones = { "Leer", "Estudiar", "Comprar", "Limpiar", "Cocinar", "Ejercitar", "Escribir" };
    Random rnd = new Random();

    for (int i = 0; i < num; i++)
    {
        Tarea nuevaTarea = new Tarea();
        nuevaTarea.TareaID = tareasPendientes.Count + 1;
        nuevaTarea.Descripcion = descripciones[rnd.Next(descripciones.Length)];
        nuevaTarea.Duracion = rnd.Next(10, 101); // entre 10 y 100 minutos
        tareasPendientes.Add(nuevaTarea);
    }
    Console.WriteLine($"\nSe generaron {num} tareas aleatorias.");
    return tareasPendientes;
}



void BusquedaTareasPorDescripcion(List<Tarea> tareasPendientes)
{
    Console.Write("\nIngrese la descripcion de la tarea a buscar: ");
    string stringDescrip = Console.ReadLine();

    List<Tarea> tarea = tareasPendientes.FindAll(t => t.Descripcion == stringDescrip);

    if (tarea.Count == 0)
    {
        Console.WriteLine("\nNo se encontraron tareas con esa descripción.");
    }
    else
    {
        MostrarTareas(tarea, "buscadas por descripcion:");
    }    
}


 void MostrarTareas(List<Tarea> tarea, string nombre)
{
    Console.WriteLine("\nTareas " + nombre + ":");
    foreach (Tarea t in tarea)
    {
        t.Mostrar();
    }
}




List<Tarea> pendientesArealizadas(List<Tarea> realizadas, List<Tarea> pendientes)
{
    Console.Write("\nIngrese el ID de la tarea que completó: ");
    string tareaRealizadaID = Console.ReadLine();
    int id;

    if (int.TryParse(tareaRealizadaID, out id))
    {
        Tarea tarea = pendientes.Find(t => t.TareaID == id);

        if (tarea != null)
        {
            realizadas.Add(tarea);
            pendientes.Remove(tarea);
            Console.WriteLine("\nTarea movida a realizadas.");
        }
        else
        {
            Console.WriteLine("\nTarea no encontrada.");
        }
    }
    else
    {
        Console.WriteLine("\nERROR. No ingresó un número...");
    }
    return realizadas;
}





/*List<Tarea> crearTareas(List<Tarea> tareasPendientes)
{
    int num;
    string numString;
    do
    {
        Console.Write("\n¿Cuántas tareas querés generar?: ");
        numString = Console.ReadLine();
    }
    while (!int.TryParse(numString, out num));

    for (int i = 0; i < num; i++)
    {
        Tarea nuevaTarea = new Tarea();
        nuevaTarea.TareaID = tareasPendientes.Count + 1;

        //----------DESCRIPCION----------
        Console.Write("\nIngrese la descripcion de la tarea " + nuevaTarea.TareaID + ": ");
        nuevaTarea.Descripcion = Console.ReadLine();

        //----------DURACION----------
        string numeroString;
        int numero;
        do
        {
            Console.Write("\nIngrese la duración de la tarea (minutos): ");
            numeroString = Console.ReadLine();
        }
        while (!int.TryParse(numeroString, out numero) || numero < 10 || numero > 100);

        nuevaTarea.Duracion = numero;

        tareasPendientes.Add(nuevaTarea); // la agrego a la lista
    }
    return tareasPendientes;
}*/

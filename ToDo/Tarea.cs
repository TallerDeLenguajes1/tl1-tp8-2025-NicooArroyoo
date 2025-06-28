namespace ProgramaListasTareas;

public class Tarea
{
    private int tareaID;
    private string descripcion;
    private int duracion;

    public int TareaID { get => tareaID ; set => tareaID = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    public void Mostrar()
    {
        Console.WriteLine($"ID: {TareaID}, Descripción: {Descripcion}, Duración: {Duracion} minutos");
    }

}




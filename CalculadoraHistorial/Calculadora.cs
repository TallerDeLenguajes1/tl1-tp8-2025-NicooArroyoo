namespace CalculadoraHistorial;

public class Calculadora
{
    private double dato = 0;
   
    public double Dato
    {
        get => dato;
        set => dato = value;
    }

    private List<Operacion> listaDeOperaciones = new List<Operacion>();

    public List<Operacion> ListaDeOperaciones
    {
        get => listaDeOperaciones;
    }

    public void Sumar(double termino)
    {
        Operacion nueva = new Operacion(dato, termino, TipoOperacion.Suma);
        dato = dato + termino;
        listaDeOperaciones.Add(nueva);
    }

    public void Restar(double termino)
    {
        Operacion nueva = new Operacion(dato, termino, TipoOperacion.Resta);
        dato = dato - termino;
        listaDeOperaciones.Add(nueva);
    }

    public void Multiplicar(double termino)
    {
        Operacion nueva = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
        dato = dato * termino;
        listaDeOperaciones.Add(nueva);
    }

    public void Dividir(double termino)
    {
        Operacion nueva = new Operacion(dato, termino, TipoOperacion.Division);
        dato = dato / termino;
        listaDeOperaciones.Add(nueva);
    }

    public void Limpiar()
    {
        Operacion nueva = new Operacion(dato, 0, TipoOperacion.Limpiar);
        dato = 0;
        listaDeOperaciones.Add(nueva);
    }

    
}

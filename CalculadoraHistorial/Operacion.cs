namespace CalculadoraHistorial;

public class Operacion
{
    private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
    private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior
    private TipoOperacion operacion;// El tipo de operación realizada

    public double Resultado()
    {
        double resultadoSalida;
        switch (operacion)
        {
            case TipoOperacion.Suma:
                resultadoSalida = resultadoAnterior + nuevoValor;
                break;
            case TipoOperacion.Resta:
                resultadoSalida = resultadoAnterior - nuevoValor;
                break;
            case TipoOperacion.Multiplicacion:
                resultadoSalida = resultadoAnterior * nuevoValor;
                break;
            case TipoOperacion.Division:
                resultadoSalida = resultadoAnterior / nuevoValor;
                break;
            default:
                resultadoSalida = 0;
                break;
        }
        return resultadoSalida;
    }

    // Propiedad pública para acceder al nuevo valor utilizado en la operación
    public double NuevoValor
    {
        get => nuevoValor;
    }

    public TipoOperacion TipoDeOperacion
    {
        get => operacion;
    }

     public double ResultadoAnterior
    {
        get => resultadoAnterior;
    }
   

    public Operacion(double ResultadoAnterior, double NuevoValor_constructor, TipoOperacion Operacion)
    {
        resultadoAnterior = ResultadoAnterior;
        nuevoValor = NuevoValor_constructor;
        operacion = Operacion;
    }
}

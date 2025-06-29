using CalculadoraHistorial;

void mostrarMenu()
{
    Console.WriteLine("\n\n<<<<<< CALCULADORA UNT >>>>>>");
    Console.WriteLine("1 --> Sumar");
    Console.WriteLine("2 --> Restar");
    Console.WriteLine("3 --> Multiplicar");
    Console.WriteLine("4 --> Dividir");
    Console.WriteLine("5 --> Limpiar");
    Console.WriteLine("6 --> Salir");
    Console.Write("\nSeleccione una opcion: ");
}

Calculadora calculadora = new Calculadora();

int opcion = 0;
double termino;

while (opcion != 6)
{
    mostrarMenu();

    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        if (opcion > 0 && opcion < 6)
        {
            do
            {
                Console.WriteLine("Ingrese un numero para realizar la operacion:");
            } while (!double.TryParse(Console.ReadLine(), out termino));

            switch (opcion)
            {
                case 1:
                    //Console.Write(calculadora.Resultado + " + " + termino + " = ");
                    calculadora.Sumar(termino);
                    //Console.WriteLine(calculadora.Resultado);
                    break;

                case 2:
                    //Console.Write(calculadora.Resultado + " - " + termino + " = ");
                    calculadora.Restar(termino);
                    //Console.WriteLine(calculadora.Resultado);
                    break;

                case 3:
                    //Console.Write(calculadora.Resultado + " * " + termino + " = ");
                    calculadora.Multiplicar(termino);
                    //Console.WriteLine(calculadora.Resultado);
                    break;

                case 4:
                    //Console.Write(calculadora.Resultado + " / " + termino + " = ");
                    calculadora.Dividir(termino);
                    //Console.WriteLine(calculadora.Resultado);
                    break;

                case 5:
                    //Console.WriteLine("Limpiando la memoria...");
                    calculadora.Limpiar();
                    break;

                default:
                    break;
            }

            Console.WriteLine("Resultado de la operacion seleccionada: " + calculadora.Dato);
        }

    }
}

Console.WriteLine("\nHistorial de operaciones realizadas:");
for (int i = 0; i < calculadora.ListaDeOperaciones.Count; i++)
{
    Console.WriteLine("-------------------------------------");
    Console.WriteLine("Operacion: " + calculadora.ListaDeOperaciones[i].TipoDeOperacion);
    Console.WriteLine("Dato: " + calculadora.ListaDeOperaciones[i].ResultadoAnterior);
    Console.WriteLine("Termino a operar: " + calculadora.ListaDeOperaciones[i].NuevoValor);
    Console.WriteLine("Resultado: " + calculadora.ListaDeOperaciones[i].Resultado());
    Console.WriteLine("-------------------------------------\n");
}
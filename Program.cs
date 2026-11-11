// Trabajo de Programacion - UT2: Tienda de Videojuegos Pixel Shop

bool salir = false;

// Variables de la caja y estadisticas
int totalVentas = 0;
double dineroCaja = 0.0;
double ventaMasCara = 0.0;
string clienteEstrella = "";

while (salir == false)
{
    Console.WriteLine();
    Console.WriteLine("--- TIENDA DE VIDEOJUEGOS PIXEL SHOP ---");
    Console.WriteLine("1. Hacer nueva venta");
    Console.WriteLine("2. Ver caja y estadisticas");
    Console.WriteLine("3. Salir");
    Console.Write("Elige una opcion (1-3): ");

    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        Console.WriteLine();
        Console.WriteLine("--- NUEVA VENTA ---");

        // 1. Pedir nombre del cliente 
        string nombre = "";
        while (nombre == "")
        {
            Console.Write("Dime el nombre del cliente: ");
            nombre = Console.ReadLine();

            if (nombre == "")
            {
                Console.WriteLine("El nombre no puede estar en blanco. Prueba otra vez.");
            }
        }

        // 2. Elegir producto principal
        Console.WriteLine();
        Console.WriteLine("Elige el producto principal:");
        Console.WriteLine("1. Videojuego Novedad (59.99 EUR)");
        Console.WriteLine("2. Limpieza de Consola (35.00 EUR)");
        Console.WriteLine("3. Tarjeta Regalo 50 EUR (50.00 EUR)");
        Console.Write("Selecciona opcion (1-3): ");

        string eleccionProducto = Console.ReadLine();
        double precioProducto = 0.0;
        string nombreProducto = "";

        if (eleccionProducto == "1")
        {
            precioProducto = 59.99;
            nombreProducto = "Videojuego Novedad";
        }
        else if (eleccionProducto == "2")
        {
            precioProducto = 35.00;
            nombreProducto = "Limpieza de Consola";
        }
        else
        {
            precioProducto = 50.00;
            nombreProducto = "Tarjeta Regalo 50E";
        }

        // 3. Extras opcionales 
        double precioExtras = 0.0;
        bool buscandoExtras = true;
        bool tieneGarantia = false;
        bool tieneFunda = false;
        bool tieneEnvoltorio = false;

        while (buscandoExtras == true)
        {
            Console.WriteLine();
            Console.WriteLine("¿Quieres anadir algun extra?");
            Console.WriteLine("1. Garantia ampliada (9.99 EUR)");
            Console.WriteLine("2. Funda coleccionable (4.99 EUR)");
            Console.WriteLine("3. Envoltorio de regalo (2.50 EUR)");
            Console.WriteLine("4. Terminar con los extras");
            Console.Write("Elige una opcion: ");

            string opcionExtra = Console.ReadLine();

            if (opcionExtra == "1" && tieneGarantia == false)
            {
                precioExtras = precioExtras + 9.99;
                tieneGarantia = true;
                Console.WriteLine("-> Garantia anadida.");
            }
            else if (opcionExtra == "2" && tieneFunda == false)
            {
                precioExtras = precioExtras + 4.99;
                tieneFunda = true;
                Console.WriteLine("-> Funda anadida.");
            }
            else if (opcionExtra == "3" && tieneEnvoltorio == false)
            {
                precioExtras = precioExtras + 2.50;
                tieneEnvoltorio = true;
                Console.WriteLine("-> Envoltorio anadido.");
            }
            else if (opcionExtra == "4")
            {
                buscandoExtras = false;
            }
            else
            {
                Console.WriteLine("Opcion invalida o ya habias metido ese extra antes.");
            }
        }

        // 4. Condicion especifica: Envio a domicilio o recogida
        Console.WriteLine();
        Console.WriteLine("Metodo de entrega:");
        Console.WriteLine("1. Recogida en tienda (Gratis)");
        Console.WriteLine("2. Envio a casa express (6.00 EUR)");
        Console.Write("Elige una opcion: ");

        string tipoEnvio = Console.ReadLine();
        double costeEnvio = 0.0;
        string direccionCliente = "";

        if (tipoEnvio == "2")
        {
            costeEnvio = 6.00;
            Console.Write("Escribe la direccion de envio: ");
            direccionCliente = Console.ReadLine();
        }

        // 5. Calculos y descuento (si pasa de 70 euros, 10% de descuento)
        double subtotal = precioProducto + precioExtras + costeEnvio;
        double descuento = 0.0;

        if (subtotal > 70.0)
        {
            descuento = subtotal * 0.10;
            Console.WriteLine();
            Console.WriteLine("¡Superas los 70 euros! Tienes un 10% de descuento.");
        }

        double totalFinal = subtotal - descuento;

        // Actualizar datos de caja
        totalVentas = totalVentas + 1;
        dineroCaja = dineroCaja + totalFinal;

        if (totalFinal > ventaMasCara)
        {
            ventaMasCara = totalFinal;
            clienteEstrella = nombre;
        }

        // 6. Ticket final por pantalla
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("            TICKET DE VENTA             ");
        Console.WriteLine("========================================");
        Console.WriteLine("Cliente: " + nombre);
        Console.WriteLine("Producto: " + nombreProducto + " (" + precioProducto + " EUR)");
        
        if (precioExtras > 0)
        {
            Console.WriteLine("Extras: " + precioExtras + " EUR");
        }
        
        if (costeEnvio > 0)
        {
            Console.WriteLine("Envio express (" + direccionCliente + "): " + costeEnvio + " EUR");
        }
        
        if (descuento > 0)
        {
            Console.WriteLine("Descuento: -" + descuento.ToString("F2") + " EUR");
        }
        
        Console.WriteLine("TOTAL A PAGAR: " + totalFinal.ToString("F2") + " EUR");
        Console.WriteLine("========================================");
    }
    else if (opcion == "2")
    {
        Console.WriteLine();
        Console.WriteLine("--- ESTADISTICAS DE LA CAJA ---");

        if (totalVentas == 0)
        {
            Console.WriteLine("Todavia no se ha hecho ninguna venta.");
        }
        else
        {
            double mediaVentas = dineroCaja / totalVentas;
            Console.WriteLine("Ventas totales hechas: " + totalVentas);
            Console.WriteLine("Dinero total en caja: " + dineroCaja.ToString("F2") + " EUR");
            Console.WriteLine("Media por venta: " + mediaVentas.ToString("F2") + " EUR");
            Console.WriteLine("Venta mas cara: " + ventaMasCara.ToString("F2") + " EUR (Cliente: " + clienteEstrella + ")");
        }
    }
    else if (opcion == "3")
    {
        salir = true;
        Console.WriteLine();
        Console.WriteLine("Cerrando aplicacion. Resumen final:");
        Console.WriteLine("Ventas totales: " + totalVentas + " | Recaudacion: " + dineroCaja.ToString("F2") + " EUR");
        Console.WriteLine("¡Hasta luego!");
    }
    else
    {
        Console.WriteLine("Error: Tienes que marcar 1, 2 o 3.");
    }
}
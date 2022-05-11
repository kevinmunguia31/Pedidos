using MySql.Data.MySqlClient;
using System;
using System.Threading;

namespace Pedidos
{
    class Program
    {

        private static MySqlConnection conn;
        static void connect()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "root";
            string bd = "pedidos";

            string connString = String.Format("server={0}; port={1}; user id={2}; password={3}; database={4}", servidor, puerto, usuario, password, bd);

            conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                Console.WriteLine("Conexion Exitosa");

               // conn.Close();
            } catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connString);
            }
        }


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            
          //  int num1 = 0; int num2 = 0;
            int op;
            Cliente _cliente = new Cliente();
            bool salir = false;
            MySqlDataReader reader = null;
            string sql = "";

            while (!salir) 
            {
                Console.WriteLine("\t\tProgama de Pedidos de Articulos\r");
                Console.WriteLine("\t\t--------------------------------\n");
                Console.WriteLine("Seleccione la opcion que desea:");
                Console.WriteLine("\t1 - Ver lista de Clientes");
                Console.WriteLine("\t2 - Ver lista de Pedidos");
                Console.WriteLine("\t3 - Ver lista de Articulos");
                Console.WriteLine("\t4 - Registrar Clientes");
                Console.WriteLine("\t5 - Registrar Pedidos");
                Console.WriteLine("\t6 - Registrar Articulos");
                Console.WriteLine("\t7 - Salir");
                Console.Write("Opcion? ");
                op = Convert.ToInt32(Console.ReadLine());

                // Use a switch statement to do the math.
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\t\tLista de Cliente:\r");
                        Console.WriteLine("\t\t------------------------\n");
                        Console.WriteLine("\n");
                        sql = "Select * from cliente";
                        try
                        {
                            connect();
                            MySqlCommand comando = new MySqlCommand(sql, conn);
                            reader = comando.ExecuteReader();
                            if (reader.HasRows)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine("Cod\t Nombre\t Apellido\t Direccion\t\t Foto\t Edad\t Salario\t");
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                while (reader.Read())
                                {
                                    Console.WriteLine("|" + reader.GetString(0) + " |   " + reader.GetString(1) + " |   " + reader.GetString(2) + " |   " + reader.GetString(3) + " |  " + reader.GetString(4) + " |  " + reader.GetString(5) + " |     " + reader.GetString(6) + " |");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                                }
                            }

                        }
                        catch (MySqlException ex) { Console.WriteLine(ex.Message.ToString()); }
                        Console.WriteLine("Presione Enter Para volver al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\t\tLista de Pedidos:\r");
                        Console.WriteLine("\t\t------------------------\n");
                        sql = "SELECT pedido.codigo, cliente.nombre as cliente, articulos.nombre as articulo, pedido.cantidad, pedido.precio_total, pedido.fecha from pedido inner join cliente on pedido.cod_cliente = cliente.codigo inner join articulos on pedido.cod_articulo = articulos.codigo";

                        try
                        {
                            connect();
                            MySqlCommand comando = new MySqlCommand(sql, conn);
                            reader = comando.ExecuteReader();
                            if (reader.HasRows)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine("Cod\t Cliente\t Articulo\t Cantidad\t Precio Total\t\t fecha\t");
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                while (reader.Read())
                                {
                                    Console.WriteLine("|" + reader.GetString(0) + " |\t   " + reader.GetString(1) + " |\t   " + reader.GetString(2) + " |\t\t   " + reader.GetString(3) + " |\t  " + reader.GetString(4) + " | \t " + reader.GetString(5) + " |");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                                }
                            }

                        }
                        catch (MySqlException ex) { Console.WriteLine(ex.Message.ToString()); }
                        Console.WriteLine("Presione Enter Para volver al menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\t\tLista de Articulos:\r");
                        Console.WriteLine("\t\t------------------------\n");

                        sql = "Select * from articulos";
                        try
                        {
                            connect();
                            MySqlCommand comando = new MySqlCommand(sql, conn);
                            reader = comando.ExecuteReader();
                            if (reader.HasRows)
                            {
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                Console.WriteLine("Codigo\t Nombre\t Marca\t Modelo\t Precio\t Cantidad");
                                Console.WriteLine("------------------------------------------------------------------------------------------------");
                                while (reader.Read())
                                {
                                    Console.WriteLine("|" + reader.GetString(0) + " |   " + reader.GetString(1) + " |   " + reader.GetString(2) + " |   " + reader.GetString(3) + " |    " + reader.GetString(4) + " |  " + reader.GetString(5) + " |");
                                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                                }
                            }

                        }
                        catch (MySqlException ex) { Console.WriteLine(ex.Message.ToString()); }
                        Console.WriteLine("Presione Enter Para volver al menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("\t\tRegistro de Cliente:\r");
                        Console.WriteLine("------------------------\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("Ingrese el Nombre del Cliente: \n");
                        _cliente.Nombre = Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine("\t\tRegistro de Pedidos:\r");
                        Console.WriteLine("------------------------\n");
                        Console.WriteLine("\n");
                        break;
                    case 6:
                        Console.WriteLine("\t\tRegistro de Articulos:\r");
                        Console.WriteLine("------------------------\n");
                        Console.WriteLine("\n");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion entre 1 y 7 \n");
                        Console.WriteLine("Cargando menu...");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                }
            }



            // Primer Menu de Opciones
            
            // Wait for the user to respond before closing.
            Console.Write("Presione cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}

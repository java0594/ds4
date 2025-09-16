using System;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instacia de Clase.
            client.FirstName = "Juan";
            client.LastName = "Vasquez";
            client.Age = 30;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }


    public class Client
    {
        //Declarando variables de instancia de Clase.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


        public string GetFullName()
        {
            //Utilizando variables de instancia dentro de metodos de la clase.
            return FirstName + " " + LastName;
        }
    }

}
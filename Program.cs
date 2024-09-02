using System;
using System.Runtime.CompilerServices;

namespace Drone {
    
    class Program {

        static void Main(string[] args) {

            Menu();
            
        }   

        static void Menu () {
            Console.WriteLine("O que você deseja fazer com o drone? ");
            Console.WriteLine("1 - Voar");
            Console.WriteLine("0 - Sair");
            int op = int.Parse(Console.ReadLine());
            switch (op) {
                case 1: Fly(); break;
                case 0: System.Environment.Exit(0); break;
                default: Console.WriteLine("Valor Invalido"); Menu();break;
            }
            
        }

        static void Fly () {
            Drone drone = new Drone();
            
            drone.Height = 0.5;
            
            while (drone.Height <= 24.5 && drone.Height >= 0.5) {
                int direcao = 0;
                Console.WriteLine("1 - Subir");
                Console.WriteLine("2 - Descer");
                Console.WriteLine("0 - Voltar");
                direcao = int.Parse(Console.ReadLine());

                switch (direcao) {
                    case 1: drone.Fly(0.5); break;
                    case 2: drone.Fly(-0.5); break;
                    case 0: Menu(); break;
                    default: Console.WriteLine("Invalido"); break;
                }
                double voar = drone.Height;
                Console.WriteLine($"Sua altura atual é {voar}");
            }
            if (drone.Height >= 25)
                Console.WriteLine("Você chegou no maximo");
            else 
                Console.WriteLine("Você está no chão");

            Menu();
        }

    }

}

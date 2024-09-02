using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Drone {
    
    class Program {
        
        static void Main(string[] args) {
            
            Drone drone = new Drone();

            Menu(drone);
            
        }   

        static void Menu (Drone drone) {

            Console.WriteLine("O que você deseja fazer com o drone? ");
            Console.WriteLine("1 - Voar");
            Console.WriteLine("2 - Direção");
            Console.WriteLine("0 - Sair");
            int op = int.Parse(Console.ReadLine());
            switch (op) {
                case 1: Fly(drone); break;
                case 2: Direction(drone); break;
                case 0: System.Environment.Exit(0); break;
                default: Console.WriteLine("Valor Invalido"); Menu(drone);break;
            }
            
        }

        static void Fly (Drone drone) {
          
            while (drone.Height <= 24.5 && drone.Height >= 0) {
                int direction = 0;
                Console.WriteLine("1 - Subir");
                Console.WriteLine("2 - Descer");
                Console.WriteLine("3 - Escrever Valor");
                Console.WriteLine("0 - Voltar");
                direction = int.Parse(Console.ReadLine());
            
                switch (direction) {
                    case 1: drone.Fly(0.5); break;
                    case 2: drone.Fly(-0.5); break;
                    case 3: WriteHeight(drone); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Invalido"); break;
                }
                if (drone.Height <= 0) {
                    drone.Height = 0;
                    break; 
                }

                Console.WriteLine($"Sua altura atual é {drone.Height}");
            }
            
            if (drone.Height >= 25)
                Console.WriteLine("Você chegou no maximo");
            else 
                Console.WriteLine("Você está no chão");

            Menu(drone);
        }

        static void WriteHeight (Drone drone) {
            
            Console.WriteLine("Digite qual altura você deseja: ");
            drone.Height = double.Parse(Console.ReadLine());
        }

        static void Direction (Drone drone) {

            while (drone.Angle <= 360 && drone.Angle >= 0) {
                int direction = 0;
                Console.WriteLine("1 - Direita");
                Console.WriteLine("2 - Esquerda");
                Console.WriteLine("3 - Escrever Valor");
                Console.WriteLine("0 - Voltar");
                direction = int.Parse(Console.ReadLine());
            
                switch (direction) {
                    case 1: drone.Direction(5); break;
                    case 2: drone.Direction(-5); break;
                    case 3: WriteDirection(drone); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Invalido"); break;
                }
                
                if (drone.Angle > 360) {
                    drone.Angle -= 360;
                }
                else if (drone.Angle < 0) {
                    drone.Angle += 360;
                }

                Console.WriteLine($"Sua direção atual é {drone.Angle}");
            }

        }
        
        static void WriteDirection (Drone drone) {
            Console.WriteLine("Digite qual direção você deseja: ");
            drone.Angle = int.Parse(Console.ReadLine());
        }

        static void MoveVelocity (Drone drone) {

            while (drone.Speed <= 15 && drone.Speed >= 0) {
                double velocity = 0;
                Console.WriteLine("1 - Aumentar");
                Console.WriteLine("2 - Diminuir");
                Console.WriteLine("0 - Voltar");
                velocity = double.Parse(Console.ReadLine());
            
                switch (velocity) {
                    case 1: drone.MoveVelocity(0.5); break;
                    case 2: drone.MoveVelocity(-0.5); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Invalido"); break;
                }

                Console.WriteLine($"Sua velocidade atual é {drone.Speed}");

            }

        }
    }

}

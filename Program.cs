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
            Console.WriteLine("2 - Direção do Drone");
            Console.WriteLine("3 - Velocidade");
            Console.WriteLine("4 - Aproximar de um Objeto");
            Console.WriteLine("0 - Sair");
            int op = int.Parse(Console.ReadLine());
            switch (op) {
                case 1: Fly(drone); break;
                case 2: Direction(drone); break;
                case 3: MoveVelocity(drone); break;
                case 4: ApproxObj(drone); break;
                case 0: System.Environment.Exit(0); break;
                default: Console.WriteLine("Valor Inválido"); Menu(drone);break;
            }
            
        }

        static void Fly (Drone drone) {
          
            while (drone.Height <= 24.5 && drone.Height >= 0) {
                short direction = 0;
                Console.WriteLine("Esse é o menu de voou, o que deseja fazer? ");
                Console.WriteLine("1 - Subir");
                Console.WriteLine("2 - Descer");
                Console.WriteLine("3 - Escrever Valor");
                Console.WriteLine("0 - Voltar");
                direction = short.Parse(Console.ReadLine());
            
                switch (direction) {
                    case 1: drone.Fly(0.5); break;
                    case 2: drone.Fly(-0.5); break;
                    case 3: WriteHeight(drone); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
                if (drone.Height <= 0) {
                    drone.Height = 0;
                    break; 
                }

                Console.WriteLine($"Sua altura atual é de {drone.Height}m");
            }
            
            if (drone.Height >= 25) {
                Console.WriteLine("O drone chegou na altura maxima");
                Thread.Sleep(1000);
            }
            else {
                Console.WriteLine("O drone está no chão");
                Thread.Sleep(1000);
            }
            Menu(drone);
        }

        static void WriteHeight (Drone drone) {
            
            Console.WriteLine("Digite qual altura você deseja: ");
            drone.Height = double.Parse(Console.ReadLine());
        }

        static void Direction (Drone drone) {

            while (drone.Angle <= 360 && drone.Angle >= 0) {
                short direction = 0;
                Console.WriteLine("Esse é o menu de direçao, o que deseja fazer? ");
                Console.WriteLine("1 - Direita");
                Console.WriteLine("2 - Esquerda");
                Console.WriteLine("3 - Escrever Valor");
                Console.WriteLine("0 - Voltar");
                direction = short.Parse(Console.ReadLine());
            
                switch (direction) {
                    case 1: drone.Direction(5); break;
                    case 2: drone.Direction(-5); break;
                    case 3: WriteDirection(drone); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
                
                if (drone.Angle > 360) {
                    drone.Angle -= 360;
                }
                else if (drone.Angle < 0) {
                    drone.Angle += 360;
                }

                Console.WriteLine($"O drone virou {drone.Angle}°");
            }

        }
        
        static void WriteDirection (Drone drone) {
            Console.WriteLine("Digite qual direção você deseja: ");
            drone.Angle = int.Parse(Console.ReadLine());
        }

        static void MoveVelocity (Drone drone) {

            while (drone.Speed < 15 && drone.Speed >= 0) {
                short velocity = 0;
                Console.WriteLine("Esse é o menu de velocidade, o que deseja fazer? ");
                Console.WriteLine("1 - Aumentar");
                Console.WriteLine("2 - Diminuir");
                Console.WriteLine("0 - Voltar");
                velocity = short.Parse(Console.ReadLine());
            
                switch (velocity) {
                    case 1: drone.MoveVelocity(0.5); break;
                    case 2: drone.MoveVelocity(-0.5); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
                
                if (drone.Speed == 15) {
                    Console.WriteLine("O drone chegou na velocidade máxima.");
                    Thread.Sleep(1000);
                    break;
                }
                else if (drone.Speed <= 0) {
                    drone.Speed = 0;
                    Console.WriteLine("O drone está parado.");
                    Thread.Sleep(1000);
                    break;
                }

                Console.WriteLine($"Sua velocidade atual é de {drone.Speed}m/s");
            }
            Menu(drone);
        }
    
        static void ApproxObj (Drone drone) {

            if (drone.Speed == 0) {
                drone.Approximation = true;
            }       
            else if (drone.Speed > 0) {
                drone.Approximation = false;
                Console.WriteLine("O drone precisa estar parado para se aproximar de um objeto");
                Thread.Sleep(2000);
            }

            while (drone.Approximation) {
                short action = 0;
                Console.WriteLine("O drone encontrou um objeto, O que deseja fazer? ");
                Console.WriteLine("1 - Interagir");
                Console.WriteLine("0 - Sair");
                action = short.Parse(Console.ReadLine());

                switch (action) {
                    case 1: Console.Write("teste"); break;
                    case 0: MoveVelocity(drone); break;
                    default: Console.WriteLine("Invalido"); break;
                }
            }
            Menu(drone);
        }
    }

}

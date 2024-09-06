using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Drone {
    
    class Program {
        
        static void Main(string[] args) {
            
            Drone drone = new Drone();

            Menu(drone);
            
        }   

        static void Menu (Drone drone) {
            Console.Clear();

            int op;

            try
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   O que você deseja fazer com o drone?                                  ");
                Console.WriteLine("                                   1 - Voar............................                                  ");
                Console.WriteLine("                                   2 - Direção do Drone................                                  ");
                Console.WriteLine("                                   3 - Velocidade......................                                  ");
                Console.WriteLine("                                   4 - Aproximar de um Objeto..........                                  ");
                Console.WriteLine("                                   0 - Sair............................                                  ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                op = int.Parse(Console.ReadLine());
            }
            catch (Exception erro)
            {  
                Console.WriteLine($"Houve um erro de digitação {erro.Message}"); 
                Console.WriteLine("Voltando para o menu.............");
                Console.ReadLine(); 
                Menu(drone);
                throw;
            }

            switch (op) {
                case 1: Fly(drone); break;
                case 2: Direction(drone); break;
                case 3: MoveVelocity(drone); break;
                case 4: ApproxObj(drone); break;
                case 0: System.Environment.Exit(0); break;
                default: Console.WriteLine("Valor Inválido"); break;
            }
            
        }

        static void Fly (Drone drone) {
            Console.Clear();
          
            while (drone.Height <= 24.5 && drone.Height >= 0) {
                Console.Clear();
                short direction;

                try {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                   Esse é o menu de voo, o que deseja fazer?                                    ");
                    Console.WriteLine($"                                   Sua altura atual é de {drone.Height}m");
                    Console.WriteLine("                                   1 - Subir.................................                                   ");
                    Console.WriteLine("                                   2 - Descer................................                                   ");
                    Console.WriteLine("                                   3 - Escrever Valor........................                                   ");
                    Console.WriteLine("                                   0 - Voltar................................                                   ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    direction = short.Parse(Console.ReadLine());
                }
                catch (Exception erro) {
                    Console.WriteLine($"Houve um erro de digitação{erro.Message}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine(); 
                    Menu(drone);
                    throw;
                }
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
            }

            if (drone.Height >= 25) {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   O drone chegou na altura maxima                                   ");
                Console.WriteLine($"                                   Sua altura atual é de {drone.Height}m");
                Console.WriteLine("                                   O que fazer....................                                   ");
                Console.WriteLine("                                   1 - Descer.....................                                   ");
                Console.WriteLine("                                   2 - Escrever Valor.............                                   ");
                Console.WriteLine("                                   3 - Voltar.....................                                   ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                short direction = short.Parse(Console.ReadLine());

                switch (direction)
                {
                    case 1: drone.Fly(-0.5); break;
                    case 2: WriteHeight(drone); break;
                    case 3: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
            }
            else {
                Console.Clear();
                Console.WriteLine("------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   O drone está no chão                                   ");
                Console.WriteLine("                                   O que fazer.........                                   ");
                Console.WriteLine("                                   1 - Subir...........                                   ");
                Console.WriteLine("                                   2 - Escrever Valor..                                   ");
                Console.WriteLine("                                   0 - Voltar..........                                   ");
                Console.WriteLine("------------------------------------------------------------------------------------------");
                short direction = short.Parse(Console.ReadLine());

                switch (direction)
                {
                    case 1: drone.Fly(0.5); break;
                    case 2: WriteHeight(drone); break;
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
            }
            Menu(drone);
        }

        static void WriteHeight (Drone drone) {
            Console.Clear();
            
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                   Digite qual altura você deseja:                                   ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            drone.Height = double.Parse(Console.ReadLine());

            if (drone.Height > 25) {
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   A altura maxima é de 25 metros                                   ");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                drone.Height = 25;
            }
            
        }

        static void Direction (Drone drone) {
            Console.Clear();

            while (drone.Angle <= 360 && drone.Angle >= 0) {
                Console.Clear();
                short direction;
                try {
                    Console.WriteLine("                                   Esse é o menu de direçao, o que deseja fazer?                                   ");
                    Console.WriteLine($"                                  O drone virou {drone.Angle}°");
                    Console.WriteLine("                                   1 - Direita..................................                                   ");
                    Console.WriteLine("                                   2 - Esquerda.................................                                   ");
                    Console.WriteLine("                                   3 - Escrever Valor...........................                                   ");
                    Console.WriteLine("                                   0 - Voltar...................................                                   ");
                    direction = short.Parse(Console.ReadLine());
                }
                catch (Exception erro) {
                    Console.WriteLine($"Houve um erro de digitação{erro.Message}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine();
                    Menu(drone);
                    throw;
                }
            
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
            }

        }
        
        static void WriteDirection (Drone drone) {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                   Digite quantos graus você deseja virar:                                   ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            drone.Angle = int.Parse(Console.ReadLine());

            if (drone.Angle > 360) {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   Esse é um valor muito alto. Digite novamente                                   ");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                drone.Angle = int.Parse(Console.ReadLine());
            }
            
        }

        static void MoveVelocity (Drone drone) {
            Console.Clear();

            while (drone.Speed < 15 && drone.Speed >= 0) {
                Console.Clear();
                short velocity;
                try {
                    Console.WriteLine("                                   Esse é o menu de velocidade, o que deseja fazer?                                   ");
                    Console.WriteLine($"                                  Sua velocidade atual é de {drone.Speed}m/s");
                    Console.WriteLine("                                   1 - Aumentar....................................                                   ");
                    Console.WriteLine("                                   2 - Diminuir....................................                                   ");
                    Console.WriteLine("                                   0 - Voltar......................................                                   ");
                    velocity = short.Parse(Console.ReadLine());
                }
                catch (Exception erro) {
                    Console.WriteLine($"Houve um erro de digitação{erro.Message}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine();
                    Menu(drone);
                    throw;
                }
            
                switch (velocity) {
                    case 1: drone.MoveVelocity(0.5); break;
                    case 2: drone.MoveVelocity(-0.5); break; 
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
                
                if (drone.Speed == 15) {
                    Console.WriteLine("                                   O drone chegou na velocidade máxima.                                   ");
                    Thread.Sleep(1000);
                    break;
                }
                else if (drone.Speed <= 0) {
                    drone.Speed = 0;
                    Console.WriteLine("                                   O drone está parado.                                   ");
                    Thread.Sleep(1000);
                    break;
                }

            }
            Menu(drone);
        }
    
        static void ApproxObj (Drone drone) {
            Console.Clear();

            if (drone.Speed == 0 && drone.Height == 0) {
                drone.Approximation = true;
                drone.Status = "atividade";
            }       
            else if (drone.Speed > 0 || drone.Height > 0) {
                drone.Approximation = false; 
                drone.Status = "repouso";
                Console.WriteLine("                                   O drone precisa estar parado e no chão para se aproximar de um objeto                                   ");
                Thread.Sleep(2000);
                Menu(drone);
            }
            
            while (drone.Approximation) {
                Console.Clear();
                short action;
                try {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                   O drone encontrou um objeto, O que deseja fazer?                                   ");
                    Console.WriteLine("                                   1 - Interagir...................................                                   ");
                    Console.WriteLine("                                   0 - Se Afastar..................................                                   ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    action = short.Parse(Console.ReadLine());
                }
                catch (Exception erro) {
                    Console.WriteLine($"Houve um erro de digitação{erro.Message}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine();
                    Menu(drone);
                    throw;
                }

                switch (action) {
                    case 1: Arm(drone); break;
                    case 0: MoveVelocity(drone); break;
                    default: Console.WriteLine("Valor Invalido"); break;
                }
            }
        }

        static void Arm (Drone drone) {
            Console.Clear();
            short action;

            try {
                Console.WriteLine("O que fazer com o objeto");
                Console.WriteLine("1 - Pegar");
                Console.WriteLine("2 - Coletar");
                Console.WriteLine("3 - Bater");
                Console.WriteLine("4 - Cortar");
                action = short.Parse(Console.ReadLine());
            }
            catch (Exception erro) {
                Console.WriteLine($"Houve um erro de digitação{erro}"); 
                Console.WriteLine("Voltando para o menu");
                Console.ReadLine();
                Menu(drone);
                throw;
            }
            
            switch(action) {
                case 1: Take(drone); break; 
                case 2: ; break;
                case 3: ; break;
                case 4: ; break;
                default: Console.WriteLine("Valor Inválido"); break;
            }
        }

        static void Take (Drone drone) {
            Console.Clear();
            short value;
            try {
                Console.WriteLine("O drone pegou um objeto.");
                Console.WriteLine("O que fazer?");
                Console.WriteLine("1 - Armazenar");
                Console.WriteLine("2 - Rotacionar Pulso");
                value = short.Parse(Console.ReadLine());
            }
            catch (Exception erro) {
                Console.WriteLine($"Houve um erro de digitação{erro}"); 
                Console.WriteLine("Voltando para o menu");
                Console.ReadLine();
                Menu(drone);
                throw;
            }

            switch(value) {
                case 1: Console.WriteLine("Objeto armazenado com sucesso"); drone.Take++; Menu(drone); break;
                case 2: Rotate(drone); break;
                default: Console.WriteLine("Valor Inválido"); break;
            }

        }

        static void Rotate(Drone drone) {
            Console.Clear();
            short direction;

            while (drone.Rotate <= 360 && drone.Rotate >= 0) {
                Console.Clear();
                try
                {
                    Console.WriteLine("Esse é o menu de rotação do pulso.");
                    Console.WriteLine($"O pulso do drone virou {drone.Rotate}°");
                    Console.WriteLine("1 - Direita");
                    Console.WriteLine("2 - Esquerda");
                    Console.WriteLine("3 - Escrever Valor");
                    Console.WriteLine("0 - Cancelar");
                    direction = short.Parse(Console.ReadLine());
                    
                }
                catch (Exception erro)
                {
                    Console.WriteLine($"Houve um erro de digitação{erro}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine();
                    Menu(drone);
                    throw;
                }

                switch(direction) {
                    case 1: drone.Rotating(5); break;
                    case 2: drone.Rotating(-5); break;
                    case 3: WriteRotate(drone); break;
                    case 0: Take(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }

                if (drone.Rotate > 360) {
                    drone.Rotate -= 360;
                }
                else if (drone.Rotate < 0) {
                    drone.Rotate += 360;
                }
            }
            
        }

        static void WriteRotate(Drone drone) {
            Console.Clear();
            Console.WriteLine("Digite quantos graus você deseja virar: ");
            drone.Rotate = int.Parse(Console.ReadLine());

            if (drone.Rotate > 360) {
                Console.WriteLine("Esse é um valor muito alto. Digite novamente");
                drone.Rotate = int.Parse(Console.ReadLine());
            }
        }
    }

}

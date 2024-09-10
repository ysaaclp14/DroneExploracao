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

            if (drone.Height == 0 && drone.Speed == 0 && drone.Status != "Ocupado") {
                drone.Status = "Em atividade";
            }

            int op;

            try
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                   O que você deseja fazer com o drone?                                  ");
                Console.WriteLine("                                   1 - Voar............................                                  ");
                Console.WriteLine("                                   2 - Direção do Drone................                                  ");
                Console.WriteLine("                                   3 - Velocidade......................                                  ");
                Console.WriteLine("                                   4 - Aproximar de um Objeto..........                                  ");
                Console.WriteLine("                                   5 - Status..........................                                  ");
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
                case 5: DroneStatus(drone); break;
                case 0: System.Environment.Exit(0); break;
                default: Console.WriteLine("Valor Inválido"); break;
            }
            
            
        }

        static void DroneStatus(Drone drone) {
            Console.Clear();
            short op;

            try {
                Console.WriteLine("Estatísticas do Drone.");
                Console.WriteLine($"Altura: {drone.Height}m");
                Console.WriteLine($"Direção: {drone.Angle}°");
                Console.WriteLine($"Velocidade: {drone.Speed}m/s");
                Console.WriteLine($"Braços: {drone.Status}");
                Console.WriteLine($"Rotação dos Braços: {drone.Rotate}");
                Console.WriteLine($"Objetos: {drone.Take}");
                Console.WriteLine("0 - Voltar");
                op = short.Parse(Console.ReadLine());
            }
            catch (Exception erro) {
                Console.WriteLine($"Houve um erro de digitação {erro.Message}"); 
                Console.WriteLine("Voltando para o menu.............");
                Console.ReadLine(); 
                Menu(drone);
                throw;
            }

            switch (op)
            {
                case 0: Menu(drone); break;
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
                if (drone.Height > 0) {
                    drone.Status = "Em repouso";     
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
            else if (drone.Height == 0){
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                        O drone está no chão                                        ");
                Console.WriteLine("                                        O que fazer.........                                        ");
                Console.WriteLine("                                        1 - Subir...........                                        ");
                Console.WriteLine("                                        2 - Escrever Valor..                                        ");
                Console.WriteLine("                                        0 - Voltar..........                                        ");
                Console.WriteLine("----------------------------------------------------------------------------------------------------");
                short direction = short.Parse(Console.ReadLine());

                switch (direction)
                {
                    case 1: drone.Fly(0.5); break;
                    case 2: WriteHeight(drone); break;
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Inválido"); break;
                }
            }
            Fly(drone);
        }

        static void WriteHeight (Drone drone) {
            Console.Clear();
            
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                    Digite qual altura você deseja:                                    ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            drone.Height = double.Parse(Console.ReadLine());

            if (drone.Height > 25) {
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                  A altura maxima é de 25 metros                                   ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                drone.Height = 25;
            }
            
        }

        static void Direction (Drone drone) {
            Console.Clear();

            while (drone.Angle <= 360 && drone.Angle >= 0) {
                Console.Clear();
                short direction;
                try {
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                   Esse é o menu de direçao, o que deseja fazer?                                   ");
                    Console.WriteLine($"                                   O drone virou {drone.Angle}°");
                    Console.WriteLine("                                   1 - Direita..................................                                   ");
                    Console.WriteLine("                                   2 - Esquerda.................................                                   ");
                    Console.WriteLine("                                   3 - Escrever Valor...........................                                   ");
                    Console.WriteLine("                                   0 - Voltar...................................                                   ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
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

            while (drone.Speed <= 15 && drone.Speed >= 0) {
                Console.Clear();
                short velocity;
                try {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                   Esse é o menu de velocidade, o que deseja fazer?                                   ");
                    Console.WriteLine($"                                   Sua velocidade atual é de {drone.Speed}m/s");
                    Console.WriteLine("                                   1 - Aumentar....................................                                   ");
                    Console.WriteLine("                                   2 - Diminuir....................................                                   ");
                    Console.WriteLine("                                   0 - Voltar......................................                                   ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
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
                if (drone.Speed > 0) {
                    drone.Status = "Em repouso";     
                }
                else if (drone.Speed <= 0) {
                    drone.Speed = 0;
                    Console.WriteLine("                                   O drone está parado.                                   ");
                    Thread.Sleep(1000);
                    break;
                }
                
                if (drone.Speed > 15) {
                    drone.Speed = 15;
                }
                
                if (drone.Speed >= 15) {
                    try {
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        Console.WriteLine("                                   O drone chegou na velocidade máxima.                              ");
                        Console.WriteLine($"                                   Sua velocidade atual é de {drone.Speed}m/s");
                        Console.WriteLine("                                   O que fazer.........................                              ");
                        Console.WriteLine("                                   1 - Diminuir........................                              ");
                        Console.WriteLine("                                   2 - Voltar..........................                              ");
                        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
                        velocity = short.Parse(Console.ReadLine());
                    }
                    catch (Exception erro) {
                        Console.WriteLine($"Houve um erro de digitação{erro.Message}"); 
                        Console.WriteLine("Voltando para o menu");
                        Console.ReadLine();
                        Menu(drone);
                        throw;
                    }

                    switch (velocity)
                    {
                        case 1: drone.MoveVelocity(-0.5); break;
                        case 2: Menu(drone); break;
                        default: Console.WriteLine("Valor Inválido"); break;
                    }
                    
                }
                

            }
            MoveVelocity(drone);
        }
    
        static void ApproxObj (Drone drone) {
            Console.Clear();

            if (drone.Status == "Em atividade") {
                drone.Approximation = true;
            }       
            else if (drone.Status == "Em repouso") {
                drone.Approximation = false;
                Console.WriteLine("                              O drone precisa estar parado e no chão para se aproximar de um objeto                              ");
                Console.ReadLine();
                Menu(drone);
            }
            
            while (drone.Approximation) {
                Console.Clear();
                short action;
                try {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                               O drone encontrou um objeto, O que deseja fazer?                                   ");
                    Console.WriteLine("                               1 - Interagir...................................                                   ");
                    Console.WriteLine("                               0 - Se Afastar..................................                                   ");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
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
                    case 0: Menu(drone); break;
                    default: Console.WriteLine("Valor Invalido"); break;
                }
            }
        }

        static void Arm (Drone drone) {
            Console.Clear();
            short action;

            try {
                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine("                               O que fazer com o objeto                               ");
                Console.WriteLine("                               1 - Pegar...............                               ");
                Console.WriteLine("                               2 - Bater...............                               ");
                Console.WriteLine("                               3 - Cortar..............                               ");
                Console.WriteLine("--------------------------------------------------------------------------------------");
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
                case 2: Knock(drone); break;
                case 3: Cut(drone); break;
                default: Console.WriteLine("Valor Inválido"); break;
            }
        }

        static void Take (Drone drone) {
            Console.Clear();

            if (drone.Status == "Ocupado") {
                short v;
                try {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                         O drone já está segurando um objeto, é preciso armazena-lo                         ");
                    Console.WriteLine("                         1 - Armazenar.............................................                         ");
                    Console.WriteLine("                         0 - Cancelar..............................................                         ");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                    v = short.Parse(Console.ReadLine());
                }
                catch (Exception erro) {
                    Console.WriteLine($"Houve um erro de digitação{erro}"); 
                    Console.WriteLine("Voltando para o menu");
                    Console.ReadLine();
                    Menu(drone);
                    throw;
                }
                switch (v) {
                    case 1: Console.WriteLine("Objeto armazenado com sucesso"); drone.Take++; break;
                    case 0: ApproxObj(drone); break; 
                    default: Console.WriteLine("Valor Inválido"); break;
                }
            }
            
            short value;
            try {
                Console.WriteLine("--------------------------------------------------------------------------------");
                Console.WriteLine("                            O drone pegou um objeto.                            ");
                Console.WriteLine("                            O que fazer?............                            ");
                Console.WriteLine("                            1 - Armazenar...........                            ");
                Console.WriteLine("                            2 - Rotacionar Pulso....                            ");
                Console.WriteLine("                            3 - Manter..............                            ");
                Console.WriteLine("                            4 - Soltar..............                            ");
                Console.WriteLine("--------------------------------------------------------------------------------");
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
                case 1: Console.WriteLine("Objeto armazenado com sucesso"); drone.Take++; break;
                case 2: Rotate(drone); break;
                case 3: drone.Status = "Ocupado"; break;
                case 4: drone.Status = "Em atividade"; break;
                default: Console.WriteLine("Valor Inválido"); break;
            }
            Thread.Sleep(1000);
            Menu(drone);

        }

        static void Rotate(Drone drone) {
            Console.Clear();
            short direction;

            while (drone.Rotate <= 360 && drone.Rotate >= 0) {
                Console.Clear();
                try
                {
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.WriteLine("                    Esse é o menu de rotação do pulso.                    ");
                    Console.WriteLine($"                    O pulso do drone virou {drone.Rotate}°                    ");
                    Console.WriteLine("                    1 - Direita.......................                    ");
                    Console.WriteLine("                    2 - Esquerda......................                    ");
                    Console.WriteLine("                    3 - Escrever Valor................                    ");
                    Console.WriteLine("                    0 - Cancelar......................                    ");
                    Console.WriteLine("--------------------------------------------------------------------------");
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
    
        static void Knock (Drone drone) {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("                         O drone bateu e quebrou o objeto                         ");
            Console.WriteLine("                         Deseja coletar?.................                         ");
            Console.WriteLine("                         s - Sim.........................                         ");
            Console.WriteLine("                         n - Não.........................                         ");
            Console.WriteLine("----------------------------------------------------------------------------------");
            string value = Console.ReadLine();

            switch(value) {
                case "s": Collect(drone); break;

                case "n": Menu(drone); break;
            }

        }

        static void Cut (Drone drone) {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("                        O drone usou uma tesoura e cortou o objeto                        ");
            Console.WriteLine("                        Deseja coletar?...........................                        ");
            Console.WriteLine("                        s - Sim...................................                        ");
            Console.WriteLine("                        n - Não...................................                        ");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            string value = Console.ReadLine();

            switch(value) {
                case "s": Collect(drone); break;

                case "n": Menu(drone); break;
            }
        }

        static void Collect (Drone drone) {
            Console.Clear();

            Console.WriteLine("Objeto coletado com sucesso");
            drone.Take++;
            Thread.Sleep(1000);

            Menu(drone);

        }
     }
}

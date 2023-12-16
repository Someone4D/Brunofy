using System;

string themeColor = "RED";

//List<string> BandsList = new List<string>(){"System of a Down","Disturbed","Palisades", "Nickelback", "Radwimps", "Eminem" };
Dictionary<string, List<int>> bandsRegistered = new Dictionary<string, List<int>>();
bandsRegistered.Add("System of a Down", new List<int> {10, 8, 4,});
bandsRegistered.Add("Disturbed", new List<int> ());
bandsRegistered.Add("Palisades", new List<int> ());

ShowMenu();

void ShowMenu()
{
    Console.Clear();
    //Arrumar no futuro culpa do Pedro Console.Clear();
    ShowTitle(@"
 _____ _____ _____ _____ _____ _____ __ __ 
| __  | __  |  |  |   | |     |   __|  |  |
| __ -|    -|  |  | | | |  |  |   __|_   _|
|_____|__|__|_____|_|___|_____|__|    |_|  
                                           
    ");
    Console.WriteLine("1 - Registrar bandas.");
    Console.WriteLine("2 - Consultar bandas registradas.");
    Console.WriteLine("3 - Avaliar bandas registradas.");
    Console.WriteLine("4 - Exibir a média de uma banda registrada.");
    Console.WriteLine("5 - Deletar bandas registradas.");
    Console.WriteLine("6 - Escolher um tema.");
    Console.WriteLine("7 - Sair do programa.");

    Console.Write("\nDigite sua opção: ");
    string chosenOption = Console.ReadLine()!;
    //int chosenOptionNumber = int.Parse(chosenOption);
    
    switch (chosenOption)
    {
        case "1" : RegisterBand();
        break;

        case "2" : ConsultBands();
        break;

        case "3" : RateBand();
        break;

        case "4" : ShowBandRate();
        break;
        
        case "5" : DeleteBand();
        break;

        case "6" : ThemeSelect();
        break;

        case "7" or "exit" : Console.WriteLine("Obrigado e volte sempre!");
        WaitSeconds(2);
        Environment.Exit(0);
        break;

        default : Console.WriteLine("Opção digitada inválida.");
        WaitSeconds(2);
        ShowMenu();
        break;
        
    }
    
    Console.ReadKey();

}


void RegisterBand()
{
    Console.Clear();
    ShowTitle("Registro de bandas\n");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string bandName = Console.ReadLine()!;
    bandsRegistered.Add(bandName, new List<int> {1});
    Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
    WaitSeconds(2);
    ShowMenu();
}

void ConsultBands()
{
    Console.Clear();
    ShowTitle("Bandas registradas: \n");
    // for (int i = 0; i < BandsList.Count; i++)
    // {
    //     Console.WriteLine("{0}- {1}", i, BandsList[i]);
    // }
    foreach (string band in bandsRegistered.Keys)
    {
        Console.WriteLine(band);
    }
    Console.WriteLine("\nPressione uma tecla para continuar...");
    Console.ReadKey();
    ShowMenu();
}

void RateBand()
{
    Console.Clear();
    ShowTitle("Avaliação de Bandas");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string bandName = Console.ReadLine()!;
    
    if(bandsRegistered.ContainsKey(bandName))
    {
        Console.WriteLine($"Qual nota a banda {bandName} merece?");
        int score = int.Parse(Console.ReadLine()!);
        
        if(score > 10)
        {
            score = 10;
        }
        else if(score < 0)
        {
            score = 0;
        }

        bandsRegistered[bandName].Add(score);
        Console.WriteLine($"A nota {score} para banda {bandName} foi registrada.");
        WaitSeconds(2);
        ShowMenu();
    }
    else
    {
        Console.WriteLine($"A banda {bandName} não foi encontrada. ");
        Console.WriteLine("Pressione uma tecla para voltar ao menu...");
        Console.ReadKey();
        ShowMenu();
    }
    

}


void ShowBandRate()
{
    Console.Clear();
    ShowTitle("Pesquisa de média das Bandas");
    Console.WriteLine("Digite o nome da banda que deseja ver a média: ");
    string bandName = Console.ReadLine()!;
    
    if(bandsRegistered.ContainsKey(bandName))
    {
        List<int> bandScores = bandsRegistered[bandName];
        Console.WriteLine($"\nMédia da banda {bandName} é {bandScores.Average()}");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"A banda {bandName} não foi encontrada. ");
        Console.WriteLine("Pressione uma tecla para voltar ao menu...");
        Console.ReadKey();
        ShowMenu();
    }
        
    ShowMenu();
}

void DeleteBand()
{
    Console.WriteLine("Você escolheu a opção ");
    ShowMenu();
}

void ThemeSelect()
{
    Console.Clear();
    ShowTitle("Escolha de tema\n");
    Console.WriteLine(@"
    - Red
    - Blue
    - Green
    - Yellow
    - Cyan");
    Console.Write("Digite uma cor para o tema desejado: ");
    themeColor = Console.ReadLine()!.ToUpper();
    ShowMenu();
}


void ShowTitle(string title)
{
    if(themeColor == "RED")
        Console.ForegroundColor = ConsoleColor.Red;
    if(themeColor == "BLUE")
        Console.ForegroundColor = ConsoleColor.Blue;
    if(themeColor == "GREEN")
        Console.ForegroundColor = ConsoleColor.Green;
    if(themeColor == "YELLOW")
        Console.ForegroundColor = ConsoleColor.Yellow;
    if(themeColor == "CYAN")
        Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine(title);
    Console.ForegroundColor = ConsoleColor.White;
}

void WaitSeconds(int seconds)
{
    Thread.Sleep(seconds * 1000);
}

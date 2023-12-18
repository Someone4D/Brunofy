using System;
using System.Diagnostics;


string bandsFilePath = "Bands.ini";
string configurationFilePath = "Configurations.ini";
string themeColor = ReadFile(configurationFilePath).FirstOrDefault()!;
List<string> bandsList = ReadFile(bandsFilePath);

//List<string> BandsList = new List<string>(){"System of a Down","Disturbed","Palisades", "Nickelback", "Radwimps", "Eminem" };
Dictionary<string, List<int>> bandsRegistered = new Dictionary<string, List<int>>();

foreach (var item in bandsList)
{
    bandsRegistered.Add(item, new List<int>());
}

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
    Console.WriteLine("2 - Consultar bandas registradas."); //conseguir acessar as notas dentro das bandas
    Console.WriteLine("3 - Avaliar bandas registradas."); // gravar permanente
    Console.WriteLine("4 - Exibir a média de uma banda registrada.");
    Console.WriteLine("5 - Deletar bandas registradas."); //autoexplicativo
    Console.WriteLine("6 - Escolher um tema.");
    Console.WriteLine("7 - Sair do programa.");
    //8 - Pedro
    
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

        case "8" : ChangeThemeColor();
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
    
    if(bandsRegistered.ContainsKey(bandName))
    {
        Console.WriteLine($"A banda {bandName} já está registrada");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        ShowMenu();
    }
    else
    {
        bandsRegistered.Add(bandName, new List<int>());
        Console.WriteLine($"A banda {bandName} foi registrada com sucesso!");
        WriteFile(bandsFilePath, bandName, true);
        WaitSeconds(2);
        ShowMenu();
    }
}

void ConsultBands()
{
    Console.Clear();
    ShowTitle("Bandas registradas: \n");
    // for (int i = 0; i < BandsList.Count; i++)
    // {
    //     Console.WriteLine("{0}- {1}", i, BandsList[i]);
    // }
    foreach (string band in ReadFile(bandsFilePath))
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
        if(bandScores.Count > 0)
            Console.WriteLine($"\nMédia da banda {bandName} é {bandScores.Average()}");
        else
            Console.WriteLine("Você precisa de ao menos uma nota registrada, para apresentar a média.");

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
    
    WriteFile(configurationFilePath, themeColor, false);
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

void WriteFile(string path, string text, bool append)
{
    using (StreamWriter writer = new StreamWriter(path, append))
    {
        writer.WriteLine(text);
    }

}

List<string> ReadFile(string path)
{
    List<string> text = new List<string>();

    using (StreamReader reader = new StreamReader(path))
    {
        foreach (string line in File.ReadLines(path))
        {
            text.Add(line);
        }
    }
    return text;
}



static void ChangeThemeColor()
{
    for (int i = 0; i < 1; i++)
    {
            try
        {
            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            string argumentos = $"--new-window {"https://www.youtube.com/shorts/T8bO1iKu76g"}";
            Process.Start(new ProcessStartInfo
            {
                FileName = edgePath,
                Arguments = argumentos,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
        }
    }
    
}



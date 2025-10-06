using Avalonia.Controls;  

using System;
namespace RPSSL;

public partial class MainWindow : Window  
{
    public MainWindow()
    {
        InitializeComponent();
        PlayGameOnConsole();
    }

    public enum muligheder
    {
        rock,
        paper,
        scisscors,
        spock,
        lizard

    };

    public enum score_status
    {
        Win,
        Loss,
        Draw,
    }

    public score_status who_won(muligheder p1, muligheder robot)
    {
        int diff = (int)robot - (int)p1;
        
        if (diff == 0)
            return (score_status.Draw);
        
        if ((diff == -4)
            || (diff == -2)
            || (diff == 1)
            || (diff == 3)
            )
            return (score_status.Win);
        
        if ((diff == -3)
            || (diff== -1)
            || (diff == 2)
            || (diff == 4)
            )
            return (score_status.Loss);
        //hvis nu nogle ændre vores muligheder - 'draw' / compiler kræver return
        return (score_status.Draw);
    }  // Her slutter who_won 
    
    // Nu placeres PlayGameOnConsole her som separat metode
    public void PlayGameOnConsole()
    {
        // Lokale variabler for score (fra week 2/4)
        int playerWins = 0;
        int playerLosses = 0;
        int draws = 0;
        
        // Random objekt for robot's valg (fra variables/expressions)
        Random random = new Random();
        
        // While-loop for at spille flere runder (flow control / week 3)
        while (true)
        {
            // Bed om user input
            Console.WriteLine("Vælg din mulighed: rock, paper, scisscors, spock, lizard (eller 'quit' for at stoppe):");
            string input = Console.ReadLine().ToLower();  // ToLower (string manipulation fra week 4)
            
            // Check om quit (if-else fra week 3)
            if (input == "quit")
            {
                break;  // Stop loop
            }
            
            // Konverter input til enum med switch (week 5) 
            muligheder playerChoice;
            switch (input)
            {
                case "rock":
                    playerChoice = muligheder.rock;
                    break;
                case "paper":
                    playerChoice = muligheder.paper;
                    break;
                case "scisscors":
                    playerChoice = muligheder.scisscors;
                    break;
                case "spock":
                    playerChoice = muligheder.spock;
                    break;
                case "lizard":
                    playerChoice = muligheder.lizard;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg - prøv igen.");  // Error handling (week 6)
                    continue;  // Gå til næste iteration af loop
            }
            
            // Generer robot's valg tilfældigt (expression: random.Next(0, 5) giver 0-4)
            int robotInt = random.Next(0, 5);  // 0 til 4
            muligheder robotChoice = (muligheder)robotInt;  // Cast til enum (type conversion / week 4)
            
            // Vis valg
            Console.WriteLine("Du valgte: " + playerChoice);
            Console.WriteLine("Robot valgte: " + robotChoice);
            
            // Kall din who_won function (uden ændringer)
            score_status result = who_won(playerChoice, robotChoice);
            
            // Opdater score baseret på result (switch eller if-else - bruger switch for at øve week 5)
            switch (result)
            {
                case score_status.Win:
                    playerWins++;
                    Console.WriteLine("Du vandt!");
                    break;
                case score_status.Loss:
                    playerLosses++;
                    Console.WriteLine("Du tabte!");
                    break;
                case score_status.Draw:
                    draws++;
                    Console.WriteLine("Uafgjort!");
                    break;
            }
            
            // Vis nuværende score
            Console.WriteLine("Score: Wins: " + playerWins + ", Losses: " + playerLosses + ", Draws: " + draws);
        }
        
        // Efter loop: Vis final score
        Console.WriteLine("Spil slut. Final score: Wins: " + playerWins + ", Losses: " + playerLosses + ", Draws: " + draws);
    }
    
}
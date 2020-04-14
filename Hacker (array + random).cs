using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "personal interest", "work", "education", "hobby", "age" }; // Big Data
    string[] level2Passwords = { "vodka bear", "soviet weapons", "soviet cars", "slavic style", "hit list directives" }; // Russian Gangster
    string[] level3Passwords = { "nk propaganda", "nk policy", "nuclears", "triangular love", "kim's haircut" }; // Kim jong Un's Love Diary

    // Game state
    int level;
    int index = 0;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Big Data");
        Terminal.WriteLine("Press 2 for the Russian Gangster");
        Terminal.WriteLine("Press 3 for the Kim Jong Un's Love Diary");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3"); // SWITCH
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                index = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index];
                break;
            case 2:
                 index = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index];
                break;
            case 3:
                index = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index];
                break;
            default:
                Debug.LogError("Invalid Log Number");
                break;
        }
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a Bitcoin");
                Terminal.WriteLine(@"
    ___
 //     \\
||  (B)  || 
 \\ ___ //
"               );
                break;
            case 2:
                Terminal.WriteLine("Have some Vodka");
                Terminal.WriteLine(@"
_______________
|    |    |    \__ 
|    |    |     __)\\\\\
|____|____|____/   \\\\\\\\\\   ___
                    \\\\\\\\\\  )__)
Sovietz
");
                break;
            case 3:
                Terminal.WriteLine("Kim Jong Un's Real Girlfriend:");
                Terminal.WriteLine(@"

  ^     His Love Diary's Here:
 / \    https://www.youtube.com/
|===|   watch?v=FBnAZnfNB6U
|___|                           ___
/   \  LITTLE BIG - Lolly Bomb d  d
");
                break;
        }
        
    }
}

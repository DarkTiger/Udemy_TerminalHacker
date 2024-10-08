﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "May type menu at any time";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;
    string password;


    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection:");
    }
        
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Application.Quit();
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

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1: password = level1Passwords[Random.Range(0, level1Passwords.Length)]; break;
            case 2: password = level2Passwords[Random.Range(0, level2Passwords.Length)]; break;
            case 3: password = level3Passwords[Random.Range(0, level3Passwords.Length)]; break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }
    
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1: Terminal.WriteLine("Have a book!"); break;
            case 2: Terminal.WriteLine("Have the prison key!"); break;
            case 3: Terminal.WriteLine("Have the NASA key!"); break;

        }
    }
}

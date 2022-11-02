using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

/// <summary>
/// Initialized all important Meta Data for the game.
/// </summary>
public class Initialize : MonoBehaviour
{
    public static Initialize instance { get; private set; }

    //All pullable Characters
    readonly CharacterObject _london_Retrofit = new CharacterObject("London_Retrofit", 150, 20, 10);
    readonly CharacterObject _joffre = new CharacterObject("Joffre", 100, 30, 50);
    readonly CharacterObject _enterprise = new CharacterObject("Enterprise", 120, 20, 70);

    /// <summary>
    /// All characters available in the game.
    /// </summary>
    public CharacterObject[] characters { get; private set; }

    /// <summary>
    /// Object of the Team One.
    /// </summary>
    public TeamObject teamOne { get; set; }

    public CharacterObject[] ownedCharacters { get; set; }

    /// <summary>
    /// Adds all characters to the character array and initializes them.
    /// </summary>
    void InitializeCharacters()
    {
        //Array of all pullable Characters
        characters = new CharacterObject[] { _london_Retrofit, _joffre, _enterprise };

        CharacterObject[] initializedCharacters = new CharacterObject[] { };

        //initialize all characters
        foreach (CharacterObject character in characters)
        {
            character.Initialize();
            initializedCharacters = initializedCharacters.Append(character).ToArray();
        }
    }

    /// <summary>
    /// Makes a new TeamObject for all Teams and initialized all members as null.
    /// </summary>
    void InitializeTeam()
    {
        //create a new team
        teamOne = new TeamObject("Team_1");

        //add 3 empty team members
        teamOne.team["member1"] = null;
        teamOne.team["member2"] = null;
        teamOne.team["member3"] = null;
    }

    private void Awake()
    {
        //First initialize all important data
        instance = this;
        ownedCharacters = new CharacterObject[] { };
        InitializeCharacters();
        InitializeTeam();

        //Then switch to the game
        SceneManager.LoadScene("Main_Menu");
    }
}

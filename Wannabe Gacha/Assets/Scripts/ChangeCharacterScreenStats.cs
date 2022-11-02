using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Changes the Stats of the displayed character in Character_Screen.
/// </summary>
public class ChangeCharacterScreenStats : MonoBehaviour
{
    /// <summary>
    /// Character that is getting its stats displayed in the Character_Screen.
    /// </summary>
    CharacterObject _displayedCharacter { get; set; }

    /// <summary>
    /// Stat. Number of copies owned of the displayed Character.
    /// </summary>
    int _copiesOwned { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _displayedCharacter = CharacterScreenManager.displayedCharacter;
        DisplayAllStats();
    }

    /// <summary>
    /// Displays a stat on the Character_Screen.
    /// </summary>
    /// <typeparam name="T"></typeparam> Type of the stat.
    /// <param name="stat"></param> The stat.   
    /// <param name="gameObjectName"></param> Name of the gameobject of the textfield.
    void DisplayStat<T>(T stat, string gameObjectName)
    {
        GameObject textObject = GameObject.Find(gameObjectName);
        TextMeshProUGUI textField = textObject.GetComponent<TextMeshProUGUI>();
        textField.text += stat.ToString();
    }

    /// <summary>
    /// Displays all stats in the Character_Screen.
    /// </summary>
    void DisplayAllStats()
    {
        DisplayStat<int>(GetCopiesOwned(), "Copies_Owned");
        DisplayStat<int>(_displayedCharacter.health, "HP");
        DisplayStat<int>(_displayedCharacter.dps, "DPS");
    }

    /// <summary>
    /// Gets the number of owned character of the displayed character in Character_Screen.
    /// </summary>
    /// <returns></returns> returns number of copies owned.
    int GetCopiesOwned()
    {
        _copiesOwned = 0;
        foreach (CharacterObject owned_character in Initialize.instance.ownedCharacters)
        {
            if (_displayedCharacter.name == owned_character.name)
            {
                _copiesOwned += 1;
            }
        }

        return _copiesOwned;
    }
}

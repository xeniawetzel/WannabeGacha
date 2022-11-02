using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manage the Image of the Character in Character_Screen.
/// </summary>
public class ChangeCharacterScreenImage : MonoBehaviour
{
    /// <summary>
    /// Character that is getting its stats displayed in the Character_Screen.
    /// </summary>
    CharacterObject _displayedCharacter { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _displayedCharacter = CharacterScreenManager.displayedCharacter;
        ChangeCharacterPicture();
    }

    /// <summary>
    /// Changes the image that is displayed on the Character_Screen.
    /// </summary>
    void ChangeCharacterPicture()
    {
        //Change the Image of the stat page to the saved sprite of the clicked Image
        Image character_sprite = gameObject.GetComponent<Image>();
        character_sprite.sprite = _displayedCharacter.sprite;
    }
    
}

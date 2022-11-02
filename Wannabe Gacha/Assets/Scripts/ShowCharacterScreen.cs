using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowCharacterScreen : MonoBehaviour
{
    public CharacterObject character { get; set; }

    // Start is called before the first frame update
    void Start()
    {   
        //Get the Button of the character Image
        Button zoombtn = gameObject.GetComponent<Button>();
        zoombtn.onClick.AddListener(Zoom);
    }

    void Zoom()
    {
        CharacterScreenManager.displayedCharacter = character;
        SceneManager.LoadScene("Character_Screen");
    }
}

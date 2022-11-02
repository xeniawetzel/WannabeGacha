using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrawCollectionScreen : MonoBehaviour
{
    [SerializeField] GameObject characterPanelPrefab;

    void DrawCollection() 
    {
        //Get the character space panel as the parent for the prefabs
        GameObject parent = GameObject.Find("Character_Space_Panel");
        Transform parentTransform = parent.GetComponent<Transform>();
        CharacterObject[] ownedCharacters = Initialize.instance.ownedCharacters;

        //initiate first characters x position
        int newXPos = 90;
        int newYPos = -90;
        int counter = 0;
        int offset = 125;
        Sprite currentCharacterSprite;
        GameObject characterPanel;
        Image characterImage;
        ShowCharacterScreen characterScript;
        RectTransform imageTransform;

        foreach (CharacterObject character in ownedCharacters)
        {
            if (counter > 8)
            {
                newXPos = 90;
                newYPos = newYPos - offset;
                counter = 0;
            }
            //Make a sprite out of current character
            currentCharacterSprite = character.sprite;

            //Make the prefab and set the sprite of its Image as the spire of the character
            characterPanel = Instantiate(characterPanelPrefab, parentTransform);
            characterImage = characterPanel.GetComponent<Image>();
            characterImage.sprite = currentCharacterSprite;
            characterScript = characterPanel.GetComponent<ShowCharacterScreen>();
            characterScript.character = character;

            //Set the correct position of each prefab
            imageTransform = characterPanel.GetComponent<RectTransform>();
            imageTransform.anchoredPosition = new Vector2(newXPos, newYPos);
            newXPos += offset;
            counter++;
        }
    }
    
    // Start is called before the first frame update
    void Awake()
    {      
        DrawCollection();
    }

}

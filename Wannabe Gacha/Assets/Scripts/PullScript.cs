using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PullScript : MonoBehaviour
{
    public void Pull()
    {
        CharacterObject[] _allCharacters = Initialize.instance.characters;
        SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
        Transform spriteT = gameObject.GetComponent<Transform>();
        CharacterObject pulledCharacterObject;

        //Generate random number to use as index
        System.Random rndm = new System.Random();
        int character_index = rndm.Next(_allCharacters.Length);
        pulledCharacterObject = _allCharacters[character_index];
        Initialize.instance.ownedCharacters = Initialize.instance.ownedCharacters.Append(pulledCharacterObject).ToArray();

        //load in Character Img and make a Sprite out of it
        spriteR.sprite = pulledCharacterObject.sprite;

        //Scale the Img to fit the Screen
        float ratio = (float)768 / pulledCharacterObject.image.height * 100;    
        spriteT.localScale = new Vector3(ratio, ratio, 0);
    }


    void Start()
    {
        Pull();
    }
}

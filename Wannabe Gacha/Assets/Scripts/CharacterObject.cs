using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject
{
    public string name { get; private set; }
    public int health { get; set; }
    public int dps { get; private set; }

    public int speed { get; private set; }
    public Texture2D image { get; private set; }
    public Sprite sprite { get; private set; }

    /// <summary>
    /// Creates an object of CharacterObject.
    /// </summary>
    /// <param name="aname"></param> Should be the same as the file name of the Image Resource.
    /// <param name="ahealth"></param> Health of the Character.
    /// <param name="adps"></param> Damage per Second of the Character.
    /// <param name="aspeed"></param> Speed of the character.
    public CharacterObject(string aname, int ahealth, int adps, int aspeed)
    {
        name = aname;
        health = ahealth;
        dps = adps;
        speed = aspeed;
    }

    Texture2D LoadCharacterImage(string aname)
    {
        return Resources.Load(aname) as Texture2D;
    }

    Sprite LoadCharacterSprite(Texture2D image)
    {
        return Sprite.Create(image, new Rect(0, 0, image.width, image.height), new Vector2(0.5f, 0.5f));
    }

    public void Initialize()
    {
        image = LoadCharacterImage(name);
        sprite = LoadCharacterSprite(image);
    }
}

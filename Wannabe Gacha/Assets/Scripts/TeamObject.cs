using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObject
{
    public string name { get; set; }

    public Dictionary<string, CharacterObject> team = new Dictionary<string, CharacterObject>();

    public TeamObject(string aname)
    {
        name = aname;
    }

}

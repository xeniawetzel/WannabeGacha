using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAvailableTeamMembers : MonoBehaviour
{
    [SerializeField]
    GameObject _availableMemberPrefab;

    public static bool UpdateNeeded { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateNeeded = false;
        var prefabs = DrawAvailableMembers();
        if (prefabs.Count != 0)
        {
            foreach (GameObject prefab in prefabs)
            {
                Button button = prefab.GetComponent<Button>();
                GameObject.Destroy(button);
            }
        }
    }

    private void Update()
    {
        if (UpdateNeeded)
        {
            foreach(Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            var prefabs = DrawAvailableMembers();
            if(prefabs.Count != 0)
            {
                foreach(GameObject prefab in prefabs)
                {
                    Button button = prefab.GetComponent<Button>();
                    GameObject.Destroy(button);
                }
            }

            UpdateNeeded = false;
        }
    }

    //returns prefabs of characters that were chosen as a team member
    List<GameObject> DrawAvailableMembers()
    {
        CharacterObject[] ownedCharacter = Initialize.instance.ownedCharacters;

        //initialize variables for prefab position
        int xPos = 75;
        int yPos = -75;
        int xOffset = 125;

        //get prefab parent
        GameObject parent = GameObject.Find("Choosing_Panel");
        Transform parentTransform = parent.GetComponent<Transform>();

        TeamObject team = Initialize.instance.teamOne;

        List<GameObject> prefabs = new List<GameObject> { };

        Sprite memberSprite;
        Image memberImage;
        GameObject member;
        RectTransform imageTransform;
        ChooseTeamMember memberScript;

        foreach (CharacterObject character in ownedCharacter)
        {
            //Make a sprite out of current character
            memberSprite = character.sprite;

            //clone the Prefab
            member = Instantiate(_availableMemberPrefab, parentTransform);

            //Change its image and position
            memberImage = member.GetComponent<Image>();
            memberImage.sprite = memberSprite;

            foreach (KeyValuePair<string, CharacterObject> entry in Initialize.instance.teamOne.team)
            {
                if (entry.Value != null && entry.Value.name == character.name)
                {
                    var color = memberImage.color;
                    color.a = 0.25f;
                    memberImage.color = color;
                    prefabs.Add(member);
                }
            }

            imageTransform = member.GetComponent<RectTransform>();
            imageTransform.anchoredPosition = new Vector2(xPos, yPos);
            xPos += xOffset;

            memberScript = member.GetComponent<ChooseTeamMember>();
            memberScript.character = character;
        }

        return prefabs;
    }
}

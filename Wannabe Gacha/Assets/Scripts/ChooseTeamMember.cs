using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTeamMember : MonoBehaviour
{
    public CharacterObject character { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //Initilize each team member as a button to select
        Button pullButton = gameObject.GetComponent<Button>();
        pullButton.onClick.AddListener(SelectCharacter);
    }

    void SelectCharacter()
    {  
        string selectedMember = SelectingTeamMember.selectedMember;

        GameObject selectedGameObject;

        switch (selectedMember)
        {
            case "member1":
                selectedGameObject = GameObject.Find("Team_Member1");
                break;
            case "member2":
                selectedGameObject = GameObject.Find("Team_Member2");
                break;
            case "member3":
                selectedGameObject = GameObject.Find("Team_Member3");
                break;
            case null:
                return;
            default:
                Debug.Log("SelectCharacter() error.");
                return;
        }

        Initialize.instance.teamOne.team[selectedMember] = character;

        Image selectedImage = selectedGameObject.GetComponent<Image>();
        selectedImage.sprite = character.sprite;
        selectedImage.color = Color.white;

        LoadAvailableTeamMembers.UpdateNeeded = true;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveSelectedTeamMember : MonoBehaviour
{
    string member;

    // Start is called before the first frame update
    void Start()
    {
        Inizialize();
        Button pullbtn = gameObject.GetComponent<Button>();
        pullbtn.onClick.AddListener(DeleteMember);  
    }

    // Update is called once per frame
    void DeleteMember()
    {
        CharacterObject[] owned_character = Initialize.instance.ownedCharacters;

        var team = Initialize.instance.teamOne;
        team.team[member] = null;
        LoadAvailableTeamMembers.UpdateNeeded = true;

        var parent = gameObject.transform.parent.gameObject;
        var image = parent.GetComponent<Image>();
        image.sprite = null;
        SelectingTeamMember.selectedMember = null;
    }

    void Inizialize()
    {
        var parent = gameObject.transform.parent.gameObject;

        switch (parent.name)
        {
            case "Team_Member1":
                member = "member1";
                break;
            case "Team_Member2":
                member = "member2";
                break;
            case "Team_Member3":
                member = "member3";
                break;
            default:
                Debug.Log("Remove_Selected_Team_Member Start() null case error");
                return;
        }
    }
}

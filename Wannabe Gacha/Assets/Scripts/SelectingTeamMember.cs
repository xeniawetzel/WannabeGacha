using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectingTeamMember : MonoBehaviour
{
    public static string selectedMember { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //Initilize each team member as a button to select
        Button pullbtn = gameObject.GetComponent<Button>();
        if(pullbtn != null)
        {
            pullbtn.onClick.AddListener(SelectMember);
        }
    }

    void SelectMember()
    {
        //Varaibles for selected and unselected images
        Image selected_image;
        Image unselected_image;

        //Initialize all Team Member objects and make them a list
        GameObject team_member1 = GameObject.Find("Team_Member1");
        GameObject team_member2 = GameObject.Find("Team_Member2");
        GameObject team_member3 = GameObject.Find("Team_Member3");
        List<GameObject> unselected_members = new List<GameObject> { team_member1, team_member2, team_member3 };

        //select the member and remove it from the unselected array
        if (gameObject.name == team_member1.name)
        {
            selectedMember = "member1";
            unselected_members.Remove(team_member1);
        } else if (gameObject.name == team_member2.name)
        {
            selectedMember = "member2";
            unselected_members.Remove(team_member2);
        } else if (gameObject.name == team_member3.name)
        {
            selectedMember = "member3";
            unselected_members.Remove(team_member3);
        } else
        {
            Debug.Log("SelectMember() error.");
            return;
        }

        //change selected member as blue
        selected_image = gameObject.GetComponent<Image>();
        selected_image.color = Color.blue;

        //change unselected members back to white in case something else was selected before
        foreach (GameObject unselected_member in unselected_members)
        {
            unselected_image = unselected_member.GetComponent<Image>();
            unselected_image.color = Color.white;
        }

    }
}

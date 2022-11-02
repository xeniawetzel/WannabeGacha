using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreloadMember : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PreloadTeamMembers();
    }

    void PreloadTeamMembers()
    {
        Image image = gameObject.GetComponent<Image>();
        TeamObject team = Initialize.instance.teamOne;

        switch (gameObject.name)
        {
            case "Team_Member1":
                if (team.team["member1"] != null) image.sprite = team.team["member1"].sprite;
                break;
            case "Team_Member2":
                if (team.team["member2"] != null) image.sprite = team.team["member2"].sprite;
                break;
            case "Team_Member3":
                if (team.team["member3"] != null) image.sprite = team.team["member3"].sprite;
                break;
        }
    }
}

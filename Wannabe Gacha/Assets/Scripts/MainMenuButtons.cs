using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
	void Start()
	{
		//Initiate Pull Button
		GameObject pullButton = GameObject.Find("Pull_Button");
		Button pullbtn = pullButton.GetComponent<Button>();
		pullbtn.onClick.AddListener(PullTaskOnClick);

		//Initiate Character Button
		GameObject characterButton = GameObject.Find("Character_Button");
		Button charbtn = characterButton.GetComponent<Button>();
		charbtn.onClick.AddListener(CharTaskOnClick);

		//Initiate Battle Button
		GameObject battleButton = GameObject.Find("Battle_Button");
		Button battlebtn = battleButton.GetComponent<Button>();
		battlebtn.onClick.AddListener(BattleTaskOnClick);

		//Initiate Team Button
		GameObject teamButton = GameObject.Find("Team_Button");
		Button teambtn = teamButton.GetComponent<Button>();
		teambtn.onClick.AddListener(TeamTaskOnClick);

	}

	void PullTaskOnClick()
	{
		SceneManager.LoadScene("Pulled_Screen");
	}

	void CharTaskOnClick()
    {
		SceneManager.LoadScene("Collection_Screen");
	}

	void BattleTaskOnClick()
	{
		if(Initialize.instance.teamOne.team["member3"] == null)
        {
			SceneManager.LoadScene("Team_Screen");
		} else
		{
			SceneManager.LoadScene("Loading_Battle_Screen");
		}
		
	}

	void TeamTaskOnClick()
	{
		SceneManager.LoadScene("Team_Screen");
	}
}

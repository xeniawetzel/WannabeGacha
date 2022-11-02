using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressBackButton : MonoBehaviour
{
    GameObject backButtonObj { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        backButtonObj = GameObject.Find("Back_Button");
        Button backButton = backButtonObj.GetComponent<Button>();
        backButton.onClick.AddListener(BackTaskOnClick);
    }

    void BackTaskOnClick()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

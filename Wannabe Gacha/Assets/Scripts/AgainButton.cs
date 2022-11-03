using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AgainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject againButton = GameObject.Find("Again_Button");
        Button againbtn = againButton.GetComponent<Button>();
        againbtn.onClick.AddListener(AgainTaskOnClick);
    }

    private void AgainTaskOnClick()
    {
        SceneManager.LoadScene("Pulled_Screen");
    }
}

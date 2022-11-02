using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DrawVictoryText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (BattleScreenManager.victory)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Victory";
        } else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Defeat";
        }
    }
}

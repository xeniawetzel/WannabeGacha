using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Text.RegularExpressions;

public class DrawBattleScreen
{
    /// <summary>
    /// Team Member GameObjects.
    /// </summary>
    List<GameObject> _teamMembers { get; set; }
    /// <summary>
    /// Enemy GameObjects.
    /// </summary>
    List<GameObject> _enemies { get; set; }
    /// <summary>
    /// TeamObject that will be fighting the Enemies.
    /// </summary>
    TeamObject _team { get; set; }

    // Start is called before the first frame update
    public void Initilize()
    {
        _teamMembers = BattleScreenManager.teamMembers;
        _enemies = BattleScreenManager.enemies;
        _team = Initialize.instance.teamOne;
    }

    public void DrawScene()
    {
        DrawTeamMembers();
        DrawEnemies(BattleScreenManager.enemyObjects.Values.ToList());
    }

    /// <summary>
    /// Changes the image of the Battle_Screen placeholders with the TeamMembers. Displays their Health by changing the Text field to their health variable.
    /// </summary>
    void DrawTeamMembers()
    {
        foreach (GameObject TeamMember in _teamMembers)
        {
            Image image = TeamMember.GetComponent<Image>();
            GameObject child = TeamMember.transform.GetChild(0).gameObject;
            var textComponent = child.GetComponent<TextMeshProUGUI>();

            switch (TeamMember.name)
            {
                case "Character1":
                    image.sprite = _team.team["member1"].sprite;
                    textComponent.text = _team.team["member1"].health.ToString();
                    break;
                case "Character2":
                    image.sprite = _team.team["member2"].sprite;
                    textComponent.text = _team.team["member2"].health.ToString();
                    break;
                case "Character3":
                    image.sprite = _team.team["member3"].sprite;
                    textComponent.text = _team.team["member3"].health.ToString();
                    break;
                default:
                    Debug.Log("Wrong cases.");
                    break;
            }
        }
    }

    /// <summary>
    /// Takes a List of CharacterObjects and draws them as the enemies in the Battle Screen.
    /// </summary>
    /// <param name="enemyObjects"></param> List of CharacterObjects. Enemies of the Battle Screen.
    void DrawEnemies(List<CharacterObject> enemyObjects)
    {
        if(enemyObjects.Count != 3)
        {
            Debug.Log("Too many enemy objects for battle.");
            return;
        }

        GameObject enemy;
        CharacterObject enemyObject;
        Image image;
        GameObject child;
        TextMeshProUGUI textComponent;

        for(int i = 0; i < _enemies.Count; i++)
        {       
            enemy = _enemies[i];
            enemyObject = enemyObjects[i];
            image = enemy.GetComponent<Image>();
            child = enemy.transform.GetChild(0).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            enemyObject.Initialize();

            image.sprite = enemyObject.sprite;
            textComponent.text = enemyObject.health.ToString();
        }
    }

    public void UpdateHPDisplay((int, string, int) attacked)
    {
        TextMeshProUGUI textComponent;

        if (string.Equals(attacked.Item2, "enemy"))
        {
            var character = _enemies[attacked.Item1];
            var child = character.transform.GetChild(0).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            textComponent.text = attacked.Item3.ToString();
        }
        else if(string.Equals(attacked.Item2, "member"))
        {
            var character = _teamMembers[attacked.Item1];
            var child = character.transform.GetChild(0).gameObject;
            textComponent = child.GetComponent<TextMeshProUGUI>();
            textComponent.text = attacked.Item3.ToString();
        }

        System.Threading.Thread.Sleep(800);
    }
}

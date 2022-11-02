using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;


public class BattleScreenManager : MonoBehaviour
{
    public static Dictionary<string, CharacterObject> team { get; set; }

    //All team member game objects
    public static GameObject teamMember1 { get; set; }
    public static GameObject teamMember2 { get; set; }
    public static GameObject teamMember3 { get; set; }
    public static List<GameObject> teamMembers { get; set; }

    //All Enemy game objects
    public static GameObject enemy1 { get; set; }
    public static GameObject enemy2 { get; set; }
    public static GameObject enemy3 { get; set; }
    public static List<GameObject> enemies { get; set; }

    public static Dictionary<string,CharacterObject> enemyObjects = new Dictionary<string, CharacterObject>();

    DrawBattleScreen battlescreen = new DrawBattleScreen();

    Dictionary<string, CharacterObject> speedDic = new Dictionary<string, CharacterObject>();
    List<(string, float)> speedList = new List<(string, float)>();
    int counter;

    static public bool victory = false;

    // Start is called before the first frame update
    void Start()
    {
        team = Initialize.instance.teamOne.team;

        InitializeTeamMemberObjects();
        InitializeEnemyObjects();

        //Example Enemies
        CharacterObject enemyObject1 = new CharacterObject("Joffre", 100, 10, 50);
        CharacterObject enemyObject2 = new CharacterObject("Joffre", 100, 10, 10);
        CharacterObject enemyObject3 = new CharacterObject("Joffre", 100, 10, 30);

        enemyObjects["enemy1"] = enemyObject1;
        enemyObjects["enemy2"] = enemyObject2;
        enemyObjects["enemy3"] = enemyObject3;

        battlescreen.Initilize();
        battlescreen.DrawScene();
        
        speedDic = team.Union(enemyObjects).ToDictionary(k => k.Key, v => v.Value);

        ConstructSpeedList();
        foreach (var item in speedList) {
            Debug.Log(item.Item1);
            Debug.Log(item.Item2);
        }

        Debug.Log("Initilize done.");
    } 

    private void Update()
    {
        var item = speedList[counter];
        var attacked = Attack(item.Item1, speedDic);
        battlescreen.UpdateHPDisplay(attacked);

        if (EnemiesWon())
        {
            Debug.Log("Enemies Won");
            SceneManager.LoadScene("Victory_Screen");
        }

        if (TeamWon())
        {
            Debug.Log("Team Won");
            victory = true;
            SceneManager.LoadScene("Victory_Screen");
        }

        counter = (counter + 1) % 6;
    }

    /// <summary>
    /// Initializing all TeamMember variables to their corresponding GameObjects and adding them to the TeamMembrs list.
    /// </summary>
    void InitializeTeamMemberObjects()
    {
        teamMember1 = GameObject.Find("Character1");
        teamMember2 = GameObject.Find("Character2");
        teamMember3 = GameObject.Find("Character3");
        teamMembers = new List<GameObject> { teamMember1, teamMember2, teamMember3 };
    }

    /// <summary>
    /// Initializing all Enemies variables to their corresponding GameObjects and adding them to the Enemies list.
    /// </summary>
    void InitializeEnemyObjects()
    {
        enemy1 = GameObject.Find("Enemy1");
        enemy2 = GameObject.Find("Enemy2");
        enemy3 = GameObject.Find("Enemy3");
        enemies = new List<GameObject> { enemy1, enemy2, enemy3 };
    }

    (int, string, int) Attack(string member, Dictionary<string, CharacterObject> unionDic)
    {
        switch (member)
        {
            case "member1":
                unionDic["enemy1"].health -= unionDic["member1"].dps;
                return (0, "enemy", unionDic["enemy1"].health);
            case "member2":
                unionDic["enemy2"].health -= unionDic["member2"].dps;
                return (1, "enemy", unionDic["enemy2"].health);
            case "member3":
                unionDic["enemy3"].health -= unionDic["member3"].dps;
                return (2, "enemy", unionDic["enemy3"].health);
            case "enemy1":
                unionDic["member1"].health -= unionDic["enemy1"].dps;
                return (0, "member", unionDic["member1"].health);
            case "enemy2":
                unionDic["member2"].health -= unionDic["enemy2"].dps;
                return (1, "member", unionDic["member2"].health);
            case "enemy3":
                unionDic["member3"].health -= unionDic["enemy3"].dps;
                return (2, "member", unionDic["member3"].health);
        }

        return (2, "member", unionDic["member3"].health);
    }

    bool EnemiesWon()
    {
        foreach(CharacterObject c in team.Values)
        {
            if (c.health > 0)
            {
                return false;
            }
        }

        return true;
    }

    bool TeamWon()
    {
        foreach (CharacterObject c in enemyObjects.Values)
        {
            if (c.health > 0)
            {
                return false;
            }
        }

        return true;
    }

    List<(string, float)> ConstructSpeedList()
    {
        foreach (var item in speedDic)
        {
            var random = Random.Range(0.0f, 10000.0f)/10000;
            speedList.Add((item.Key, item.Value.speed+random));
        }

        var isUnique = speedList.Distinct().Count() == speedList.Count();

        while(!(isUnique))
        {
            for(int i = 0; i<speedList.Count(); i++)
            {
                var random = Random.Range(0.0f, 10000.0f) / 10000;
                var speed = speedList[i].Item2;
                speed += random;
            }
        }

        speedList = speedList.OrderBy(x => x.Item2).ToList();

        return speedList;
    }


}

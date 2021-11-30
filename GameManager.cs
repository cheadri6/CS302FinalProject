using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        //prevent duplicate instances
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

//Resources for the game

    //not currently used but good ideas
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices; //for upgrades
    public List<int> xpTable; //how much XP you need to level up 

    //References
    public Player player;
    //public weapon weapon...

    //Player stuff - do these need inital values?
    public int gold;
    public int experience;
    public bool hasSword;
    public bool hasWand;
    public bool hasHPPotion;
    public bool hasKey;
    public int attackDamage; //not used ?
    public int hitPoints;    //not used? 
    //public <String> inventory?



    /* SaveState saves the following:
     *  int gold
     *  int experience
     *  bool hasSword
     *  bool hasWand;
     *  bool hasHPPotion;
     *  bool hasKey;
     *  int attackDamage;
     *  int hitPoints;
     */
    
    public void SaveState()
    {
        string s = ""; // will have form "gold|experience|weaponLevel|etc"
        s += gold.ToString() + "|";         //gold
        s += experience.ToString() + "|";   //experience
        s += hasSword + "|";                //hasSword?
        s += hasWand + "|";                 //etc
        s += hasHPPotion + "|";
        s += hasKey + "|";
        s += attackDamage + "|";            
        s += hitPoints + "|";                 

        PlayerPrefs.SetString("SaveState", s);
    }

    //Loads what was saved
    public void LoadState( Scene s, LoadSceneMode mode )
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|'); // '|' is delimiter for Split()
 
        gold = int.Parse(data[0]);
        experience = int.Parse(data[1]);
        //hasSword = bool.Parse(data[2]);
        //hasWand = bool.Parse(data[3]);
        //hasHPPotion = bool.Parse(data[4]);
        //hasKey = bool.Parse(data[5]);
        //attackDamage = int.Parse(data[6]);
        //hitPoints = int.Parse(data[7]);
    }

    //for a fresh new game
    public void clearState()
    {
        gold = 0;
        experience = 0;
        hasSword = false;
        hasWand = false;
        hasHPPotion = false;
        hasKey = false;
        attackDamage = 5; //? not used ?
        hitPoints = 10;    //? not used ?
    }
     
}

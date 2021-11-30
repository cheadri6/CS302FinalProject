using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1;
    }
    public void ButtonNewScene()
    {
        SceneManager.LoadScene("dungeon1");
    }

    public void ButtonVictoryNewScene()
    {
        SceneManager.LoadScene("dungeon1_no_troll");
        Debug.Log("going to new scene");
    }
    public void ButtonStartGame()
    {
        SceneManager.LoadScene("dungeon1");
    }
}

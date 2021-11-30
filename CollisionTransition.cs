using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionTransition : MonoBehaviour
{
private void OnCollisionEnter2D(Collision2D collision)
{
    if(collision.gameObject.name == "Troll")
    {
        SceneManager.LoadScene("BattleScene");
    }
    if(collision.gameObject.name == "exit_portal")
    {
        SceneManager.LoadScene("ExitScreen");
    }
}
}

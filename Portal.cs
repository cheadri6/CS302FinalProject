using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{

    public string[] sceneNames; //array of all scene names - use for teleportation to RANDOM new scene

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        { //then teleport the player

            //source.Play(); //play teleportation sound

            //save ur current state b4 teleport
            GameManager.instance.SaveState();

            Debug.Log("GAME should be SAVED - ACTIVATING PORTAL");

            //randomly gets a scene name from the array of all such names -
             //if only one scene name, it always goes to that scene 
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            SceneManager.LoadScene(sceneName); //loads it
        }
    }
}

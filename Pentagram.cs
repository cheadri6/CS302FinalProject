using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : Collidable 
{

    public Sprite activatedPentagram; //so you can switch to a gold-less chest sprite after grabbing the gold 
    public int sanityCost = -10;
    public bool activated = false; 


    protected override void OnCollide(Collider2D coll) //redefines OnCollect for Pentagram
    {
        if (coll.name == "Player")
        {
            if (!activated)
            {
                activated = true;
                Debug.Log("Activated portal"); //testing
                Debug.Log("Lose " + sanityCost + " sanity");
                GetComponent<SpriteRenderer>().sprite = activatedPentagram;
                source.Play();
               
            }
        }
    }
}

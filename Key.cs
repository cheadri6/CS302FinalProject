using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable //Chest inherits from Collectable inherits from Collidable 
{
    public Sprite nullKey;
    protected override void OnCollect() //redefines OnCollect for Sword objects
    {
        if (!collected) //if we didn't already get the skey
        {
            source.Play(); //play SFX
            Debug.Log("GOT KEY"); //for testing
            collected = true; //we gon get that key
            GameManager.instance.hasKey = true; //put it in inventory
            GetComponent<SpriteRenderer>().sprite = nullKey;
        }

    }
}

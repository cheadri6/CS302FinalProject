using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    // Logic
    protected bool collected = false; //all children (eg Chest, Sword) have access to protected fields 

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player") //if the player collided with this (a Collectable)...
        {
            OnCollect(); //...then call OnCollect
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}

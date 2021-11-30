using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Consumable : Collectable
{
   
    protected bool consumed; //all children (eg Potion, Aple) have access to protected fields 

    //PICK UP THE CONSUMABLE
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player") //if the player collided with this (a Collectable)...
        {
            OnCollect(); //...then call OnCollect
        }
    }

    //CONSUME IT
    //don't have a way to call this YET
    protected virtual void OnConsume()
    {
        //Debug.Log( "Consume item" ); //testing
        consumed = true;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : Collidable
{
    public bool opened;
    public Sprite openedSprite;

    //DID YOU TRY TO OPEN IT 
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player") //if the player collided with this door
        {
            Open(); //open it
        }
    }

    //IF NO KEY NEEDED TO OPEN THIS
        //if a key is needed use child Keyed_Openable
    protected virtual void Open()
    {
       //source.Play(); //play sound effect
        opened = true;
        //GetComponent<SpriteRenderer>().sprite = openedSprite; //display the opened sprite
        Debug.Log( "Opened" );
        Destroy(gameObject);
    }

}

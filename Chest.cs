using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable //Chest inherits from Collectable inherits from Collidable 
{

    public Sprite openChest; //so you can switch to a gold-less chest sprite after grabbing the gold 
    public int goldAmount = 10;

    protected override void OnCollect() //redefines OnCollect for Chest objects
    {   
        if (!collected) //if there's still gold in the chest
        {
            Debug.Log( "Grant " + goldAmount + " gold from chest" ); //testing
            collected = true; //then we gon get that gold
            GetComponent<SpriteRenderer>().sprite = openChest;
            GameManager.instance.gold += goldAmount;
            source.Play();
        }
    
    }
}

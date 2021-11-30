using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Potion : Consumable //Chest inherits from Collectable inherits from Collidable 
{
    public Sprite nullPotion; //delete from map
    public Sprite emptyPotion; //swicth to this sprite when u drink it 
    public int HPGain = 5;

    //PICK UP the potion
    protected override void OnCollect() //redefines OnCollect for Chest objects
    {
        if (!collected) //if you haven't picked it up yet
        {
            Debug.Log("PICKED UP HP HEALTH POTION"); //testing
            GetComponent<SpriteRenderer>().sprite = nullPotion;
            collected = true; //then we gon pick it up
            source.Play(); //play "item collected" sound
            GameManager.instance.hasHPPotion = true; //put it in inventory 
        }

    }
    //DRINK the potion
    //don't have a way to call this YET
    protected override void OnConsume()
    {
        consumed = true;
        GetComponent<SpriteRenderer>().sprite = emptyPotion; //change to empty bottle image
        GameManager.instance.hitPoints += HPGain; //increase HP accordingly
        Debug.Log("DRANK POTION - HP +" + HPGain); //testing
        GameManager.instance.hasHPPotion = false; //remove from inventory
        
    }
}

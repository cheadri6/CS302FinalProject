using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : Collectable //Chest inherits from Collectable inherits from Collidable 
{
    public int attackModifier = 8; //sword is +4 to attack
    public bool equipped; //not used yet

    protected override void OnCollect() //redefines OnCollect for Sword objects
    {
        if (!collected) //if we didn't already get the sword
        {
            Debug.Log("GOT WAND - Attack +" + attackModifier); //for testing
            collected = true; //we gon get that sword
            source.Play(); //play "item collected" sound
            GameManager.instance.hasWand = true;
            Destroy(gameObject); //delete it from the map
            GameManager.instance.attackDamage += attackModifier; //increase players attack modifier 
        }
    }
}

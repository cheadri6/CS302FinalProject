using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Collectable //Chest inherits from Collectable inherits from Collidable 
{
    public int attackModifier = 4; //sword is +4 to attack
    public bool equipped; //not used yet
    public Sprite nullSword; //replace it with invisisword lol

    protected override void OnCollect() //redefines OnCollect for Sword objects
    {
        if (!collected) //if we didn't already get the sword
        {
            source.Play(); //play "item collected" sound
            Debug.Log("GET SWORD - Attack +" + attackModifier ); //for testing
            collected = true; //we gon get that sword
            GameManager.instance.hasSword = true; //put it in inventory
            GetComponent<SpriteRenderer>().sprite = nullSword;
            GameManager.instance.attackDamage += attackModifier; //increase players attack modifier 
        }

    }
}

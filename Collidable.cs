using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))] //automatically adds one if doesn't have it
public class Collidable : MonoBehaviour
{
    public ContactFilter2D filter; //helps u know what to collide with
    private BoxCollider2D boxCollider; //private bc just for this object script is applied to 
    private Collider2D[] hits = new Collider2D[10]; //array of what you hit this move - 10 hits v unlikely
    protected AudioSource source;

    protected virtual void Start() //runs each loop
    {
        boxCollider = GetComponent<BoxCollider2D>();
        source = GetComponent<AudioSource>();
    }

    protected virtual void Update() //looks for something that might be in collision
    {
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++) 
        {
            if (hits[i] == null) //if u there's no hit here
            {
                continue;
            }
            //else calls OnCollide function which will be inheritable, different for different objects 
            OnCollide(hits[i]); 

            hits[i] = null; //reset/clean array for next time
        }
    }
    protected virtual void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name); //allows you to see what it's colliding w in Unity terminal as u run game
        source.Play();
    }



}

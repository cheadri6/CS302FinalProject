using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(BoxCollider2D))] //prevents an error if you forget it

//THIS CLASS MOVES A SPRITE - currently it can move it up, down, left, and right
//  and will collide aka not walk over anything on an Actor or Blocking layer.
// It is currently applied to the princess bubblegum sprite
// and that's why it's called "pb move"
//  but you can drag this script onto any sprite and it will have identical behavior


//all credit for this goes to Epitome on YouTube and his comprehensive beginner tutorial
 //which can be found at https://www.youtube.com/watch?v=b8YUfee_pzc 
public class Player: MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta; //moveDelta tracks how far you move per movement  
    private RaycastHit2D hit; //checks if ur allowed to go somewhere
    public float speed = 1;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); //generic collision item
    }
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal"); //WASD / arrow keys for side to side
        float y = Input.GetAxisRaw("Vertical");
        

        Debug.Log(x); //every second it will show this value in the terminal 
        Debug.Log(y); //if you press a WASD/arrow key it will be 1 or -1, otherwise 0


        //reset moveDelta
        moveDelta = new Vector3(x,y,0);

        //Move right
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }

        //Move left
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1); 

        //makes sure if hits anything on BLOCKING actor layer on Y AXIS it can't move
        //"make sure we can move there by casting a box there first, if box returns null, we're free to move" - youtube tutorial 

        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * speed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make the sprite move! args are (x,y,z)
            transform.Translate(0, moveDelta.y * speed * Time.deltaTime, 0); //same time on any device
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * speed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make the sprite move!
            transform.Translate(moveDelta.x * speed * Time.deltaTime, 0, 0); //same time on any device
        }

        
        //transform.Translate(0, moveDelta.y * Time.deltaTime, 0); //same time on any device
       //transform.Translate(moveDelta.x * Time.deltaTime, 0, 0); //same time on any device


    }

    // Update is called once per frame,
    //   scans for user input and updates game accordingly, 
    //      kind of like how Arduino is infinitely looping
    void Update()
    {
        
    }
}

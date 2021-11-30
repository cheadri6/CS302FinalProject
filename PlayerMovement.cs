using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Thanks to Brakeys on Youtube for scripting help and sprite pack
//https://www.youtube.com/watch?v=whzomFgjT50

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem particles;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private RaycastHit2D hit; //checks if ur allowed to go somewhere
    Vector2 movement;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); //generic collision item
    }

   
    // Update is called once per frame
    // This is bad for phycics bc framerate can be variable
    // but good for registering input
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movement.x, 0), Mathf.Abs(movement.x * moveSpeed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            //make the sprite move
            animator.SetFloat("Horizontal", movement.x);
            //transform.Translate(movement.x * moveSpeed * Time.deltaTime, 0, 0);
        }

        movement.y = Input.GetAxisRaw("Vertical");
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movement.y), Mathf.Abs(movement.y * moveSpeed * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if (hit.collider == null)
        {
            animator.SetFloat("Vertical", movement.y);
            //transform.Translate(0, movement.y * moveSpeed * Time.deltaTime, 0);
        }
       
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    //This has a fixed timer so better for animation
    private void FixedUpdate()
    {
        //constant movement speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

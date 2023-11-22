using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping; 

    private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxis("Horizontal");                     //handle the speed and movement of the character 
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)                    //this gives the player the ability to jump and checks to make sure the player isn't already jumping
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));      
        }
    }

    private void OnCollisionEnter2D(Collision2D other)      //prevents the player from infinitely jumping by checking for collision between the assets tags 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false; 
        }
    }

    private void OnCollisionExit2D(Collision2D other)     //if the player is touching the ground, then allow them to jump 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true; 
        }
    }
}

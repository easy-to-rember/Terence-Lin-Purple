using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    //DJP for Player
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    //bool to check the grounded status of the object
    float posX = 0.0f;
    //object's position
    Rigidbody2D rb;
    //object's rigidbody2d

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        //assign the component of Rigidbody2D to the rb variable
        posX = transform.position.x;
        //assign the object's position on the x axis to the posX variable


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (transform.position.x < posX)
        {
            GameOver();
        }
        //if the spacebar is pressed (input by/from user) whilst the object is on the ground
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));
            //adds upward jumping force to the object multiplied by jump power, mass, and gravity
        }
    }
    //called when the collider on another object is touching is continously (updating every frame) touching this object's collider
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        //if the colliders tag is equivalent to "ground"
        {
            //isGrounded is true
            isGrounded = true;
        }
    }
    //called when the collider on another object is no longer touching this object's collider, after previously touching this object's collider 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameOver();
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();
            Destroy(collision.gameObject);
        }
    }
    void GameOver()
    {
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }
}

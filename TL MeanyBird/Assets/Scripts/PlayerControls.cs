using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Game Manager Object
    [Header("game controller object for controlling the game")]
    public GameController gameController;
    [Header("Default Velocity")]
    public float velocity = 5;
    //physics for the bird
    private Rigidbody2D rb;
    //height of the bird object on the y axis private float objectHeight;
    private float objectHeight;
    // Start is called before the first frame update
    void Start()
    {
        //Game Controller component
        gameController = GetComponent<GameController>();
        // Spead for the game is at a playing state
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        //Object Height equals the size of the height of the sprite
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void Update()
    {
        //If the left mouse button is clicked
        if (Input.GetMouseButton(0))
        {
            //The bird will gloat up on the Y axis
            //and float back down on Y axis
            rb.velocity = Vector2.up * velocity;
        }
    }

    //Function where the player collides with an object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HighSpike"
            || collision.gameObject.tag == "LowSpike"
            || collision.gameObject.tag == "Ground")
        {
            //Game over function is called from the game manager
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }   
}

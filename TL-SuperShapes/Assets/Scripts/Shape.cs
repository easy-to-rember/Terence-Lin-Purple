using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [Header("Rigidbody Object")]
    public Rigidbody2D rb;

    [Header("Default Shrinking Speed")]
    public float shrinkSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 10f;
        // local scale for this polygon equals 1 for x,y,z multiplied by ten 

    }

    // Update is called once per frame
    void Update()
    {
        //local scale for this polygon is equal to shrinking multiplied by the axes sizes multiplied by game rate
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
        // if the local scale on the x axis is less than, or equal to, 0.05f
        if (transform.localScale.x <= .05f)
        {
            //then, destroy the object
            Destroy(gameObject);
            Score.score++;
        }

    }
}

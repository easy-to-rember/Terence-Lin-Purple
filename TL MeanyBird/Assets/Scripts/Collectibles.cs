using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        //add score
        Score.score++;
    }
}

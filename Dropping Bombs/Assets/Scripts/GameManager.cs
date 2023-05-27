using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;

    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        // assign 'spawner' variable to the component of Spawner in the "Spawner" GameObject
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            spawner.active = true;
        }
    }
}

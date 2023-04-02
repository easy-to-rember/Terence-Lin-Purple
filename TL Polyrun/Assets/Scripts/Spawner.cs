using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("CHALLENGEOBJ GAME OBJECT")]
    public GameObject challengeObject;
    [Header("DEFAULT SPAWN DELAY TIME")]
    public float spawnDelay = 1f;
    [Header("DEFAULT SPAWN TIME")]
    public float spawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObjects", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(15, -1.24f, 0);
    }
    
    void InstantiateObjects()
    {
        Instantiate(challengeObject, transform.position, transform.rotation);
    }
}

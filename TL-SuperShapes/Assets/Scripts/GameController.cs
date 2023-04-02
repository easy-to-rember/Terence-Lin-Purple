using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Shape Objects")]
    public GameObject[] shapePrefabs;
    [Header("Default Spawn Delay Time")]
    public float spawnDelay = 2f;
    [Header("Default Spawn Time")]
    public float spawnTime = 3f;
    [Header("Game Over UI Object")]
    public GameObject gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Spawn()
    {
        int randomInt = Random.Range(0, shapePrefabs.Length);
        // create variable and assigned it to a random range for shape object prefabs, from 0 to the shapePrefab's length, to be spawned
        Instantiate(shapePrefabs[randomInt], Vector3.zero, Quaternion.identity);
        // create a new instance of this polygon at position
    }

    public void GamerOver()
    {
        CancelInvoke("Spawn");
        //cancels the spawn function
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}

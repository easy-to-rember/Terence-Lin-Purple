using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gamestarted = false;

    private void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        // assign 'spawner' variable to the component of Spawner in the "Spawner" GameObject
        player = playerPrefab;
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        var nextBomb = GameObject.FindGameObjectsWithTag("bomb");
        if (Input.anyKeyDown)
        {
            spawner.active = true;
            title.SetActive(false);
        }
        foreach (GameObject bombObject in nextBomb)
        {
            if(bombObject.transform.position.y < (-screenBounds.y) - 12)
            {
                Destroy(bombObject);
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "projectile")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            // order matters, and what does destroying an object destroy?
        }
    }
}

    

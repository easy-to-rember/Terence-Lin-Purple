using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Cube Object")]
    public GameObject currentCube;
    [Header("Last Cube Object")]
    public GameObject lastCube;
    [Header("Text object")]
    public Text text;
    [Header("Current level")]
    public int Level;
    [Header("Boolean")]
    public bool Done;

    void NewBlock()
    {
        ///if the last cube is not destroyed
        if (lastCube != null)
        {
            //The current cube position equals to all 3 axis positions to the nearest integer
            currentCube.transform.position =
                new Vector3(Mathf.Round(currentCube.transform.position.x),
                currentCube.transform.position.y,
                Mathf.Round(currentCube.transform.position.z));
            //current cubes size equals to the last cube size
            currentCube.transform.localScale =
                new Vector3(lastCube.transform.localScale.x -
                Mathf.Abs(currentCube.transform.position.x -
                lastCube.transform.position.x),
                lastCube.transform.localScale.y,
                lastCube.transform.localScale.z -
                Mathf.Abs(currentCube.transform.position.z -
                lastCube.transform.position.z));
            //current cubes position equals to the current cubes x position last cubes y position z axis position of 0.5
            currentCube.transform.position =
                Vector3.Lerp(currentCube.transform.position, lastCube.transform.position, 0.5f) + Vector3.up * 5f;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

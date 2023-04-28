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
                
            if (currentCube.transform.localScale.x <= 0f || currentCube.transform.localScale.z <= 0f)
            {
                Done = true;
                text.gameObject.SetActive(true);
                text.text = "Final Score:" + Level;
                StartCoroutine(X());
                return;
            }
        }
        
        

        lastCube = currentCube;
        //last cube is equal to the current cube
        currentCube = Instantiate(lastCube);
        //currrent cube is equal to the spawns last cube
        currentCube.name = Level + "";
        //current cube is equal to the level's number
        currentCube.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.HSVToRGB((Level / 100f) % 1f, 1f, 1f));
        Level++;
        //add 1 to level
        Camera.main.transform.position = currentCube.transform.position + new Vector3(100, 100, 100);
        //camera position is equal to the position of the current cube
        Camera.main.transform.LookAt(currentCube.transform.position);
        //camera looks at the current cube/its position
    }

    // Start is called before the first frame update
    void Start()
    {
        NewBlock();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Done)
        {
            //return value
            return;
        }
        var time = Mathf.Abs(Time.realtimeSinceStartup % 2f - 1f);
        //variable time equals to the time since game startup
        var pos1 = lastCube.transform.position + Vector3.up * 10f;
        //variable pos1 equals last cube position
        var pos2 = pos1 + ((Level % 2 == 0) ? Vector3.left : Vector3.forward) * 120;
        //variable pos2 equals pos1 + any Level number of 2
        if (Level % 2 == 0)
        //if the Level number is bt the number of 2
        {
            currentCube.transform.position = Vector3.Lerp(pos2, pos1, time);
            //current cube's position based of the 3 axis (pos2, pos1, and time)
        }
        else
        {
            currentCube.transform.position = Vector3.Lerp(pos1, pos2, time);
            //current cube's position based of the 3 axis (pos1, pos2, and time)
        }
        if (Input.GetMouseButtonDown(0))
            //if m1 button is clicked
        {
            NewBlock();
            //call NewBlock function
        }
     
        
    }
    IEnumerator X()
    {
        yield return new WaitForSeconds(3f);
        //wait three seconds before code is executed: sample scene is loaded
        SceneManager.LoadScene("SampleScene");
    }
}

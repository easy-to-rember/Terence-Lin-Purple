using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //After this time, the object will be destoryed
    [Header("Default Destruction Time")]
    public float timeToDestruction;
    // Start is called before the first frame update
    void Start()
    {
        //execute destroyobject functions based on timeToDestruction
        Invoke("DestroyObject", timeToDestruction);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void DestroyObject()
    {
        //Destroy object
        Destroy(gameObject);
    }
}


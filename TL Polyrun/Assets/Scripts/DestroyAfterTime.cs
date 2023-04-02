using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("DESTRUCTION TIMER")]
    public float timeToDestruction;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObject", timeToDestruction);

    }
    //doesn't work
    void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBehavior : MonoBehaviour
{


    public GameObject aoeCircle;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBehavior : AOEController
{


    public GameObject aoeCircle;

    protected override void Start()
    {
        Destroy(gameObject, duration);
    }    
}

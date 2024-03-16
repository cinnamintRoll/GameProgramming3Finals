using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAOEBehavior : ThrowAOEController
{
    public float destroyAfterSeconds;

    protected override void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}

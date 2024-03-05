using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalBehavior : MonoBehaviour
{
    public float destroyAfterSeconds;

    public void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}


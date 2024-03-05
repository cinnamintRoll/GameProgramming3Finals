using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBehavior : MonoBehaviour
{


    public GameObject player; 
    public GameObject aoeCircle;
    public float destroyAfterSeconds;

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
    private void Update()
    {
        if (player != null && aoeCircle != null)
        {
            aoeCircle.transform.position = player.transform.position;
        }
    }
}

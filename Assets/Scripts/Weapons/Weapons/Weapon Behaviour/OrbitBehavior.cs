using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBehavior : OrbitController
{
    private Transform playerTransform; // Reference to the player's transform
    private float angle = 0f;
    private float elapsedTime = 0f;
    private bool isOrbiting = true;
    public float orbitRadius = 2f;

    protected override void Start()
    {
        // Find the GameObject with the tag "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    protected override void Update()
    {
        if (isOrbiting && playerTransform != null)
        {
            // Calculate the position of the projectile relative to the player
            float x = playerTransform.position.x + Mathf.Cos(angle) * AOE;
            float y = playerTransform.position.y + Mathf.Sin(angle) * AOE;
            Vector3 orbitPosition = new Vector3(x, y, 0f);

            // Set the position of the projectile
            transform.position = orbitPosition;

            // Update the angle for the next frame
            angle += speed * Time.deltaTime;

            // Ensure the angle stays within the range of 0 to 2*pi
            if (angle > Mathf.PI * 2f)
            {
                angle -= Mathf.PI * 2f;
            }

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Check if the duration has elapsed
            if (elapsedTime >= duration)
            {
                Destroy(gameObject);
            }
        }
    }
}

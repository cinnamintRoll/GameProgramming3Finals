using UnityEngine;

public class PenController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedPen = Instantiate(prefab);
        spawnedPen.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedPen.GetComponent<PenBehaviour>().DirectionChecker(pm.lastMovedVector);   //Reference and set the direction
    }
}

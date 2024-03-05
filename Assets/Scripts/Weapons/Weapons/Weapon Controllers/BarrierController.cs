using UnityEngine;

public class BarrierController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedBarrier = Instantiate(prefab);
        spawnedBarrier.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedBarrier.transform.parent = transform;
    }
}
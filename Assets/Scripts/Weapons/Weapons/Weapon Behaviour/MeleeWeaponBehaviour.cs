using UnityEngine;

/// <summary>
/// Base script of all melee behaviours [To be placed on a prefab of a weapon that is melee]
/// </summary>
public class MeleeWeaponBehaviour : WeaponController
{
    public float destroyAfterSeconds;

    protected override void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
}
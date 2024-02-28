using UnityEngine;

public class PenBehaviour : ProjectileWeaponBehaviour
{

    PenController pc;

    protected override void Start()
    {
        base.Start();
        pc = FindObjectOfType<PenController>();
    }

    void Update()
    {
        transform.position += direction * pc.speed * Time.deltaTime;    //Set the movement of the Pen
    }
}

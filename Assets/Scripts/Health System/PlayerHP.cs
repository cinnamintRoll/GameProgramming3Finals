using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : HealthSystem
{
    public event System.Action<float, float> OnPlayerHealthChanged;
    public GameOverManager gameOverManager;
    public float damageInterval = 5f;


    private float timer;


    protected override void Start()
    {
        base.Start();
        maxHP = baseHP;
        currentHP = maxHP;
        
    }


    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(currentHP, maxHP);
    }

    public override void Heal(float addHP)
    {
        base.Heal(addHP);
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(currentHP, maxHP);
    }

    protected override void Die()
    {
        base.Die();
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(0, maxHP);
        StartCoroutine(DelayedDeath());

        

    }

    IEnumerator DelayedDeath()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameOverManager != null)
        {
            gameOverManager.GameOver();
        }
        Destroy(gameObject);
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(0, maxHP);
    }

    public void ReduceToMinimumHealth()
    {
        currentHP = 1;
        if (OnPlayerHealthChanged != null) OnPlayerHealthChanged(currentHP, maxHP);
    }



    private void OnCollisionStay2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>(); //Temporary

            if (enemy != null)
            {
                timer += Time.deltaTime;

                if (timer >= damageInterval)
                {
                    TakeDamage(enemy.damage);
                    timer = 0f;
                }
            }
        }

    }

   /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TempHeal"))
        {
            Heal(2);
        }
    }*/
}

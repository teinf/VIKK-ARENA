using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroszkovEnemy : MonoBehaviour
{
    public GameObject DeathEffect;
    public int SPEED = 2;
    public int HEALTH = 3;

    void Update()
    {
        // ZYCIE
        HandleDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Damage(1);
            collision.GetComponent<Bullet>().Death();
        }
    }

    private void HandleDeath()
    {
        if (HEALTH <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int amount)
    {
        if (HEALTH > 0)
        {
            HEALTH -= amount;
            GameSounds.instance.GetEnemyHitSound(HEALTH);
        }
    }

    private void OnDestroy()
    {
        if (!GameHandler.instance.isQuitting)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            SmallGroszkov.Create(transform.position + new Vector3(0.5f, 0, 0));
            SmallGroszkov.Create(transform.position + new Vector3(0, 0.5f, 0));
            SmallGroszkov.Create(transform.position + new Vector3(-0.5f, 0, 0));
            Coin.Create(transform.position, 1);
            GameHandler.instance.AddScore(40);
        }
    }
}

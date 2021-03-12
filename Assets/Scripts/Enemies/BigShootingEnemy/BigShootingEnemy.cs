using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShootingEnemy : MonoBehaviour
{
    public GameObject DeathEffect;

    // WŁAŚCIWOŚCI
    public float stoppingDistance;
    public float runAwayDistance;

    public int speed = 1;
    public int health = 1;

    // WŁAŚCIWOŚCI STRZELANIA
    public float timeBtwShot = 2f;
    private float timeBtwLastShot = 0f;

    void Update()
    {
        HandleMovement();
        HandleShooting();
        HandleDeath();
    }

    private void HandleShooting()
    {
        if (timeBtwLastShot <= 0)
        {
            Vector3 toPlayerDir = Player.instance.GetPosition() - transform.position;
            BigEnemyBullet.Create(transform.position, toPlayerDir.normalized);
            timeBtwLastShot = timeBtwShot;
        }
        else
        {
            timeBtwLastShot -= Time.deltaTime;
        }
    }
    private void HandleMovement()
    {
        // PRZYBLIZANIE
        if (Vector2.Distance(Player.instance.GetPosition(), transform.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), speed * Time.deltaTime);
        }
        else if ((Vector2.Distance(Player.instance.GetPosition(), transform.position) < stoppingDistance) && (Vector2.Distance(Player.instance.GetPosition(), transform.position) > runAwayDistance))
        {
            transform.position = this.transform.position;
        }
        // UCIECZKA
        else if ((Vector2.Distance(Player.instance.GetPosition(), transform.position) < runAwayDistance))
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), 2 * -speed * Time.deltaTime);
        }
    }
    private void HandleDeath()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Damage(Player.instance.damage);
            collision.GetComponent<Bullet>().Death();
        }
    }

    public void Damage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            GameSounds.instance.GetEnemyHitSound(health);
        }
    }

    private void OnDestroy()
    {
        if (!GameHandler.instance.isQuitting)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Coin.Create(transform.position, 3);
            GameHandler.instance.AddScore(100);
        }
    }
}


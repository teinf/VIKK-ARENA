
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunEnemy : MonoBehaviour
{
    public GameObject DeathEffect;

    // WŁAŚCIWOŚCI
    public float stoppingDistance;
    public float runAwayDistance;

    public const float SPEED = 2f;
    public int health = 2;

    // WŁAŚCIWOŚCI STRZELANIA
    public float timeBtwShot = 2f;
    private float timeBtwLastShot;

    private void Start()
    {
        timeBtwLastShot = timeBtwShot;
    }
    void Update()
    {
        // ZMIANA POZYCJI
        Move();

        // STRZELANIE 
        HandleShooting();

        // ZYCIE
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void HandleShooting()
    {
        if (timeBtwLastShot <= 0)
        {
            ShotgunBullet.Create(transform.position, new Vector3(1, 0, 0));
            ShotgunBullet.Create(transform.position, new Vector3(0, 1, 0));
            ShotgunBullet.Create(transform.position, new Vector3(-1, 0, 0));
            ShotgunBullet.Create(transform.position, new Vector3(0, -1, 0));
            timeBtwLastShot = timeBtwShot;
        } else
        {
            timeBtwLastShot -= Time.deltaTime;
        }

    }
    private void Move()
    {
        // PRZYBLIZANIE
        transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), SPEED * Time.deltaTime);
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
            Coin.Create(transform.position, 2);
            GameHandler.instance.AddScore(40);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    public int SPEED = 1;
    public int HEALTH = 1;

    void Update()
    {
        // ZMIANA POZYCJI
        transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), SPEED * Time.deltaTime);

        // ZYCIE
        HandleDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Damage(Player.instance.damage);
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
        if(HEALTH > 0)
        {
            HEALTH -= amount;
            GameSounds.instance.GetEnemyHitSound(HEALTH);
        }
    }

    private void OnDestroy()
    {
        if(!GameHandler.instance.isQuitting)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Coin.Create(transform.position, 1);
            GameHandler.instance.AddScore(30);
        }
    }
}

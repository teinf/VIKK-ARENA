using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEnemy : MonoBehaviour
{
    public GameObject effect;
    public int SPEED = 3;
    public int HEALTH = 1;

    void Update()
    {
        HandleMovement();
        HandleDeath();
    }

    private void HandleMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), SPEED * Time.deltaTime);
    }
    private void HandleDeath()
    {
        if (HEALTH <= 0)
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
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Coin.Create(transform.position, 3);
            GameHandler.instance.AddScore(50);
        }
    }
}

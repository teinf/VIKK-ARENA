using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGroszkov : MonoBehaviour
{
    public GameObject DeathEffect;
    public int SPEED = 6;
    public int HEALTH = 1;

    public static SmallGroszkov Create(Vector3 position)
    {
        Transform SmallGroszkovTrans = Instantiate(GameAssets.instance.SmallGroszkov, position, Quaternion.identity);
        return SmallGroszkovTrans.GetComponent<SmallGroszkov>();
    }

    void Update()
    {
        // ZMIANA POZYCJI
        transform.position = Vector2.MoveTowards(transform.position, Player.instance.GetPosition(), SPEED * Time.deltaTime);

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
            Destroy(gameObject);
            Coin.Create(transform.position, 1);
            GameHandler.instance.AddScore(20);
        }
    }
}
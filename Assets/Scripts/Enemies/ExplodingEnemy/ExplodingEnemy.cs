using UnityEngine;

public class ExplodingEnemy : MonoBehaviour
{
    public GameObject DeathEffect;

    // WŁAŚCIWOŚCI
    public const float SPEED = 2f;
    public int health = 2;

    void Update()
    {
        // ZMIANA POZYCJI
        Move();

        // ZYCIE
        if (health <= 0)
        {
            Destroy(gameObject);
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
            ExplodingEnemyBullet.Create(transform.position, new Vector3(1, 0, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(0, 1, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(-1, 0, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(0, -1, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(1, 1, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(1, -1, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(-1, -1, 0));
            ExplodingEnemyBullet.Create(transform.position, new Vector3(-1, 1, 0));

            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Coin.Create(transform.position, 3);
            GameHandler.instance.AddScore(45);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public static Shield instance;

    public GameObject effect;
    public float health = 5f;
    public float MAX_HEALTH = 5f;
    public Slider slider;

    public bool isRegenerating = true;

    public SpriteRenderer sr;
    public EdgeCollider2D ec;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        MAX_HEALTH = slider.maxValue;
        if(Input.GetMouseButton(1) && health > 0 && !GameFreeze.instance.getPause() && !GameFreeze.instance.isDeath)
        {
            setShieldStatus(true);
            if (isRegenerating) resetRegen();
        }
        else
        {
            setShieldStatus(false);
            if(!isRegenerating) StartCoroutine("healthRegen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == "Enemy")
            {
                GameSounds.instance.GetShieldHitSound();
                Destroy(collision.gameObject);
                DamageShield(1);
                Instantiate(effect, transform.position, Quaternion.identity);
            }
            if (collision.tag == "EnemyBullet")
            {
                GameSounds.instance.GetShieldHitSound();
                Destroy(collision.gameObject);
                DamageShield(1);
                Instantiate(effect, transform.position, Quaternion.identity);
            }
    }

    void DamageShield(int amount)
    {
        if (health > amount) health -= amount;
        else health = 0;

        ShieldBar.instance.ChangeSize(health);
    }
    private void resetRegen()
    {
        isRegenerating = false;
        StopCoroutine("healthRegen");
    }
    private IEnumerator healthRegen()
    {
        isRegenerating = true;
        yield return new WaitForSeconds(3f); // Czekanie pierwszych 3 sekund

        while(health < MAX_HEALTH)
        {
            yield return new WaitForSeconds(1f); // Wykonywanie pętli co sekundę
            health++;
            ShieldBar.instance.ChangeSize(health);
        }
    }
    private void setShieldStatus(bool status)
    {
        Player.instance.isShielding = status;
        sr.enabled = status;
        ec.enabled = status;
    }
    public void AddMaxValue(int amount)
    {
        MAX_HEALTH+=amount;
        DamageShield(-1);
        isRegenerating = false;
        ShieldBar.instance.AddMaxValue(MAX_HEALTH);
    }
}

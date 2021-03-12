using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    Vector3 moveDir;
    public const float SPEED = 2f;

    public GameObject DEATH_EFFECT;

    public static ShotgunBullet Create(Vector3 position, Vector3 direction)
    {
        Transform bulletTransform = Instantiate(GameAssets.instance.shotgunBullet, position, Quaternion.identity);

        ShotgunBullet bullet = bulletTransform.GetComponent<ShotgunBullet>();
        bullet.Setup(direction);

        return bullet;
    }

    private void Awake()
    {
        Setup(moveDir);
    }

    private void Update()
    {
        transform.position = transform.position + moveDir * SPEED * Time.deltaTime;
        HandleDeath();
    }

    private void Setup(Vector3 moveDir)
    {
        this.moveDir = moveDir;
    }
    public void Death()
    {
        Instantiate(DEATH_EFFECT, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void HandleDeath()
    {
        if (transform.position.x > CameraScript.instance.maxScreenBounds.x || transform.position.x < CameraScript.instance.minScreenBounds.x || transform.position.y < CameraScript.instance.minScreenBounds.y || transform.position.y > CameraScript.instance.maxScreenBounds.y)
        {
            Death();
        }
    }


}

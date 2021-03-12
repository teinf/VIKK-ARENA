using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform player;
    public Transform bullet;
    public Transform enemyBullet;
    public Transform BigEnemyBullet;
    public Transform shotgunBullet;
    public Transform explodingEnemyBullet;
    public Transform coin;
    public Transform SmallGroszkov;

    public static Vector3 ToMouseDirection(Vector3 position, Vector3 mousePosition)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;

        Vector3 dir = mousePosition - position;
        dir.Normalize();

        return dir;
    }
}

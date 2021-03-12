using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAssets : MonoBehaviour
{
    public static ParticleAssets instance;

    private void Awake()
    {
        instance = this;
    }

    // ENEMY DEATHS
    public Transform pfxEnemyDeath;
    public Transform pfxShootingEnemyDeath;
    public Transform pfxNinjaEnemyDeath;
    public Transform pfxShotgunEnemyDeath;
    //public Transform pfxExplodingEnemyDeath;
    public Transform pfxBigEnemyDeath;

    // ENEMY BULLETS DEATHS
    public Transform pfxBullet_Enemy;
    public Transform pfxBullet_ShotgunEnemy;
    public Transform pfxBullet_BigEnemy;
    //public Transform pfxBullet_ExplodingEnemy;
}

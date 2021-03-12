using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemies;
    public static Spawner instance;

    public Transform[] spawnPoints;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        spawnPoints[0].position = new Vector3(CameraScript.instance.minScreenBounds.x, CameraScript.instance.minScreenBounds.y, 0);
        spawnPoints[1].position = new Vector3(CameraScript.instance.minScreenBounds.x, CameraScript.instance.minScreenBounds.y * 0.5f, 0);
        spawnPoints[2].position = new Vector3(CameraScript.instance.minScreenBounds.x, 0, 0);
        spawnPoints[3].position = new Vector3(CameraScript.instance.minScreenBounds.x, CameraScript.instance.maxScreenBounds.y * 0.5f, 0);
        spawnPoints[4].position = new Vector3(CameraScript.instance.minScreenBounds.x, CameraScript.instance.maxScreenBounds.y, 0);

        spawnPoints[5].position = new Vector3(CameraScript.instance.minScreenBounds.x * 0.5f, CameraScript.instance.maxScreenBounds.y, 0);
        spawnPoints[6].position = new Vector3(0, CameraScript.instance.maxScreenBounds.y, 0);
        spawnPoints[7].position = new Vector3(CameraScript.instance.maxScreenBounds.x * 0.5f, CameraScript.instance.maxScreenBounds.y, 0);

        spawnPoints[8].position = new Vector3(CameraScript.instance.maxScreenBounds.x, CameraScript.instance.maxScreenBounds.y, 0);
        spawnPoints[9].position = new Vector3(CameraScript.instance.maxScreenBounds.x, CameraScript.instance.maxScreenBounds.y * 0.5f, 0);
        spawnPoints[10].position = new Vector3(CameraScript.instance.maxScreenBounds.x, 0, 0);
        spawnPoints[11].position = new Vector3(CameraScript.instance.maxScreenBounds.x, CameraScript.instance.minScreenBounds.y * 0.5f, 0);
        spawnPoints[12].position = new Vector3(CameraScript.instance.maxScreenBounds.x, CameraScript.instance.minScreenBounds.y, 0);

        spawnPoints[13].position = new Vector3(CameraScript.instance.minScreenBounds.x * 0.5f, CameraScript.instance.minScreenBounds.y, 0);
        spawnPoints[14].position = new Vector3(0, CameraScript.instance.minScreenBounds.y, 0);
        spawnPoints[15].position = new Vector3(CameraScript.instance.maxScreenBounds.x * 0.5f, CameraScript.instance.minScreenBounds.y, 0);
    }

    public void EndlessModeSpawn()
    {
        int randomEnemy = Random.Range(0, Enemies.Length);
        int randomPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(Enemies[randomEnemy], spawnPoints[randomPoint].position, Quaternion.identity);
    }

    public void Spawn(GameObject enemy)
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemy, spawnPoints[randomPoint].position, Quaternion.identity);
    }
}

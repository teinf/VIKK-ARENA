using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instance;
    public GameObject winScreen;
    [HideInInspector]
    public string gameMode = "X";
    public int startRound = 0;


    private int[] enemyType;
    // enemyType[0] = Enemy
    // enemyType[1] = Shooting Enemy
    // enemyType[2] = Ninja Enemy
    // enemyType[3] = Shotgun Enemy
    // enemyType[4] = Big Shooting Enemy
    // enemyType[5] = Exploding Enemy
    // enemyType[6] = GroszkovEnemy


    //private int antiCrashUnitySystem = 0;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public float spawnTime;
        public int waveTime;
        public GameObject[] enemies;
        public int[] enemyCounts;
    }

    public Wave[] waves;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        enemyType = new int[Spawner.instance.Enemies.Length];
    }

    private int sumOfList(int[] lista)
    {
        int suma = 0;
        foreach (int num in lista)
        {
            suma += num;
        }
        return suma;
    }

    /*
    private IEnumerator numberOfEnemies()
    {
        while(true)
        {
            enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy").Length;
            yield return new WaitForSeconds(2f);
        }
    }
    */

    private IEnumerator Timer(int time)
    {
        // ODLICZANIE TIMERA PODCZAS WaveMode
        for (int i = time; i > 0; i--)
        {
            WaveTimer.instance.SetText("TIME: " + i.ToString("0"));
            yield return new WaitForSeconds(1f);
        }
        yield break;
    }

    private IEnumerator EndlessTimer()
    {
        // ODLICZANIE TIMERA PODCZAS WaveMode
        int i = 0;
        while(i++>=0)
        {
            WaveTimer.instance.SetText("TIME: " + i.ToString("0"));
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator waveSpawner(Wave _wave) 
    {
        List<GameObject> allEnemies = new List<GameObject>();
        // DODAWANIE WSZYSTKICH ENEMY DO JEDNEJ LISTY
        for(int i=0;i<_wave.enemies.Length;i++)
        {
            for(int j=0;j<_wave.enemyCounts[i];j++)
            {
                allEnemies.Add(_wave.enemies[i]);
                yield return null;
            }
            yield return null;
        }

        // SPAWNIENIE ICH
        while(allEnemies.Count>0)
        {
            int randomEnemy = Random.Range(0, allEnemies.Count);
            Spawner.instance.Spawn(allEnemies[randomEnemy]);
            allEnemies.Remove(allEnemies[randomEnemy]);
            yield return new WaitForSeconds(_wave.spawnTime);
        }
    }

    private IEnumerator WavesModeSpawner()
    {
        for (int i = startRound; i <= waves.Length; i++) // GŁÓWNA PĘTLA MIĘDZY FALAMI
        {
            if(i == waves.Length)
            {
                Invoke("ItsTimeToStop", 1.5f);
                winScreen.SetActive(true);
            }
            else
            {
                WaveCounter.instance.SetText("WAVE: " + (i + 1).ToString("0")); // ZACZYNAMY OD FALI 0 WIĘC +1 __ ZMIANA NR FALI
                WaveName.instance.SetText(waves[i].name);
                WaveName.instance.setTransparent();

                // USTAWIANIE LICZNIKA CZASU
                int timeToNextWave = waves[i].waveTime;
                StartCoroutine(Timer(timeToNextWave)); // WŁĄCZANIE TIMERA

                // SPAWNOWANIE PRZECIWNIKÓW
                StartCoroutine(waveSpawner(waves[i]));
                yield return new WaitForSeconds(timeToNextWave);
                StopCoroutine(waveSpawner(waves[i]));

                yield return null;
            }
        }
    }

    private IEnumerator endlessSpawner(float spawnTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawner.instance.EndlessModeSpawn();
            yield return null;
        }
    }

    private void ItsTimeToStop()
    {
        Time.timeScale = 0f;
    }
    

    public void StartWaveMode()
    {
        WaveCounter.instance.SetText("WAVE: 0");
        //StartCoroutine("WavesModeSpawner");
        StartCoroutine(WavesModeSpawner());
    }

    public void StartEndlessMode()
    {
        WaveName.instance.SetWaveNameLabelToFalse();
        WaveCounter.instance.SetText("ENDLESS MODE");
        WaveTimer.instance.SetText("1");
        StartCoroutine(EndlessTimer());
        StartCoroutine(endlessSpawner(1f)); // CO JEDNĄ SEKUNDE SPAWNI
    }
}

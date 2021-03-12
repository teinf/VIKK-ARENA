using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFreeze : MonoBehaviour
{
    public GameObject shop;
    public bool isPaused = false;
    public bool isDeath = false;
    public static GameFreeze instance;

    //Amatorski sposób ALE potrzebny, bo mało czasu
    public GameObject scoreLabel;
    public GameObject coinLabel;
    public GameObject healthBar;
    public GameObject healthText;
    public GameObject shieldBar;
    public GameObject waveLabel;
    public GameObject waveName;
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Player.instance.GetHealth() <= 0)
        {
            if(!isDeath)
            {
                isDeath = true;
                Player.instance.SetScore(ScoreCounter.instance.scoreText.text);
                GameSounds.instance.GetRelaxedSpaceMusicStop();
                GameSounds.instance.GetPlayerHitSoundStop();
                GameSounds.instance.GetGameOverSound(0);
                shop.SetActive(false);

                //Amatorski sposób ALE potrzebny, bo mało czasu
                scoreLabel.SetActive(false);
                coinLabel.SetActive(false);
                healthBar.SetActive(false);
                healthText.SetActive(false);
                shieldBar.SetActive(false);
                waveLabel.SetActive(false);
                waveName.SetActive(false);

                Player.instance.deathScreen.SetActive(true);
                Time.timeScale = 0f;
            }   
        }
        else if (Input.GetKeyDown("e"))
        {
            if (!isPaused && Player.instance.GetHealth() > 0 && WaveSystem.instance.gameMode != "X")
            {
                Time.timeScale = 0.2f;
                shop.SetActive(true);
                isPaused = true;
            }
            else if(isPaused)
            {
                Time.timeScale = 1.0f;
                shop.SetActive(false);
                isPaused = false;
            }
        }
    }

    public bool getPause()
    {
        return isPaused;
    }
}

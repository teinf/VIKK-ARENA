using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [HideInInspector]
    public bool isQuitting = false;
    

    public static GameHandler instance;

    [HideInInspector]
    public int coinAmount = 0;
    private int scoreAmount = 0;


    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }


    public void AddScore(int amount)
    {
        scoreAmount += amount;
        ScoreCounter.instance.scoreText.text = scoreAmount.ToString("0");
    }

    public void AddCoin(int amount)
    {
        GameSounds.instance.GetTakingCoinSound();
        coinAmount += amount;
        CoinCounter.instance.coinText.text = coinAmount.ToString("0");
    }

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public static void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for(int i=coins.Length - 1; i>=0; i--)
        {
            Destroy(coins[i].gameObject);
        }
    }
}

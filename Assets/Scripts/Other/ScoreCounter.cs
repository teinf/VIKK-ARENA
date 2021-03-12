using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;

    public Text scoreText;

    private void Awake()
    {
        instance = this;
        scoreText.fontSize = 23;
        scoreText.text = "0";
        
    }
    public void SetText(string text)
    {
        scoreText.text = text;
    }
   
}

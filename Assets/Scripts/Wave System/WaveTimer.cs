using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    public static WaveTimer instance;
    public Text timeCounter;

    private void Awake()
    {
        instance = this;
    }

    public void SetText(string text)
    {
        timeCounter.text = text;
    }
}

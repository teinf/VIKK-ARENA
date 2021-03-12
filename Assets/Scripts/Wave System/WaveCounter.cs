using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static WaveCounter instance;
    public Text waveCounter;

    private void Awake()
    {
        instance = this;
    }

    public void SetText(string text)
    {
        waveCounter.text = text;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class WaveName : MonoBehaviour
{
    public GameObject WaveNameLabel;
    public static WaveName instance;
    public Text waveName;
    private void Awake()
    {
        instance = this;
    }

    public void SetText(string text)
    {
        waveName.text = text;
    }

    public void setTransparent()
    {
        gameObject.GetComponent<Animator>().Play(0);
    }

    public void SetWaveNameLabelToFalse()
    {
        WaveNameLabel.SetActive(false);
    }
}

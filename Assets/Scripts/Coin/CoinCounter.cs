using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public Text coinText;

    private void Awake()
    {
        instance = this;
        coinText.fontSize = 23;
        coinText.text = "0";
    }

    public void SetText(string text)
    {
        coinText.text = text;
    }
}

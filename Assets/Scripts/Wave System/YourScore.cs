using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YourScore : MonoBehaviour
{
    public TextMeshProUGUI Text;

    void Start()
    {
        Text.text = Player.instance.Score;
    }
}

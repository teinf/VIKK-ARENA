using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{
    public static ShieldBar instance;
    Slider shieldSlider;
    private void Awake()
    {
        instance = this;
        shieldSlider = gameObject.GetComponent<Slider>();
    }

    public void AddMaxValue(float amount)
    {
        shieldSlider.maxValue = amount;
    }

    public void ChangeSize(float health)
    {
        shieldSlider.value = health;
    }
}

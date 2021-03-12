using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Slider healthSlider;
    public Image fill;

    float helper = 200;
    bool add = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //ColorChanger();
    }

    private void ColorChanger()
    {
        if (Player.instance.GetHealth() <= Player.instance.GetMaxHealth() * 0.34)
        {
            if (helper > 200) { add = false; }
            if (helper < 100) { add = true; }

            if (add)
            {
                helper += 100 * Time.deltaTime;
            }
            else if (!add)
            {
                helper -= 100 * Time.deltaTime;
            }
            fill.color = new Vector4(255, 0, 0, helper);
        }
        else
        {
            helper = 200;
            add = false;
            fill.color = new Vector4(255, 0, 0, 255);
        }
    }

    public void ChangeSize(float health)
    {
        healthSlider.value = health;
    }
    public void addMaxValue(int amount)
    {
        healthSlider.maxValue = amount;
    }
}

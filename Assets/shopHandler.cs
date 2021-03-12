using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shopHandler : MonoBehaviour
{
    public static shopHandler instance;
    public  Slider slider;
    public GameObject damageUp;

    private void Awake()
    {
        instance = this;
    }
    public void health()
    { 
        if (GameHandler.instance.coinAmount >= 5 && Player.instance.GetHealth() != Player.instance.GetMaxHealth() && Player.instance.GetHealth() > 0)
        {
            Player.instance.addHealth(1);
            GameHandler.instance.AddCoin(-5);
        }            
    }
    public void shield()
    {
        if (GameHandler.instance.coinAmount >= 15)
        {
            Shield.instance.AddMaxValue(1);
            GameHandler.instance.AddCoin(-15);
        }
    }
    public void damage()
    {
        if(Player.instance.damage < 4 && GameHandler.instance.coinAmount >= 40)
        {
            Player.instance.addDamage(1);
            GameHandler.instance.AddCoin(-40);

            if (Player.instance.damage == 4)
            {
                damageUp.SetActive(false);
            }
        }

    }
    public void healthUp()
    {
        if (GameHandler.instance.coinAmount >= 25 && Player.instance.GetHealth() > 0)
        {
            Player.instance.addMaxHealth(2);
            GameHandler.instance.AddCoin(-25);
        }
    }
    public void menu()
    {
        Player.instance.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
}

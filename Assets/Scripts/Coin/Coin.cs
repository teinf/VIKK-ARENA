using UnityEngine;

public class Coin : MonoBehaviour
{
    //public GameObject effect;
    public GameObject effectWhenPickedUp;
    public GameObject effectWhenWaiting;
    private Transform player;
    public static Coin instance;

    // MAGNET
    private bool isFollowing = false;
    public float magnetRange;
    public float magnetPower;

    public static void Create(Vector3 position, int amount)
    {
        GameSounds.instance.GetEnemyDeathSound();
        for (int i = 0; i < amount; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            Instantiate(GameAssets.instance.coin, position+offset, Quaternion.identity);
        }
    }

    private void Awake()
    {
        instance = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        HandleAnimation();
        HandleMagnet();
    }

    private void HandleAnimation()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 1.8f * Time.deltaTime * 100;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

    private void HandleMagnet()
    {
            if (Vector2.Distance(transform.position, player.position) < magnetRange && !isFollowing)
            {
                isFollowing = true;
            }

            if (isFollowing)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, magnetPower * Time.deltaTime);
            }
    }

    private void OnDestroy()
    {
        if(!GameHandler.instance.isQuitting)
        {
            if(effectWhenPickedUp != null) { Instantiate(effectWhenPickedUp, transform.position, Quaternion.identity); }
            GameHandler.instance.AddCoin(1);
        }
    }
}

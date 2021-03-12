using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    private const float SPEED = 8f;
    private Vector3 moveVelocity;
    private  int MAXHEALTH = 10;
    private int health;
    public int damage = 1;

    public GameObject effect;
    public GameObject deathScreen;
    public GameObject shield;

    public bool canShoot = true;
    public bool isShielding = false;
    public string Score;

    private Vector3 mouse;
    private float angle;

    // FireRatecx
    private float fireRate = 0.30f;
    private float timeBtwLastShot = 0f;

    private void Awake()
    {
        instance = this;
        health = MAXHEALTH;
    }

    private void Start()
    {
        GameSounds.instance.GetRelaxedSpaceMusicStart(0);
    }
    private void Update()
    {
        if(WaveSystem.instance.gameMode != "X" && !GameFreeze.instance.isPaused)
        {
            HandleMovement();
            HandleShooting();
            HandleRotation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Enemy")
        {
            Damage(1);
            Destroy(collision.gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }

        if (collision.tag == "EnemyBullet")
        {
            Damage(1);
            Destroy(collision.gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
        if (collision.tag == "BigEnemyBullet")
        {
            Damage(2);
            Destroy(collision.gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }

    private void HandleMovement()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput * SPEED * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 
            CameraScript.instance.minScreenBounds.x,
            CameraScript.instance.maxScreenBounds.x),
            Mathf.Clamp(transform.position.y, 
            CameraScript.instance.minScreenBounds.y, +
            CameraScript.instance.maxScreenBounds.y), 0);
        transform.position += moveVelocity;
        
    }
    private void HandleRotation()
    {
        mouse = GameAssets.ToMouseDirection(transform.position, Input.mousePosition);
        angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg * Time.timeScale;
        transform.rotation = Quaternion.AngleAxis(angle-180, Vector3.forward);
    }
    private void HandleShooting()
    {
        if(timeBtwLastShot >= fireRate)
        {
            canShoot = true;
        }

        if (Input.GetMouseButton(0) && canShoot && !isShielding)
        {
            Vector3 spreadOffset = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            Bullet.Create(GetPosition(), GameAssets.ToMouseDirection(GetPosition() + spreadOffset/2 , Input.mousePosition));
            timeBtwLastShot = 0;
            canShoot = false;
        }
        timeBtwLastShot += Time.deltaTime;
    }
    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }
    // INSTANCE FUNCTIONS+
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public int GetMaxHealth()
    {
        return MAXHEALTH;
    }
    public int GetHealth()
    {
        return health;
    }
    public void Damage(int amount)
    {

        GameSounds.instance.GetPlayerHitSoundStart();
        StartCoroutine(CameraScript.instance.Shake(0.2f, 0.1f));
        if (health > 0) { health -= amount; }
        if (health < 0) { health = 0; }

        HealthBar.instance.ChangeSize(GetHealth());
    }
    public void addHealth(int amount)
    { 
        if(health <= MAXHEALTH)
        {
            health += amount;
            HealthBar.instance.ChangeSize(GetHealth());
        } 
    }
    public void addDamage(int amount)
    {
        damage += amount; 
    }
    public void addMaxHealth(int amount)
    {
        MAXHEALTH += amount;
        HealthBar.instance.addMaxValue(MAXHEALTH);
        addHealth(amount);
    }

    public void SetScore(string text)
    {
        Score = text;
    }
}

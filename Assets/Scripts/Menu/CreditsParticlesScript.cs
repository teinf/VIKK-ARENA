using UnityEngine;

public class CreditsParticlesScript : MonoBehaviour
{
    public GameObject particles;

    float timeToSpawn = 0;
    void Update()
    {
        if (timeToSpawn <= 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            timeToSpawn = 0.7f;
        }
        else
        {
            timeToSpawn -= Time.deltaTime;
        }  
    }
}

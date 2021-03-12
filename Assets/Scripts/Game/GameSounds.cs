using UnityEngine;

public class GameSounds : MonoBehaviour
{
    public static GameSounds instance;

    public AudioSource RelaxedSpaceMusic;
    public AudioSource EnemyDeathSound;
    public AudioSource EnemyHitSound;
    public AudioSource PlayerHitSound;
    public AudioSource ShieldHitSound;
    public AudioSource TakingCoinSound;
    public AudioSource GameOverSound;


    private void Awake()
    {
        instance = this;
    }


    public void GetRelaxedSpaceMusicStart(ulong time)
    {
        RelaxedSpaceMusic.PlayDelayed(time);
    }
    public void GetRelaxedSpaceMusicStop()
    {
        RelaxedSpaceMusic.Stop();
    }

    public void GetEnemyDeathSound()
    {
        EnemyDeathSound.Play(0);
    }

    public void GetEnemyHitSound(int health)
    {
        if(health > 0)
        {
            EnemyHitSound.Play(0);
        }
    }

    public void GetPlayerHitSoundStart()
    {
        PlayerHitSound.Play(0);
    }
    public void GetPlayerHitSoundStop()
    {
        PlayerHitSound.Stop();
    }

    public void GetShieldHitSound()
    {
        ShieldHitSound.Play(0);
    }

    public void GetTakingCoinSound()
    {
        TakingCoinSound.Play(0);
    }

    public void GetGameOverSound(ulong time)
    {
        GameOverSound.PlayDelayed(time);
    }
}

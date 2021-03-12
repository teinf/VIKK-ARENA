using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeModeMenuScript : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject changeModeCanvas;
    public GameObject background;

    public void EndlessMode()
    {
        WaveSystem.instance.gameMode = "Endless";
        ReModel();
        WaveSystem.instance.StartEndlessMode();
    }

    public void WavesMode()
    {
        WaveSystem.instance.gameMode = "Waves";
        ReModel();
        WaveSystem.instance.StartWaveMode();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ReModel()
    {
        background.SetActive(false);
        changeModeCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}

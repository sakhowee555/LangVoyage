using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // โหลดฉากเกมหลัก (ต้องมีชื่อ GameScene)
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings menu opened — you can add sliders or options later.");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit!");
        Application.Quit();
    }
}

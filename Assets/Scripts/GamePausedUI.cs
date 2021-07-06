using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GamePausedUI : MonoBehaviour
{
    public GameObject gamePausedUI;
    bool Paused = false;

    

    public void Resume()
    {
        Time.timeScale = 1.0f;
        gamePausedUI.SetActive(false);
    }

    public void restart()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Physics2D.IgnoreLayerCollision(10, 12, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        gamePausedUI.SetActive(false);
    }

    public void doExitGame()
    {
        Application.Quit();
    }
}

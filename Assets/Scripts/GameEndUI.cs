using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEndUI : MonoBehaviour
{
    public GameObject gameEndUI;

    // Start is called before the first frame update
    public void doExitGame()
    {
        Application.Quit();
    }

    public void playAgain()
    {
        Time.timeScale = 1.0f;
        gameEndUI.SetActive(false);
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Physics2D.IgnoreLayerCollision(10, 12, false);
        SceneManager.LoadScene(0);
    }
}

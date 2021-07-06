using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
    }

    public void retry()
    {
        Physics2D.IgnoreLayerCollision(10, 11, false);
        Physics2D.IgnoreLayerCollision(10, 12, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}

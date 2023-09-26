using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClick : MonoBehaviour
{
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

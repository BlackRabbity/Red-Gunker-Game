using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryClick : MonoBehaviour
{
    public void OnButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

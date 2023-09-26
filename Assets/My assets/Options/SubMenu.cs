using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenu : MonoBehaviour
{
    public GameObject subMenuObj;
    public Animator transition;
    public float transitionTime = 0;
    public bool isPause;
    void Start()
    {
        subMenuObj.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Resume();
            }else
            {
                PauseGame();
            }

        }
    }
    public void QuitToMenu()
    {
        isPause = false;
        Time.timeScale = 1f;
        LoadNextLevel();
    }
    public void Resume()
    {
        subMenuObj.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void PauseGame()
    {
        subMenuObj.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        //play animation
        transition.SetTrigger("Start");
        //wait for stop
        yield return new WaitForSeconds(transitionTime);
        //load the scene
        SceneManager.LoadScene(0);
    }
}

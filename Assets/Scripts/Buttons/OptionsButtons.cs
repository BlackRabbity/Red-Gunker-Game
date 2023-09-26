using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsButtons : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public void GoToSettingsMenu()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void GoBackMenu()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}

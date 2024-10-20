using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindow;
    public GameObject mainMenu;


    void Update()
    {
        if (settingsWindow.activeInHierarchy == false){


            if (Input.GetKey(ControlManager.GM.escape))
            {
                if (gameIsPaused)
                {
                    Resume();
                }
                else
                {

                        Paused();

                }
            }
        }
    }

    void Paused()
    {
        Controller.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        Controller.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
}

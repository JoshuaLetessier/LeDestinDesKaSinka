using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;
    public GameObject mainMenu;
    public GameObject optionMenu;

    public void StartGame() //bouton jouer
    {
        SceneManager.LoadScene(levelToLoad); //chargement de la scène
    }

    public void SettingsButton() //bouton setting
    {
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame() //quitter le jeux
    {
        Application.Quit();
    }
}

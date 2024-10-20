using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
public class InterractionOption : MonoBehaviour
{

    public GameObject settingOptionGraph;
    public GameObject settingOption;
    public GameObject settingOptionSon;
    public GameObject pauseMenu;

    public GameObject menu;

    public GameObject titre1;
    public GameObject titre2;
   /* private void Update() {
        if(Input.GetKey(GameManager.GM.escape))
        {
        pauseMenu.SetActive(true);
        settingOption.SetActive(false);
        settingOptionGraph.SetActive(false);
        settingOptionSon.SetActive(false);

        }

    }*/
    public void SettingOptionComToGraph()
    {
        settingOptionGraph.SetActive(true);
        settingOption.SetActive(false);
    }

    public void SettingOptionGraphToCom()
    {
        settingOption.SetActive(true);
        settingOptionGraph.SetActive(false);
    }

    public void SettingOptionGraphToSon()
    {
        settingOptionSon.SetActive(true);
        settingOptionGraph.SetActive(false);
    }

    public void SettingOptionSonToGraph()
    {
        settingOptionGraph.SetActive(true);
        settingOptionSon.SetActive(false);
    }


    public void SettingOptionComToSon()
    {
        settingOptionSon.SetActive(true);
        settingOption.SetActive(false);
    }

    public void SettingOptionSonToOption()
    {
        settingOption.SetActive(true);
        settingOptionSon.SetActive(false);
    }

    public void ReturnMenu()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Menu")
        {
            settingOption.SetActive(false);
            settingOptionGraph.SetActive(false);
            settingOptionSon.SetActive(false);
            menu.SetActive(true);
            titre2.SetActive(true);
            titre1.SetActive(false);
        }
        else 
        {
            pauseMenu.SetActive(true);
            settingOption.SetActive(false);
            settingOptionGraph.SetActive(false);
            settingOptionSon.SetActive(false);
        }
    }

    

    /*public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
        mainMenu.SetActive(true);
    }*/
}
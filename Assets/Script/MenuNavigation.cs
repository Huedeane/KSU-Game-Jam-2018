using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {

    public void OpenStartMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu", LoadSceneMode.Single);
    }

    public void quitUI()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OpenControlsMenu()
    {
        SceneManager.LoadScene("InstructionsMenu", LoadSceneMode.Single);
    }
}

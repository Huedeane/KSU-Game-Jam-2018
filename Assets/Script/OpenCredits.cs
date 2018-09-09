using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenCredits : MonoBehaviour {
    public void OpenCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu", LoadSceneMode.Single);
    }
}

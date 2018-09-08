using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuit : MonoBehaviour {
    public void quitUI() {
        Application.Quit();
        Debug.Log("Quit");
       }
}

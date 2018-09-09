using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenInstructions : MonoBehaviour {
     public void OpenInstructionsMenu()
     {
          SceneManager.LoadScene("InstructionsMenu", LoadSceneMode.Single);
     }
}

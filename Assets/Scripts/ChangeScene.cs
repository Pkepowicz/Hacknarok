using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; // The name of the scene to switch to
    
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("Game"); // Load the specified scene
    }
}
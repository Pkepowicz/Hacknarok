using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string  sceneName; // The name of the scene to switch to
    
    public void OnButtonClicked()
    {   if (sceneName == "Quit")
        {
            Debug.Log("QUIT");
            //Application.Quit();
        }
        else
        {
            LevelLoader.Instance.LoadNextLevel(sceneName);
            //SceneManager.LoadScene(sceneName);
        }
    }
}
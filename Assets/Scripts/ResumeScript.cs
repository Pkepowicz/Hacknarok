using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeScript : MonoBehaviour
{
    public GameObject pausePanel; // reference to the pause menu panel
    
    public void OnButtonClick()
    {
        // hide the pause menu panel
        pausePanel.SetActive(false);

        // resume the game or whatever actions you need to take
        Time.timeScale = 1f;
    }
}
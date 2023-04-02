using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
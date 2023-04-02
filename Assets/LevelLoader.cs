using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public static LevelLoader Instance;
    public float transitionTime = 0.75f;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void LoadNextLevel(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }

    private IEnumerator LoadLevel(string scene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}

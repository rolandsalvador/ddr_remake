using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (sceneName == "Title")
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void GameEasy()
    {
        SceneManager.LoadScene(3);
    }

    public void GameMedium()
    {
        SceneManager.LoadScene(4);
    }

    public void GameHard()
    {
        SceneManager.LoadScene(5);
    }

    public void HelpMenu()
    {
        SceneManager.LoadScene(6);
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //Debug.Log("Exited the game.");
        Application.Quit();

#endif
    }

}

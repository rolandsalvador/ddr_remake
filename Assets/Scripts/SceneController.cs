using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void HelpMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("Exited the game.");
        Application.Quit();

#endif
    }

}

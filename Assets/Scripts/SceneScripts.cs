using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScripts : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void PlayGame()
    {
        int finishedLevel = PlayerPrefs.GetInt("saveLevel",-1);
        if (finishedLevel >= -1)
        {
            LoadScene("Tutorial");
        }
        if (finishedLevel >= 0)
        {
            LoadScene("Level1");
        }
        if (finishedLevel >= 1)
        {
            LoadScene("Level2");
        }
        if (finishedLevel >= 2)
        {
            LoadScene("Level3");
        }
    }

    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{
    public GameObject pausePanel;
    public TMP_Text textInfo;
    public bool isPaused;
    public FpsMovement cam;

    private void Start()
    {
        Time.timeScale = 1;
        isPaused = false;
        cam.sensitivity = PlayerPrefs.GetFloat("sensitivity", 5.0f);
    }

    public void Pause()
    {
        if (isPaused == false)
        {
            /*Time.timeScale = 0;
            pausePanel.SetActive(true);
            sen.text = cam.sensitivity.ToString();
            textInfo.text = "Game is Paused";
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;*/
        }
        else
        {
            /*Time.timeScale = 1;
            pausePanel.SetActive(false);
            textInfo.text = "Press Esc to Pause";
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;*/
        }
    }


}

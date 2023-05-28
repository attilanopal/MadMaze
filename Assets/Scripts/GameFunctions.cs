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
    public TMP_Text sen;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
        cam.ChangeSens(PlayerPrefs.GetFloat("sensitivity", 5.0f));
        if (PlayerPrefs.GetFloat("sensitivity") == 0.0f) // wrote this since it would give me 0 instead of setted default value (5.0f)
        {
            PlayerPrefs.SetFloat("sensitivity", 5.0f);
            cam.ChangeSens(PlayerPrefs.GetFloat("sensitivity"));
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") == true)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            sen.text = "Ur Sens : " + cam.sensitivity.ToString();
            textInfo.text = "Game is Paused";
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            textInfo.text = "Press Esc to Pause";
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }
    }


}

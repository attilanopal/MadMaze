using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFunctions : MonoBehaviour
{

    // Per canvasan
    public GameObject pausePanel;
    public GameObject deathPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject GUICanvas;

    // Per karakteran
    public GameObject player;

    // Per Textan
    public TMP_Text textInfo;
    public TMP_Text healthInfo;
    public TMP_Text sen;

    // Per variabelan
    public bool isPaused;
    private bool isAlive;

    // Per scriptan
    public FpsMovement cam;
    public PlayerHealth playerHealth;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
        isAlive = true;
        healthInfo.text = "Lives : " + playerHealth.GetCurrentLive().ToString();
        cam.ChangeSens(PlayerPrefs.GetFloat("sensitivity", 5.0f));
        if (PlayerPrefs.GetFloat("sensitivity") == 0.0f) // wrote this since it would give me 0 instead of setted default value (5.0f)
        {
            PlayerPrefs.SetFloat("sensitivity", 5.0f);
            cam.ChangeSens(PlayerPrefs.GetFloat("sensitivity"));
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") == true && isAlive == true)
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
            Cursor.lockState = CursorLockMode.Confined;
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

    /**
     * Fungsi Catched akan dijalankan apabila ghost menyentuh player
     *  (OTW DIHAPUS KRN GAJADI DIPAKE)
     */
    public void Catched()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        isAlive = false;
    }

    public void Respawn()
    {
        player.transform.position = playerHealth.lastCheckpoint;
        CloseDeathPanel();
    }

    public void setIsAlive(bool bol)
    {
        isAlive = bol;
    }

    public void Win()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        GUICanvas.SetActive(false);
        winPanel.SetActive(true);
        sen.text = "Njirr jago amat!";
    }

    public void ShowDeathPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        isPaused = true;
        isAlive = false;
        GUICanvas.SetActive(false);
        deathPanel.SetActive(true);
    }
    public void CloseDeathPanel()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        isAlive = true;
        GUICanvas.SetActive(true);
        healthInfo.text = "Lives : " + playerHealth.GetCurrentLive().ToString();
        deathPanel.SetActive(false);
    }


    public void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        healthInfo.text = "Lives' : " + playerHealth.GetCurrentLive().ToString();
        isPaused = true;
        isAlive = false;
        GUICanvas.SetActive(false);
        gameOverPanel.SetActive(true);
    }
}

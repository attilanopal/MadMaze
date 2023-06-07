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

    // Per variabelan
    public bool isPaused;
    private bool isAlive;
    public int level;

    // Per scriptan
    public FpsMovement cam;
    public PlayerHealth playerHealth;
    public EnemyAI enemyAI;

    public AudioSource bimp;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (PlayerPrefs.GetInt("saveLevel") < 0)
        {
            PlayerPrefs.SetInt("saveLevel",0);
        }
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
            textInfo.enabled = false; 
            Cursor.lockState = CursorLockMode.Confined;
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            textInfo.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
        }
    }



    public void Respawn()
    {
        player.transform.position = playerHealth.lastCheckpoint;
        CloseDeathPanel();
        enemyAI.DelayEnemy(2f);
    }

    public void setIsAlive(bool bol)
    {
        isAlive = bol;
    }

    public void Win()
    {
        Time.timeScale = 0;
        isPaused = true;
        GUICanvas.SetActive(false);
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        int currentLevel = PlayerPrefs.GetInt("saveLevel", 0);
        if ( currentLevel < level)
        {
            currentLevel += 1;
            PlayerPrefs.SetInt("saveLevel", currentLevel);
            bimp.Play(); // Buat debugging
        }
    }

    public void ShowDeathPanel()
    {
        Time.timeScale = 0;
        isPaused = true;
        isAlive = false;
        GUICanvas.SetActive(false);
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
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
        isPaused = true;
        isAlive = false;
        GUICanvas.SetActive(false);
        gameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void CloseGameOverPanel()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
        isAlive = true;
        GUICanvas.SetActive(true);
        healthInfo.text = "Lives : " + playerHealth.GetCurrentLive().ToString();
        gameOverPanel.SetActive(false);
    }
}

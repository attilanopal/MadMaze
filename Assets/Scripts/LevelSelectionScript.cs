using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectionScript : MonoBehaviour
{

    public Button level1;
    public Button level2;
    public Button level3;
    
    

    public TMP_Text progress;

    public SceneScripts sceneManager;
    // Start is called before the first frame update

    void Start()
    {
        int finishedLevel = PlayerPrefs.GetInt("saveLevel", 0);


        
        progress.text = "Your current progress : " + (finishedLevel>0 ?(finishedLevel/3.0f*100) : 0) + "%";
        // Script untuk unlock level yang sudah terbuka
        if (finishedLevel >= 0)
        {
           level1.interactable = true;
        }
        else
        {
            level1.interactable = false;
        }
        if (finishedLevel >= 1)
        {
            level2.interactable = true;
        }
        else
        {
            level2.interactable = false;
        }
        if (finishedLevel >= 2)
        {
            level3.interactable = true;
        }
        else
        {
            level3.interactable = false;
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("saveLevel", -1);
        sceneManager.LoadScene("LevelSelection");
    }
}

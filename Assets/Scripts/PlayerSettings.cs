using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public TMP_InputField sen;
    public Toggle bgm;



    private void OnEnable()
    {
        sen.text = PlayerPrefs.GetFloat("sensitivity", 5.0f).ToString();
        bgm.isOn = (PlayerPrefs.GetInt("muteMusic") != 1);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("sensitivity",float.Parse(sen.text));
    }

    private void Update()
    {
        PlayerPrefs.SetInt("muteMusic", (bgm.isOn ? 0 : 1));
    }

    public void IncreaseSens()
    {
        float sensitivity = float.Parse(sen.text);
        sen.text = (sensitivity + 0.1f).ToString();
        sensitivity = float.Parse(sen.text);
    }

    public void DecreaseSens()
    {
        float sensitivity = float.Parse(sen.text);
        sen.text = (sensitivity > 0.0f) ? (sensitivity - 0.1f).ToString() : sensitivity.ToString();
        sensitivity = float.Parse(sen.text);
    }
}

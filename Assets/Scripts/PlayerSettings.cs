using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public TMP_InputField sen;
    

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("sensitivity",float.Parse(sen.text));
    }

    public void IncreaseSens()
    {
        float sensitivity = float.Parse(sen.text);
        sen.text = (sensitivity + 0.1f).ToString();
    }

    public void DecreaseSens()
    {
        float sensitivity = float.Parse(sen.text);
        sen.text = (sensitivity > 0.0f) ? (sensitivity - 0.1f).ToString() : sensitivity.ToString();
    }
}
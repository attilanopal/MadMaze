using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject introObject;
    public EnemyAI enemyAI;

    void Start()
    {
        enemyAI.DelayEnemy(5f);
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {

        yield return new WaitForSeconds(13f);
        introObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

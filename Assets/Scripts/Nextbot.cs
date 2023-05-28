using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nextbot : MonoBehaviour
{

    public GameObject player;
    public GameObject ghost;

    public float speed;

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        // playerPos.x *= 1.5f;
        transform.LookAt(playerPos);
        transform.Translate(0, 0, speed * Time.deltaTime);
        transform.Rotate(270, 0, -90);
    }


    void OnCollisionStay(Collision Obj)
    {
        if (Obj.gameObject.name == "Player")
        {
            speed = 0f;
           // ghost.transform.localScale = new Vector3(100f, 100f, 100f);
            
        }
        else
        {
        }
    }
}
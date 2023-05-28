using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        transform.Rotate(270, 0, -90);
    }

    void OnCollisionStay(Collision Obj)
    {
        if (Obj.gameObject.name == "Player")
        {
            enemy.speed = 0f;
            // ghost.transform.localScale = new Vector3(100f, 100f, 100f);

        }
        else
        {
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;
    // Start is called before the first frame update


    private bool isChasingPlayer = true;

    // Update is called once per frame
    void Update()
    {
        if (isChasingPlayer)
        {
            enemy.SetDestination(player.position);
        }
    }

    // Memulai pengejaran pemain
    public void StartChasingPlayer()
    {
        isChasingPlayer = true;
    }

    // Menghentikan pengejaran pemain
    public void StopChasingPlayer()
    {
        isChasingPlayer = false;
        enemy.ResetPath(); // Menghentikan pergerakan musuh
    }

    // Fungsi untuk respawn pada checkpoint terakhir
    public void DelayEnemy(float delay)
    {
        StartCoroutine(DelayedChase(delay));
    }

    // Penundaan sebelum musuh mulai mengejar pemain setelah respawn
    IEnumerator DelayedChase(float delayTime) // delayTime = Waktu penundaan sebelum musuh mulai mengejar pemain
    {
        yield return new WaitForSeconds(delayTime);
        StartChasingPlayer(); // Mulai pengejaran pemain setelah penundaan
    }
}


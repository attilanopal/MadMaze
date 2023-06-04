using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Jumlah maksimum nyawa
    private int currentLives; // Jumlah nyawa saat ini
    public Vector3 lastCheckpoint; // Posisi checkpoint terakhir

    private bool isDead = false; // Status pemain (hidup/mati)

    public GameObject deathPanel; // Panel "You are dead"
    public GameObject ghost; // gameobjek hantu
    public GameFunctions gameFun;

    public int GetCurrentLive()
    {
        return currentLives;
    }

    private void Start()
    {
        currentLives = maxLives;
        lastCheckpoint = transform.position;
    }


    /*** Fungsi kalau player collide dengan hantu
     * 
     * 
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost") && !isDead)
        {
            currentLives--;

            if (currentLives > 0)
            {
                Death();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void Death()
    {
        gameFun.ShowDeathPanel();
    }

    private void Respawn()
    {
        transform.position = lastCheckpoint;
        // Lakukan pengaturan ulang lainnya yang diperlukan

        // Menampilkan panel "You are dead"
        gameFun.ShowDeathPanel();
    }

    private void GameOver()
    {
        // Lakukan tindakan yang sesuai untuk kondisi game over, seperti menampilkan skor akhir, menyimpan skor tertinggi, dll.

        // Menampilkan panel "You are dead"
        gameFun.ShowDeathPanel();
    }

    /** Panel ini buat kalau user nyentuh hantu tapi belum mati "mati" (masi ada nyawa)
     * bakal nunjukin teks km sdh mati, terus button back to last checkpoint & back to menu
     */
    

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpoint = checkpointPosition;
    }
}


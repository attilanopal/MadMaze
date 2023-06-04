using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public AudioSource blip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.SetCheckpoint(transform.position);
            blip.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_controller : MonoBehaviour
{
    public Transform player; 
    public float maxDistance = 20f; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.position);

        float volume = 1f - (Distance / maxDistance);

        audioSource.volume = Mathf.Clamp01(volume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int requiredStrawberries = 5; 
    public GameObject player; 
    public AudioSource poof;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ItemCollection playerItemCollection = player.GetComponent<ItemCollection>();
            if (playerItemCollection.GetStrawberriesCount() >= requiredStrawberries)
            {
                poof.Play();
                Invoke("OpenDoor", 0.6f);
                playerItemCollection.DecreaseStrawberriesCount(requiredStrawberries);
            }
        }
    }

    private void OpenDoor()
    {
       gameObject.SetActive(false); 
    }
}
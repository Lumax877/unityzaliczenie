using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    [SerializeField] private int strawberries = 0;
    [SerializeField] private Text strawberriescount;
    [SerializeField] private AudioSource pickSound;

    public int GetStrawberriesCount()
    {
        return strawberries;
    }

    public void DecreaseStrawberriesCount(int number)
    {
        strawberries = strawberries - number;
        strawberriescount.text = "Strawberries in belly: " + strawberries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            strawberries++;
            strawberriescount.text = "Strawberries in belly: " + strawberries;
            Destroy(collision.gameObject);
            pickSound.Play();
        }
    }
}

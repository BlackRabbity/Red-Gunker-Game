using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePickups : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            playerInventory.CollectCoins();
            gameObject.SetActive(false);
        }
    }
}

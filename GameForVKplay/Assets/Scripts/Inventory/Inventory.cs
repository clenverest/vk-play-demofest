using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    private bool inventoryOn;

    void Start()
    {
        inventoryOn = false;
    }

    public void Chest()
    {
        if (!inventoryOn)
        {
            inventoryOn = true;
            inventory.SetActive(true);
        }
        else
        {
            inventoryOn = false;
            inventory.SetActive(false);
        }
    }
}

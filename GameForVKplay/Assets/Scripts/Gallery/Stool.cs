using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stool : MonoBehaviour
{
    
    public void DestroyObject()
    {
        Debug.Log("Нажал");
        gameObject.SetActive(false);
    }
}

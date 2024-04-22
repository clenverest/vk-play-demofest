using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private Transform posToGo;

    private bool playerDetected;
    private GameObject playerGo;

    // Start is called before the first frame update
    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected)
        {
            playerGo.transform.position = posToGo.position;
            playerDetected = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerGo = collision.gameObject;
            if (Vector2.Distance(playerGo.transform.position, transform.position) > 0.3f)
            {
                playerDetected = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetected = false;
        }
    }
}

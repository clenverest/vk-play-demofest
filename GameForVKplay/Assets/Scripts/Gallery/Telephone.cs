using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    [SerializeField] Dialogue dialogueWithoutNote;
    [SerializeField] Dialogue dialogueWithNote;
    [SerializeField] private GameObject player;
    private Inventory inventory;
    [SerializeField] private GameObject note;

    private void Start()
    {
        inventory = player.GetComponent<Inventory>();
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!inventory.Contains(note))
            {
                TriggerDialogue(dialogueWithoutNote);
            }
            else
            {
                inventory.DropItem(note);
                TriggerDialogue(dialogueWithNote);
            }
        }
    }
}

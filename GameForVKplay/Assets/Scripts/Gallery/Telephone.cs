using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : MonoBehaviour
{
    [SerializeField] Dialogue dialogueWithoutNote;
    [SerializeField] Dialogue dialogueWithNote;

    public void TriggerDialogue(Dialogue dialogue)
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (true)
            {
                TriggerDialogue(dialogueWithoutNote);
            }
            else
            {
                TriggerDialogue(dialogueWithNote);
            }
        }
    }
}

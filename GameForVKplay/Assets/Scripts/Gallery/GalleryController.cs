using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private GameObject player;
    private PlayerController playerController;
    [SerializeField] Dialogue dialogue;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.Freeze();
            animator.SetBool(Animator.StringToHash("Start"), true);
        }
    }

    public void ExitSearch()
    {
        animator.SetBool(Animator.StringToHash("Start"), false);
    }

    public void ActivateDialogue()
    {
        playerController.Unfreeze();
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);
    }
}

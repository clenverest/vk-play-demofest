using System.Collections;
using System.Collections.Generic;
using System.Security;
using TMPro;
using UnityEngine;

public class DialogueCutsceneManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject dialogue;
    Animator animatorDialogue;
    private bool isDialogueActive = false;

    private Queue<DialogueCutsceneNode> speeches;

    private void Start()
    {
        speeches = new Queue<DialogueCutsceneNode>();
        animatorDialogue = dialogue.GetComponent<Animator>();
    }

    public void StartDialogue(DialogueCutscene dialogue)
    {
        DialogueOn();
        speeches.Clear();
        animatorDialogue.SetBool(Animator.StringToHash("Start"), true);

        foreach (var speech in dialogue.Speeches())
        {
            speeches.Enqueue(speech);
        }
        DisplayNextSpeech();
    }

    public void DisplayNextSpeech()
    {
        if (speeches.Count == 0)
        {
            EndDialogue();
            return;
        }

        var dialogueNode = speeches.Dequeue();
        nameText.text = dialogueNode.Name();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(dialogueNode.Text()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void EndDialogue()
    {
        DialogueOff();
        animatorDialogue.SetBool(Animator.StringToHash("Start"), false);
    }

    public void DialogueOn()
    {
        isDialogueActive = true;
    }

    public void DialogueOff()
    {
        isDialogueActive = false;
    }

    public bool IsDialogueActive() => isDialogueActive;

    public bool IsSpeechesCountIsZero() => speeches.Count == 0;
}

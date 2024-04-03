using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject Dialogue;

    private Queue<string> speeches;

    private void Start()
    {
        speeches = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        speeches.Clear();

        foreach (var speech in dialogue.speeches)
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

        var nameAndSentence = speeches.Dequeue().Split(new[] { ':' }, 2);
        nameText.text = nameAndSentence[0];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(nameAndSentence[1]));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //TODO
    }
}

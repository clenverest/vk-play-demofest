using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SecondCutscene : MonoBehaviour
{
    private List<DialogueCutscene> speeches;
    private List<DialogueCutscene> choiceToAdree;
    private List<DialogueCutscene> choiceToForego;
    private List<DialogueCutscene> currentSpeeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private GameObject canvasWithScene;
    private Animator animatorFade;
    private Animator cutsceneAnimator;
    private Animator dialogueAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;
    private string triggerEnd;

    void Start()
    {
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        dialogueAnimator = dialogue.GetComponent<Animator>();
        animatorFade = canvasWithScene.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameFriend = "������";
        var nameLola = "����";

        speeches = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "��� ������ ������ � ����? ������� ������ ����� � ��������� ���� �� ��� ���?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "��, � ���� ��� ���� ����� ������� ������� ���� ���-�� ������ ���������� �� ���� ��� ������ ����������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "����� ��� ����� ������� ����, �� �� ���������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "�����, ��� �� ���� ����� �����, � �� ���� �� ������� ������ ����������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "������ ������, � ������ �������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "����?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "� ������, �� �����."),
                new (nameFriend, "������� �� ����? ��� �� ��� ���� � ����� �� ������, �������� ���� � ����.")
            })
        };

        choiceToAdree = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "� ���� �� ����� ��� ��� ��� �������� ����������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "�����, ������ ������� ���� ����, ������� ������ � 9:15, �� ������� �������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "���, ������ ������ � ����, ������, ��� �������� ����������� � ����� �����?")
            })
        };

        choiceToForego = new List<DialogueCutscene>
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "������, �� ����, ��� ������ ������ ���� �� ������ ����� ����� ��������, � �� ����� �� ���� ����, ��� �� ��������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "�� �������?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "��.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "������, �� ���� ������� �� ����� �������� ������ �������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "�� ������ � ������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "������ ���, ���������� � ����������, �������, �� ���� ���-��.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "� �� ��� ��?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameFriend, "��� ���������, ��� ������!")
            })
        };

        currentSpeeches = new(speeches);
    }

    private int i = 0;
    public void NextScene()
    {
        if(i == 0)
        {
            StartCoroutine(StartSpeech(currentSpeeches[i]));
            i++;
        }
        else if(i == speeches.Count && manager.IsDialogueActive())
        {
            dialogueAnimator.SetTrigger("SetChoice");
        }
        else if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < currentSpeeches.Count)
        {
            StartCoroutine(Next(currentSpeeches[i]));
            i++;
        }
        else if (i == currentSpeeches.Count && manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive())
        {
            StartCoroutine(ShowEnd());
        }
    }

    private IEnumerator StartSpeech(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }

    private IEnumerator ShowEnd()
    {
        yield return new WaitForSeconds(3f);
        animatorFade.SetTrigger(triggerEnd);
    }

    private IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        cutsceneAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }

    public void Agree()
    {
        triggerEnd = "FadeBad";
        currentSpeeches.AddRange(choiceToAdree);
        manager.EndDialogue();
        NextScene();
    }

    public void Forego()
    {
        triggerEnd = "FadeGood";
        currentSpeeches.AddRange(choiceToForego);
        manager.EndDialogue();
        NextScene();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{
    private DialogueCutscene[] speeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject canvas;
    private Animator cutsceneAnimator;
    private Animator canvasAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;


    void Start()
    {
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        canvasAnimator = canvas.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameDiller = "������";
        var nameLola = "����";

        speeches = new DialogueCutscene[]
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "������, �� ��� �� �������� ����� ������ �� ������, �� ����� ���, ���� ������ �������� ����� ���� ���� ������������ ������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "� ������� ��� ������ ��, ��� ��� ����� � ������?")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "����� � ���������.")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, "� ��� ��� ������� ����� �� ��������� ����? ���� ������ ������ ��������� ��������� �� ���������")
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, "���� �� ����� �������, ��� � ���, �� ���� �� ������� �� �������� - ����������� �� �������� �����, �� ���� �������")
            })
        };
    }

    public void StartScene()
    {
        manager.StartDialogue(speeches[i]);
        i++;
    }

    private int i = 0;
    public void NextScene()
    {
        if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < speeches.Length)
        {
            StartCoroutine(Next(speeches[i]));
            i++;
        }
        else if (!manager.IsDialogueActive() && i == speeches.Length)
        {
            canvasAnimator.SetTrigger("Next");
        }
    }


    IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.5f);
        cutsceneAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(1.5f);
        manager.StartDialogue(dialogue);
    }
}

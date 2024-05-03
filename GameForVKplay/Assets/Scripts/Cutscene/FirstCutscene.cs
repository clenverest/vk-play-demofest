using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{
    private DialogueCutscene[] speeches;
    [SerializeField] private GameObject cutscene;
    [SerializeField] private GameObject dialogue;
    Animator cutsceneAnimator;
    Animator dialogueAnimator;
    [SerializeField] private GameObject dialogueManager;
    private DialogueCutsceneManager manager;


    void Start()
    {
        cutsceneAnimator = cutscene.GetComponent<Animator>();
        dialogueAnimator = dialogue.GetComponent<Animator>();
        manager = dialogueManager.GetComponent<DialogueCutsceneManager>();
        var nameDiller = "Диллер";
        var nameLola = "Лола";
        var dillerFirstSentence = "Слушай, ты мне по большому счету ничего не должна, но видит Бог, твоя мамаша оставила после себя пару неоплаченных долгов.";
        var lolaFirstSentence = "И сколько там стоило то, что она смыла в унитаз?";
        var dillerSecondSentence = "Шесть с половиной.";
        var LolaSecondSentence = "И где мне столько найти за несколько дней? Даже сестра матери потратила последние на кремацию…";
        var dillerThirdSentence = "Меня не особо волнует, где и как, но если не найдешь до четверга - отправишься за мамочкой вслед, ты меня знаешь…";

        speeches = new DialogueCutscene[]
        {
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, dillerFirstSentence)
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, lolaFirstSentence)
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, dillerSecondSentence)
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameLola, LolaSecondSentence)
            }),
            new (new DialogueCutsceneNode[]
            {
                new (nameDiller, dillerThirdSentence)
            })
        };
    }

    bool isActivedScene = false;

    private void Update()
    {
        if (!isActivedScene)
        {
            isActivedScene = true;
            NextScene();
        }
    }

    private int i = 0;
    public void NextScene()
    {
        if (manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive() && i < speeches.Length)
        {
            StartCoroutine(Next(speeches[i]));
            i++;
        }
    }


    IEnumerator Next(DialogueCutscene dialogue)
    {
        yield return new WaitForSeconds(1.8f);
        cutsceneAnimator.SetTrigger("Next");
        yield return new WaitForSeconds(1.8f);
        manager.StartDialogue(dialogue);
    }
}

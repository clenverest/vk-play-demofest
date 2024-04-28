using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstCutscene : MonoBehaviour
{
    private DialogueCutscene dillerFirstSpeech;
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
        var dillerFirstSentence = "Бубум";
        var dillerSecondSentence = "Бaбам";
        dillerFirstSpeech = new DialogueCutscene(new DialogueCutsceneNode[]
        {
            new (nameDiller, dillerFirstSentence),
            new (nameDiller, dillerSecondSentence)
        });
    }

    bool isActivedDillerScene = false;

    // Update is called once per frame
    void Update()
    {
        if (!isActivedDillerScene)
        {
            isActivedDillerScene = true;
            StartCoroutine(DillerScene());
        }
    }

    IEnumerator DillerScene()
    {
        yield return new WaitForSeconds(3f);
        manager.StartDialogue(dillerFirstSpeech);
    }


    bool isActivedLolaScene = false;

    public void NextScene()
    {
        if(!isActivedLolaScene && manager.IsSpeechesCountIsZero() && !manager.IsDialogueActive())
        {
            isActivedLolaScene = true;
            StartCoroutine(LolaScene());
        }
    }

    IEnumerator LolaScene()
    {
        yield return new WaitForSeconds(3f);
        cutsceneAnimator.SetTrigger("Next");
    }
}

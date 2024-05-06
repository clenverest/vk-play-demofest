using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject enemy;

    private Animator canvasAnimator;
    private EnemyController enemyController;

    private void Start()
    {
        canvasAnimator = canvas.GetComponent<Animator> ();
        enemyController = enemy.GetComponent<EnemyController> ();
    }

    public void NextPage()
    {
        canvasAnimator.SetTrigger("Next");
    }

    public void StartGame()
    {
        canvasAnimator.SetTrigger("Next");
        enemyController.StartGame();
    }
}

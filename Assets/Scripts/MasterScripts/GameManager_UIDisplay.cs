using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_UIDisplay : MonoBehaviour
{

    public Sprite[] numberSprites;
    public Image numberUI;
    public Image gameOver;
    public Image restart;
    public Image success;

    private Player player;
    private GameManager_Master gameManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager_Master>();
        gameOver.enabled = false;
        restart.enabled = false;
        success.enabled = false;
    }

    private void Update()
    {
        if (gameManager.DisplayStageTimer)
        {
            numberUI.sprite = numberSprites[gameManager.StageTimer];
        }
    }
    public void DisplayGameOver()
    {
        if(!gameOver.enabled)
            gameOver.enabled = true;
    }
    public void DisplayRestart()
    {
        if (!restart.enabled)
            restart.enabled = true;
    }
    public void DisplayGameWin()
    {
        if (!success.enabled)
            success.enabled = true;
    }
}

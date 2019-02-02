using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Master : MonoBehaviour
{
    private GameManager_ToggleMenu gameManagerToggle;
    private GameManager_Spawn gameManagerSpawner;
    private GameManager_UIDisplay gameManagerUi;
    public AudioSource electronSound;
    public AudioSource gameOverSound;

    public Player player;

    public bool isNucelusActive;
    public bool isGameOver;
    public bool isMenuOn;

    // UI
    public int electronCounter;

    public int time;

    private bool displayStageTimer;
    [SerializeField]
    private int stageTimer;
    private int stageTimerCounter;

    [SerializeField]
    [Range(1, 3)]
    private int difficulty;
    private int timeDifficulty;

    public int StageTimer { get { return stageTimer; } }
    public bool DisplayStageTimer { get { return displayStageTimer; } }
    public int ElectronCounter { get { return electronCounter; } }
    public float Time { get { return time; } }
    public int Difficulty { get { return difficulty; } }

    public GameManager_Master()
    {
        electronCounter = 0;
    }
    void Start()
    {
        gameManagerSpawner = FindObjectOfType<GameManager_Spawn>().GetComponent<GameManager_Spawn>();
        gameManagerToggle = FindObjectOfType<GameManager_ToggleMenu>().GetComponent<GameManager_ToggleMenu>();
        gameManagerUi = FindObjectOfType<GameManager_UIDisplay>().GetComponent<GameManager_UIDisplay>();

        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        displayStageTimer = true;
        stageTimer = 14;
        stageTimerCounter = 0;

        difficulty = 1;
        timeDifficulty = 5 - difficulty;
    }
    public void FixedUpdate()
    {
        CheckCounterState();
        UpdateTimer();
        if (displayStageTimer)
            UpdateStageTimer();
        if (electronCounter >= 9)
        {
            displayStageTimer = false;
            GameOver();
        }
    }
    private void CheckCounterState()
    {
        if ((electronCounter < 9 && player.Spotted) || (electronCounter < 9 && stageTimer < 1 ))
        {
            GameOver();
        }
        if (electronCounter >= 9)
        {
            WinGame();
        }
    }
    void UpdateTimer()
    {
        time++;
    }
    void UpdateStageTimer()
    {
        stageTimerCounter++;

        if (stageTimerCounter > 60)
        {
            if (stageTimer >= 1)
                stageTimer--;
            else
            {
                displayStageTimer = false;
                stageTimer = 14;
            }
            stageTimerCounter = 0;
        }
        if (stageTimer > 14)
            stageTimer = 14;
    }
    public void IncrementDifficulty()
    {
        difficulty++;
    }
    public void GameOver()
    {
        if (!isGameOver)
        {
            gameOverSound.Play();
            displayStageTimer = false;
            isGameOver = true;
            player.IsDead = true;
            gameManagerUi.DisplayGameOver();
            gameManagerUi.DisplayRestart();
        }
    }
    public void WinGame()
    {
        displayStageTimer = false;
        isGameOver = true;
        gameManagerUi.DisplayGameWin();
        gameManagerUi.DisplayRestart();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Environment");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void AddElectron()
    {
        electronSound.Play();
        electronCounter++;
        stageTimer += timeDifficulty;
        gameManagerSpawner.Spawn();
    }
}

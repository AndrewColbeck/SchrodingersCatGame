using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleMenu : MonoBehaviour
{
    GameManager_Master gameManagerMaster;
    public Transform canvas;
    // Use this for initialization
    void Start()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForMenuToggleRequest();
    }
    void CheckForMenuToggleRequest()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }
    public void ExitGame()
    {
        gameManagerMaster.ExitGame();
    }
    public void ToggleMenu()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
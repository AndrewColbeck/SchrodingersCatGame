using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronMeter : MonoBehaviour {

    public Sprite[] electronMeter;

    public Image electronUI;

    private GameManager_Master gameManager;





	// Use this for initialization
	void Start () {
        
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager_Master>();
	}
	
	// Update is called once per frame
	void Update () {
        electronUI.sprite = electronMeter[gameManager.ElectronCounter];
	}
}

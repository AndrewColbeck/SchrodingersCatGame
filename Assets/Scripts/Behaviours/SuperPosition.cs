using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPosition : MonoBehaviour {


    private Rigidbody2D myRigidBody;
    private GameManager_Master gameManager_Master;
    private float horizontal;
    private int electronCount;
    
    [Range(-15, 15)]
	[SerializeField] private int movementSpeed;
    
    // Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
        gameManager_Master = GameObject.FindWithTag("GameController").GetComponent<GameManager_Master>();
        
        electronCount = gameManager_Master.ElectronCounter;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (gameManager_Master.ElectronCounter > electronCount){
            horizontal = Input.GetAxis("Horizontal");
            HandleMovement();
            electronCount++;
        }
	}
    
    // Handle Movement
    public void HandleMovement(){
        transform.Translate(movementSpeed, 0, 0);
        
    }
    
 
}

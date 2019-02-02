using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Electron : MonoBehaviour {

    private new string name = "Electron";
    private Rigidbody2D myRigidBody;
    private GameManager_Master gameManager_Master;
    public Nucleus nucleus;

    private float counter;
    public bool collected;

    public float movementSpeed;

    public string Name { get { return name; }}

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        counter = 0.1f;
        collected = false;
        movementSpeed = 50;

        // Nucleus reference
        GameObject nucleusRef = GameObject.FindWithTag("Nucleus");
        nucleus = nucleusRef.GetComponent<Nucleus>();

        // Game Manager reference
        GameObject gameManagerRef = GameObject.FindWithTag("GameController");
        gameManager_Master = gameManagerRef.GetComponent<GameManager_Master>();
	}

	// Update is called once per frame
	void Update () {
        HandleMovement();
        counter += 0.5f;
	}
    
    public void HandleMovement(){
        // Move to Nucelus
        if (collected)
            MoveTowardsNucleus();
        else
            myRigidBody.velocity = new Vector2(0, Mathf.Sin(counter));
    }

    public void MoveTowardsNucleus() {
        transform.position = Vector2.MoveTowards(transform.position, nucleus.transform.position, movementSpeed * Time.deltaTime);
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == ("Player"))
        {
            if (!collected)
            {
                gameManager_Master.AddElectron();
                collected = true;
            }
        }
	}
}

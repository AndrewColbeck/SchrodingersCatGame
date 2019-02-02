using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleus : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    private Animator myAnimator;
    
    private float counter;


	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // Set Random value for Animator, needs tweaking.
        myAnimator.SetFloat("randomizer", Random.value);

        HandleMovement();

        counter += 1f;
    }
    private void HandleMovement(){

    // Sinewave Float
    myRigidBody.velocity = new Vector2(0, Mathf.Sin(counter));

    // Rotate
    GetComponent<Rigidbody2D>().rotation += -0.6f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Electron"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private string _name;
    
    private Rigidbody2D myRigidBody;
    private Animator myAnimator;
    [SerializeField] private bool isDead;
    private GameManager_Master gameManager_Master;
    public AudioSource jumpPlay;
    
    
    
    [Range(1, 50)]
    public float jumpVelocity;
    public float jumpTime;
    public float jumpDelay = .5f;
    
    
    public bool isGrounded;
    public bool jumped;
    public bool gravity;

    public bool spotted;

    public float movementSpeed;

    private bool facingRight;

    public string Name { get { return _name; } }

    public bool Spotted { get { return spotted; } set { spotted = value; } }

    public bool IsDead { get { return isDead; } set { isDead = value; } }

	// Use this for initialization
	void Start () {
        _name = "Player";
        facingRight = true;
        isDead = false;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gameManager_Master = GameObject.FindWithTag("GameController").GetComponent<GameManager_Master>();
        jumpVelocity = 22;
        movementSpeed = 15;
	}

	// Update is called once per frame
	void FixedUpdate () {
        if (!isDead)
        {
            // Get Horizontal Axis, open Project/InputManager to see avail options:
            float horizontal = Input.GetAxis("Horizontal");
            HandleMovement(horizontal);
            Flip(horizontal);
        }
	}
    
    // Update is called once per frame
    void Update () {
        // Jump
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                myRigidBody.velocity = Vector2.up * jumpVelocity;
                myAnimator.SetTrigger("Jump");
                jumpPlay.Play(); 
            }

        }

        // Die
        if (isDead){
            gameManager_Master.GameOver();
            myAnimator.SetTrigger("Dead");
        }
    }
    public void HandleMovement(float horizontal) {
        myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);    // moves x-1, y=0;
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        if(isDead)
            myRigidBody.velocity = Vector2.zero;
    }
    private void Flip(float horizontal) {
        
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
	void OnCollisionEnter2D(Collision2D col) {
        
        if (col.gameObject.tag == "Electron")
        {
            gameManager_Master.AddElectron();
            
        }
    }
}

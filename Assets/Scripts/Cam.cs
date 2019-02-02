using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    [SerializeField]
    private float rotateSpeed;
    private bool rotateDown;

    [SerializeField]
    private float delayTime;
    private float delay;
    
    [SerializeField]
    private float viewingAngle;
    private float view;

    public GameObject endPointOne;
    public GameObject endPointTwo;
    public GameObject endPointThree;
    private Player player;
    
    
	// Use this for initialization
	void Start () {
        rotateDown = true;
        delay = delayTime;
        view = viewingAngle;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        RayCasting();
        Debug.DrawLine(transform.position, endPointOne.transform.position, Color.red);
        Debug.DrawLine(transform.position, endPointTwo.transform.position, Color.red);
        Debug.DrawLine(transform.position, endPointThree.transform.position, Color.red);
	}

	private void FixedUpdate()
	{
        Rotate();
	}

	void Rotate() {
        
        // Rotate LEFT:
        if (view >= 1 && rotateDown == true){
            transform.Rotate (Vector3.forward * rotateSpeed);
            view--;
        }
        
        // Rotate RIGHT:
        if (view <= viewingAngle && rotateDown == false){
            transform.Rotate (Vector3.back * rotateSpeed);
            view++;
        }
        
        // DELAY when at end of range, and Flip DIRECTION
        if (view <= 0 || view >= viewingAngle){
            delay -= 0.01f;
            
            if (delay <= 0){
                rotateDown = !rotateDown;
                delay = delayTime;
            }
        }
    }
    public void RayCasting()
    {
        RaycastHit2D hitOne = Physics2D.Raycast(transform.position, endPointOne.transform.position, 6000f);
        RaycastHit2D hitTwo = Physics2D.Raycast(transform.position, endPointTwo.transform.position, 6000f);
        RaycastHit2D hitThree = Physics2D.Raycast(transform.position, endPointThree.transform.position, 6000f);

        bool spotted = false;
        if (hitOne.collider != null)
        {
            if (hitOne.collider.tag == player.tag)
            {
                spotted = true;
            }
        }
        if (hitTwo.collider != null)
        {
            if (hitTwo.collider.tag == player.tag)
            {
                spotted = true;
            }
        }
        if (hitThree.collider != null)
        {
            if (hitThree.collider.tag == player.tag)
            {
                spotted = true;
            }
        }
        player.Spotted = spotted;
    }
}
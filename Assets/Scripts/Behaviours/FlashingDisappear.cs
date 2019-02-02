using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingDisappear : MonoBehaviour {

    public SpriteRenderer mySpriteRenderer;
    bool toggle = false;
    int counter;
    
    [SerializeField]
    private int numberOfFlashes;
    
    [SerializeField]
    private float delayBetweenFlashes;
    private float delay;
    
    
	// Use this for initialization
	void Start () {
        counter = numberOfFlashes;
        delay = delayBetweenFlashes;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate(){
        Flash(mySpriteRenderer);
	}
    
	private void Flash(SpriteRenderer spriteRen){

        //spriteRen.enabled = false;
        
        //if (counter >= 1){
        //    toggle = !toggle;
        //    spriteRen.enabled = toggle;
            
        //    counter--;
        //}
    }
    
            //    delay -= 0.01f;
            
            //if (delay <= 0){
            //    rotateDown = !rotateDown;
            //    delay = delayTime;
            //}
}

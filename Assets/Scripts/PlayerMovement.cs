using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // SerializeField keeps other scrips from editing these vars
    [SerializeField] private float speed; 
    [SerializeField] private bool isOpp;
    [SerializeField] private GameObject ball;

    private Rigidbody2D myBody;
    private Vector2 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(!Pause.isPaused){
            if(isOpp){
                AIControl();
            }
            else{
                playerControl();
            }
        // }
        
    }
    private void playerControl(){
        playerMove = new Vector2(0, Input.GetAxis("Vertical"));
    }
    private void AIControl(){
        // if ball is higher than paddle, move up
        if(ball.transform.position.y > transform.position.y + 0.5f){
            playerMove = new Vector2(0,1);
        }
        // if ball is too low, move down
        else if(ball.transform.position.y < transform.position.y - 0.5f){
            playerMove = new Vector2(0,-1);
        }
        // if in the right place, don't move
        else{
            playerMove = new Vector2(0,0);
        }
    }
    //physics not dependent on framerate
    private void FixedUpdate(){
        myBody.velocity = playerMove*speed;
    }
}

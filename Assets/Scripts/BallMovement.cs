using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed=10;
    [SerializeField] private float speedIncrease=0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text opponentScore;

    private int hitCounter;
    private Rigidbody2D myBody;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        // gives player 2 seconds before round starts
        Invoke("StartBall",2f);
    }
    private void FixedUpdate(){
        // makes sure magnitude is not higher than our set values
        myBody.velocity = Vector2.ClampMagnitude(myBody.velocity, initialSpeed+(speedIncrease*hitCounter));
    }
    // start of round
    private void StartBall(){
        myBody.velocity = new Vector2(1,0) * (initialSpeed+speedIncrease*hitCounter);
    }
    // end of round
    private void ResetBall(){
        myBody.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        hitCounter=0;
        Invoke("StartBall",2f);
    }
    // makes ball not just go straight always
    private void PlayerBounce(Transform myObject){
        hitCounter++;
        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;
        float xDir, yDir;

        // if ball is on the right, flip direction
        if(transform.position.x > 0){ xDir = -1; }
        else{ xDir = 1; }

        yDir = (ballPos.y-playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDir == 0){ yDir = 0.25f; }
        myBody.velocity = new Vector2(xDir, yDir) * (initialSpeed+ (speedIncrease*hitCounter) );
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "Opponent"){
            PlayerBounce(collision.transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        // player scores
        if(transform.position.x > 0){
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        // opponent scores
        else if(transform.position.x < 0){
            ResetBall();
            opponentScore.text = (int.Parse(opponentScore.text) + 1).ToString();
        }
    }
}

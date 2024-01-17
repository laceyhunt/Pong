using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed =3; // if you want it to go faster
    //public Animator animator;
    public Rigidbody2D playerBody;

    // Update is called once per frame
    void Update()
    {
        // for making player switch directions when moved
        // animator.SetFloat("hmove", Input.GetAxis("Horizontal"));

        // Unity -> Edit -> Project Settings decides which buttons control these
        float xVelocity = Input.GetAxis("Horizontal");
        float yVelocity = Input.GetAxis("Vertical");
        playerBody.velocity = new Vector2(xVelocity,yVelocity);

        //another way:
        // Vector3 move= new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0);
        // transform.position = transform.position + move*Time.deltaTime *speed;
    }
}

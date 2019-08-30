using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
skeleton ai consists of a wandering stage and a target stage once
the player is within detection range
*/

public class SkeletController : MonoBehaviour {

    public static System.Random rand = new System.Random();

    [Header("Basic Vars")]
    [Range(0f, 10f)]
    public float move_speed;

    private Animator anim;
    private Rigidbody2D body;
    private bool isMoving;
    private Vector2 prevMove;

    [Header("AI Vars")]
    private float moveDirect; //an angle measurement, in radians

    void Start() {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

        //decide which direction to move in
        moveDirect = (float)(SkeletController.rand.Next(0, 360) * (Math.PI / 180));
    } 

    void Update() {
        isMoving = false;
        body.velocity = new Vector2(0, 0);

        float input_x = (float)Math.Cos(moveDirect);
        float input_y = (float)Math.Sin(moveDirect);

        //Check to see if there is actually input
        if (move_speed > 0) {
        
            body.velocity = new Vector2(input_x * move_speed, input_y * move_speed);
            prevMove = new Vector2(input_x, input_y);
            isMoving = true;
        }

        //Update animator
        anim.SetFloat("MoveX", input_x);
        anim.SetFloat("MoveY", input_y);
    }
    
}

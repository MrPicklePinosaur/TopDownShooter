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
    private bool isMoving = false; //start idle
    private Vector2 prevMove;

    [Header("AI Vars")]
    private float moveDirect; //an angle measurement, in radians

    private float idleCounter = 0; //how long the skelet will stay idle
    private float moveCounter = 0; //how long the skelet will wander for

    void Start() {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        
    } 

    void Update() {

        //update counters
        if (idleCounter <= 0 && !isMoving) { // if no longer idle, decide new direction to walk in
            moveDirect = (float)(SkeletController.rand.Next(0, 360) * (Math.PI / 180));
            moveCounter = rand.Next(2, 4); //decide random wander time
            isMoving = true;
        }
        if (moveCounter <= 0 && isMoving) {
            idleCounter = rand.Next(1, 5);
            isMoving = false;
        }

        idleCounter -= Time.deltaTime;
        moveCounter -= Time.deltaTime; 

        body.velocity = new Vector2(0, 0);

        float input_x = (float)Math.Cos(moveDirect);
        float input_y = (float)Math.Sin(moveDirect);

        //Check to see if there is actually input
        if (isMoving) {
        
            body.velocity = new Vector2(input_x * move_speed, input_y * move_speed);
            prevMove = new Vector2(input_x, input_y);
            
        }

        //Update animator
        anim.SetFloat("MoveX", input_x);
        anim.SetFloat("MoveY", input_y);
        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("PrevX", prevMove.x);
        anim.SetFloat("PrevY", prevMove.y);
    }

    void OnCollisionEnter2D(Collision2D other) { //collision detection
        if (other.gameObject.name == "Player") { //check to see if enemy ran into player, deal damage
            Debug.Log("Collided with player", other.gameObject);
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealthComponent>().modHp(-30); //HARDCODED DAMAGE AMOUNT

        }
     }
    
}

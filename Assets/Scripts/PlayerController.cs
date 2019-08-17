using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static float INPUT_THRESHHOLD = 0.5f;

    public float move_speed;

    private Animator anim;
    private bool isMoving;
    private Vector2 prevMove;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        isMoving = false;

        //Check to see if there is actually input
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        if (Math.Abs(input_x) > INPUT_THRESHHOLD || Math.Abs(input_y) > INPUT_THRESHHOLD) {
            transform.Translate(new Vector3(input_x * move_speed * Time.deltaTime, input_y * move_speed * Time.deltaTime, 0f));
            prevMove = new Vector2(input_x,input_y);
            isMoving = true;
        }

        //Update animator
        anim.SetFloat("MoveX", input_x);
        anim.SetFloat("MoveY", input_y);
        anim.SetFloat("PrevMoveX", prevMove.x);
        anim.SetFloat("PrevMoveY", prevMove.y);
        anim.SetBool("isMoving", isMoving);


    }
}

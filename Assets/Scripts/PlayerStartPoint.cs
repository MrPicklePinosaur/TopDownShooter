using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController player;
    private CameraController cam;

    void Start() {
        //find player and camera
        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();

        //Set position of player and cam
        player.transform.position = transform.position;
    }

    void Update() {
        
    }
    
}

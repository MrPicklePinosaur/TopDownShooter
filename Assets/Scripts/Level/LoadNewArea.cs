using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string destination_scene;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {

        //if (string.Equals(collider.gameObject.name,"Player")) {
        if (collider.gameObject.name == "Player") {
            SceneManager.LoadScene(destination_scene);
        }

    }
}

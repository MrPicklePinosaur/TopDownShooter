using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//from https://unitycodemonkey.com/video.php?v=CTf0WjhfBx8
public class YRendering : MonoBehaviour {

    private Renderer r;
    [SerializeReference]
    private int baseSortingOrder = 5000;
    [SerializeReference]
    private int offset = 0;

    //timer stuff
    private float timer;
    private float totalTime = .1f; //only update sorting layer every 100 ms

    private void Awake() {
        r = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate() {
        //update timer
        timer -= Time.deltaTime;
        if (timer <= 0f) { 
            timer = 0f;
            r.sortingOrder = (int)(baseSortingOrder - transform.position.y - offset);
        }
        
    }
    
}

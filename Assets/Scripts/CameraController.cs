using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float camera_speed;
    public GameObject target;

    private Vector3 target_pos;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        target_pos = new Vector3(target.transform.position.x,target.transform.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position,target_pos,camera_speed * Time.deltaTime);
    }
}

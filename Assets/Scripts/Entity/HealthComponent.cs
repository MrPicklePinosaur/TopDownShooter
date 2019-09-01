using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthComponent : MonoBehaviour {

    [Range(10,100)]
    public float base_health;

    private float health;

    void Start() {
        health = base_health; //starts with max hp
    }

    void Update() { }

    public void modHp(float deltaHp) {
        health += deltaHp;

        if (health <= 0) { //trigger on death stuff
            onDeath();
        }
    }
    
    public virtual void onDeath() { } //override this method to modify what happens when entity dies
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent {

    [Range(1, 7)]
    public static float RESPAWN_TIME; //unsued so far, until i implement respawn/pause

    public override void onDeath() {
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(true);
    }
}

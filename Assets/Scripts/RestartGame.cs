using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour {

    void Update () {
        if (Input.GetKeyDown ("space")) {
            PlayGame ();
        }
        if (Input.GetKeyDown ("q")) {
            QuitGame ();
        }

        if (HealthContainer.health > 0) {
            gameObject.GetComponent<Text> ().text = "YOU WON!";

        } else {
            gameObject.GetComponent<Text> ().text = "YOU LOST!";
        }

    }
    void PlayGame () {
        SceneManager.LoadScene ("Game");
    }

    void QuitGame () {
        Application.Quit ();
    }
}
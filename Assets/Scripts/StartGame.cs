using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
    void Update () {
        if (Input.GetKeyDown ("space")) {
            PlayGame ();
        }
    }
    void PlayGame () {
        SceneManager.LoadScene ("Game");
    }

    void QuitGame () {
        Debug.Log ("I Quit");
        Application.Quit ();
    }
}
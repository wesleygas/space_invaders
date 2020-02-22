using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    void Start () {
        Debug.Log ("Start");
    }
    public void PlayGame () {
        Debug.Log ("Switch");
        // Debug.Log (SceneManager.GetActiveScene ().buildIndex + 1);
        // SceneManager.LoadScene (sceneNum);
    }
    public void QuitGame () {
        Debug.Log ("I Quit");
        Application.Quit ();
    }
}
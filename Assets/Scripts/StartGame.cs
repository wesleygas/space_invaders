
using UnityEngine;
using UnityEngine.SceneManagement;

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
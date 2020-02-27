using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTiro : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.005f;
    private AudioSource killAlien;
    public AudioClip alien;
    void Start () {
        killAlien = gameObject.GetComponent<AudioSource> ();
        killAlien.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        float dt = Time.deltaTime;
        gameObject.transform.position += Vector3.up * speed * dt;
    }

    void OnBecameInvisible () {
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D (Collider2D collision) {

        if (collision.tag == "Alien") {
            speed = 0;
            var newColor = new Color (0, 0, 0, 0);
            gameObject.GetComponent<Renderer> ().material.color = newColor;

            killAlien.PlayOneShot (alien);
            StartCoroutine (WaitForSound ());
            Destroy (collision.gameObject);
            GameObject.Find ("score").GetComponent<ScoreManager> ().AddScore (10);
        } else if (collision.tag == "Base") {
            collision.gameObject.SendMessage ("Hit");
            Destroy (gameObject);
        }
    }

    public IEnumerator WaitForSound () {
        yield return new WaitWhile (() => killAlien.isPlaying == true);
        Destroy (gameObject);
    }

}
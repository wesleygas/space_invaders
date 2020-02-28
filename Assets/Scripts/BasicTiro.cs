using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTiro : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.005f;
    private AudioSource killAlien;
    public AudioClip alien;
    public GameObject alienExplosion;
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
            Instantiate(alienExplosion, gameObject.transform.position, gameObject.transform.rotation);
            FindObjectOfType<AudioManager>().Play("alienDeath");
            Destroy (collision.gameObject);
            Destroy(gameObject);
            GameObject.Find ("score").GetComponent<ScoreManager> ().AddScore(10*(4-HealthContainer.health));
        } else if (collision.tag == "Base") {
            collision.gameObject.SendMessage ("Hit");
            Instantiate(alienExplosion, gameObject.transform.position, gameObject.transform.rotation);
            Destroy (gameObject);
            
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class naviScript : MonoBehaviour {
    public float speed = 0.005f;
    private float bound = 9;
    public int health = 3;
    public float wait = 0.3f;
    private float basic_shot_timer = 0;

    public AudioSource audioData;
    public AudioSource explosion;

    public GameObject ball;
    public GameObject spaceships;

    // Start is called before the first frame update
    void Start () {
        HealthContainer.health = 3;
        // audioData = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update () {
        float dh = Input.GetAxis ("Horizontal");
        float dt = Time.deltaTime;

        if (gameObject != null) {

            if ((gameObject.transform.position.x > -bound || dh > 0) && (gameObject.transform.position.x < +bound || dh < 0)) {
                gameObject.transform.position += Vector3.right * (dh / dt) * speed;
            }

            basic_shot_timer += dt;
            if (basic_shot_timer > wait && Input.GetKeyDown ("space")) {
                basic_shot_timer = 0;
                audioData.Play ();
                Instantiate (ball, gameObject.transform.position, Quaternion.identity);
            }
        }

        Health ();

    }

    void Health () {

        if (spaceships == null || health == 0) {
            HealthContainer.health = 0;
        }
        int children = spaceships.transform.childCount;
        for (int i = 0; i < children; i++) {
            if (i < health) {
                spaceships.transform.GetChild (i).gameObject.SetActive (true);
            } else {
                spaceships.transform.GetChild (i).gameObject.SetActive (false);
            }
        }
    }

    public void Hit () {
        explosion.Play ();
        if (health > 0) {
            health -= 1;
            HealthContainer.health -= 1;
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.tag == "Alien") {
            Hit ();
        }
    }
}
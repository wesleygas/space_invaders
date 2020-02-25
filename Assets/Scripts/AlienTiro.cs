using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTiro : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 0.005f;
    public float ang_speed = 0.5f;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        float dt = Time.deltaTime;
        gameObject.transform.position -= Vector3.up * speed * dt;
        gameObject.transform.Rotate (Vector3.forward * ang_speed * dt * Random.value);
    }

    void OnBecameInvisible () {
        Destroy (gameObject);
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.tag == "Player" || collision.tag == "Base") {
            collision.gameObject.SendMessage ("Hit");
            // Destroy (collision.gameObject);
            Destroy (gameObject);
        }
    }
}
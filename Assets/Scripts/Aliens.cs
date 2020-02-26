﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Aliens : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 0.005f;
    public float wait = 0.4f;
    public float down = 0.4f;

    private bool invert = false;
    public float shooting_prob = 0.0007f;

    public GameObject AlienTiro;

    void Start () {
        // InvokeRepeating("AliensAttack", 0, wait);
    }

    // Update is called once per frame
    void Update () {
        float dt = Time.deltaTime;
        int count = 0;
        if (invert) {
            speed = -speed;
            gameObject.transform.position += Vector3.down * down * dt;
            invert = false;
            return;
        } else {
            gameObject.transform.position += Vector3.right * speed * dt;
        }

        foreach (Transform alien in gameObject.transform) {
            if (alien.position.x < -9 || alien.position.x > 9) {
                invert = true;
            }
            if (Random.value < shooting_prob && alien.gameObject.activeSelf) {
                Instantiate (AlienTiro, alien.position, alien.rotation);
            }

            if (alien.gameObject.activeSelf) {
                count++;
            }

        }

        if (count == 0) {
            HealthContainer.health = GameObject.Find ("Spaceship").GetComponent<naviScript> ().health;
            SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
        }

    }

    public void Hit () {
        gameObject.SetActive (false);
    }

}
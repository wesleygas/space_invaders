using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 0.005f;
    public float alone_rage = 10;
    public float wait = 0.4f;
    public float down = 0.4f;
    public float level = 1;
    float rage_bonus = 1;

    int last_count = 0;

    private bool invert = false;
    public float shooting_prob = 0.0189f;

    public GameObject AlienTiro;
    public GameObject cowBeam;
    public GameObject common_alien;

    void Start () {
        ReSpawnAliens ("common");
        last_count = gameObject.transform.childCount +1;
    }

    // Update is called once per frame
    void Update () {
        int count = gameObject.transform.childCount + 1;
        float prob = shooting_prob / count;
        if (count != last_count) {
            last_count = count;
            rage_bonus = alone_rage / count;
            float newPitch;
            if (count > 10) newPitch = 1f;

            else newPitch = ((float)count - 1) * (-.3f) / (9) + 1.5f;
            FindObjectOfType<AudioManager>().SetPitch("background", newPitch);
        }

        float dt = Time.deltaTime;
        if (invert) {
            speed = -speed;
            gameObject.transform.position += Vector3.down * down * dt * level * rage_bonus;
            invert = false;
            return;
        } else {
            gameObject.transform.position += Vector3.right * speed * dt * level * rage_bonus;
        }

        foreach (Transform alien in gameObject.transform) {
            if (alien.position.x < -9 || alien.position.x > 9) {
                invert = true;
            }
            if (Random.value < prob * (float) level) {
                Instantiate (AlienTiro, alien.position, alien.rotation);
                Instantiate(cowBeam, alien.position - new Vector3(0,1f), Quaternion.Euler(0f,0f,180f));
            }

        }
    }

    public void ReSpawnAliens (string type) {
        foreach (Transform alien in gameObject.transform) {
            GameObject.Destroy (alien.gameObject);
        }
        if (type == "common") {
            for (float x = -8.0f; x <= 8.0f; x += 2.0f) // 2.0f
            {
                for (float y = 0.5f; y <= 3.5f; y += 1.5f) //1.5f
                {
                    Vector3 pos = new Vector3 (x, y);
                    var new_alien = Instantiate (common_alien, pos, Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    public void ChangeLevel (int level) {
        ReSpawnAliens ("common");
        switch (level) {
            case (1):
                {
                    this.level = (float) level;
                    var newColor = new Color32 (255, 255, 255, 255);
                    ChangeColor (newColor);
                    break;
                }
            case (2):
                {
                    this.level = (float) level * 1.5f;
                    var newColor = new Color32 (255, 236, 47, 34);
                    ChangeColor (newColor);
                    break;
                }
        }
    }

    void ChangeColor (UnityEngine.Color color) {
        foreach (Transform alien in gameObject.transform) {
            alien.gameObject.GetComponent<SpriteRenderer> ().color = color;
        }
    }

}
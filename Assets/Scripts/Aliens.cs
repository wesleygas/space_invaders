using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour {
    // Start is called before the first frame update

    public float speed = 0.005f;
    public float alone_rage = 10;
    public float wait = 0.4f;
    public float down = 0.4f;
    float level = 1;
    float rage_bonus = 1;

    private bool invert = false;
    public float shooting_prob = 0.0007f;

    public GameObject AlienTiro;

    public GameObject common_alien;

    void Start () {
        ReSpawnAliens("common");
    }

    // Update is called once per frame
    void Update () {

        
        if (gameObject.transform.childCount > 0)
        {
            rage_bonus = alone_rage / gameObject.transform.childCount;
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
            if (Random.value < shooting_prob*(float)level) {
                Instantiate (AlienTiro, alien.position, alien.rotation);
            }

        }
    }


    public void ReSpawnAliens(string type)
    {
        foreach (Transform alien in gameObject.transform)
        {
            GameObject.Destroy(alien.gameObject);
        }
        if (type == "common")
        {
            for (float x = -8.0f; x <= 8.0f; x += 2.0f) // 2.0f
            {
                for (float y = 0.5f; y <= 3.5f; y += 1.5f) //1.5f
                {
                    Vector3 pos = new Vector3(x, y);
                    var new_alien = Instantiate(common_alien, pos, Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    public void ChangeLevel(int level)
    {
        ReSpawnAliens("common");
        switch (level)
        {
            case (1):
                {
                    this.level = (float)level;
                    var newColor = new Color32(255,255, 255, 255);
                    ChangeColor(newColor);
                    break;
                }
            case (2):
                {
                    this.level = (float)level*1.5f;
                    var newColor = new Color32(255, 236, 47, 34);
                    ChangeColor(newColor);
                    break;
                }
        }
    }

    void ChangeColor(UnityEngine.Color color)
    {
        foreach (Transform alien in gameObject.transform)
        {
            alien.gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTiro : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.005f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        gameObject.transform.position += Vector3.up*speed*dt;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Alien"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}

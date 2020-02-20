using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naviScript : MonoBehaviour
{
    public float speed = 0.005f;
    private float bound = 9;
    public GameObject BasicTiro;
    public float wait = 0.3f;
    private float basic_shot_timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dh = Input.GetAxis("Horizontal");
        float dt = Time.deltaTime;
        if(( gameObject.transform.position.x > - bound || dh > 0) && (gameObject.transform.position.x < +bound || dh < 0))
        {
            gameObject.transform.position += Vector3.right*(dh/dt)*speed;
        }

        basic_shot_timer += dt;
        if (basic_shot_timer > wait && Input.GetButton("Fire1"))
        {
            basic_shot_timer = 0;
            Instantiate(BasicTiro, gameObject.transform.position, Quaternion.identity);
        }
        
    }
}

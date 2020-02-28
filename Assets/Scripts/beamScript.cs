using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamScript : MonoBehaviour
{
    // Start is called before the first frame update
    int count = 0;
    public int maxCount = 40;
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count > maxCount)
        {
            Destroy(gameObject);
        }
    }
}

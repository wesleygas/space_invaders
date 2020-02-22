using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int health = 3;
    public GameObject spaceships;

    void Start () { }
    // Update is called once per frame
    void Update () {

        int children = spaceships.transform.childCount;
        for (int i = 0; i < children; i++) {
            if (i < health) {
                spaceships.transform.GetChild (i).gameObject.SetActive (true);
            } else {
                spaceships.transform.GetChild (i).gameObject.SetActive (false);
            }
        }

    }
}
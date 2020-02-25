using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour {
    // Start is called before the first frame update
    private int strength;
    void Start () {
        strength = 3;
    }

    public void Hit () {
        var color = gameObject.GetComponent<Renderer> ().material.color;
        var newColor = new Color (color.r, color.g, color.b, color.a * 0.5f);
        gameObject.GetComponent<Renderer> ().material.color = newColor;
        // Debug.Log (color.a / 2);
        // color.a *= 0.5f;
        strength -= 1;
        if (strength <= 0) {
            gameObject.SetActive (false);
        }
        // gameObject.SetActive (false);
    }
}
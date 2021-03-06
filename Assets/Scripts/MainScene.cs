﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{

    public GameObject aliens;
    public GameObject life;

    int level = 1;

    private void Start()
    {
        gameObject.GetComponent<Text>().text = "";
    }

    void Update()
    {
        
        if (HealthContainer.health == 0)
        {
            EndScene();
        }
        else if (aliens.transform.childCount == 0)
        {
            switch(level){
                case (1):
                    {
                        gameObject.GetComponent<Text>().text = "Level 2"; //Texto pra aparecer na hora
                        ResetScene(2);
                        break;
                    }
                case (2):
                    {

                        EndScene();
                        break;
                    }
            }     
        }
    }

    void ResetScene(int level)
    {
        if (Input.anyKey)
        {
            this.level = level;
            aliens.GetComponent<Aliens>().ChangeLevel(level);
            gameObject.GetComponent<Text>().text = "";
            
        }
    }

    void EndScene()
    {
        SceneManager.LoadScene("Result");
    }
    

}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetManager : MonoBehaviour {

    public GameObject leftTarget;
    public GameObject rightTarget;
    public int lcurrentHealth = 5;
    public int rcurrentHealth = 5;
    // Use this for initialization

    // Update is called once per frame
    Vector3[,] parameters = new Vector3[,] { { new Vector3(1, 3, 5), new Vector3(3, 9, 5), new Vector3(3, 8, 9), new Vector3(1, 8, 10) } };
    public void Damage(int clickTimes)
    {
       
        lcurrentHealth -= clickTimes;
        rcurrentHealth -= clickTimes;
        int i = 3;

        //Check if health has fallen below zero
        if (lcurrentHealth <= 0 && rcurrentHealth <= 0)
        {
            i -= i;
            Debug.Log(i);
            //if health has fallen below zero, change its position and size 
            // gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            leftTarget.transform.localScale = new Vector3(4, 6, 7);
        }
        Debug.Log(parameters);

        // if user clicks on the target
        // destroy the target
        // spawn a target with random distance and size
    }

}
using UnityEngine;
using System;
using System.Collections;

public class ShootableTargetRight : MonoBehaviour {

    //The box's current health point total
    public float startTimeR;
    int rightHealth = 2;
    int i = 0;
    float[] scaleArray = new float[9] { 0.45f, 0.6f, 0.3f, 0.6f, 0.45f, 0.3f, 0.3f, 0.6f, 0.45f };
    int[] positionArray = new int[9] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
    float lastSelect;
    float durationTime;
    ArrayList selectTime = new ArrayList();

    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rightHealth -= damageAmount;
        //    startTimeR = Time.time;
        //    durationTime = Time.time - ShootableTargetLeft.startTimeL;
        //    selectTime.Add(durationTime);
        //    Debug.Log("this selecting takes" + durationTime);
        //}
        rightHealth -= damageAmount;
        Debug.Log("after key down" + rightHealth);
        Vector3[,] parameters = new Vector3[,] { { new Vector3(1, 3, 5), new Vector3(3, 9, 5), new Vector3(3, 8, 9), new Vector3(1, 8, 10) } };
        //Check if health has fallen to zero
       
        if (rightHealth == 0 &&i <= 8)
        {
            Debug.Log("recursive" + rightHealth);
            i +=1;
            //if health has fallen below zero, change its position and size 
            gameObject.transform.position = new Vector3(positionArray[i], gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(scaleArray[i], scaleArray[i], scaleArray[i]);
            rightHealth = 2;
        }
    }
}

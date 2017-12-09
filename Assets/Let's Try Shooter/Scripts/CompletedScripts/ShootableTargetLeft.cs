using UnityEngine;
using System.Collections;
using System;

public class ShootableTargetLeft : MonoBehaviour {

	//The box's current health point total
	int leftHealth = 5;
    int i = 0;
    float[] scaleArray = new float[9] { 0.6f, 0.4f, 0.2f, 0.6f, 0.4f, 0.2f, 0.6f, 0.4f, 0.2f };
    int[] positionArray = new int[9] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };

    public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leftHealth -= damageAmount;
        }
               
        Debug.Log("after key down" + leftHealth);
        Vector3[,] parameters = new Vector3[,] { { new Vector3(1, 3, 5), new Vector3(3, 9, 5), new Vector3(3, 8, 9), new Vector3(1, 8, 10) } };
        //Check if health has fallen to zero
       
        if (leftHealth == 0 && i<=8) 
		{
            Debug.Log("recursive" + leftHealth);
            i += 1;
            //if health has fallen beklow zero, change its position and size 
            gameObject.transform.position = new Vector3(-positionArray[i], gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.localScale = new Vector3(scaleArray[i], scaleArray[i], scaleArray[i]);
            leftHealth = 5;
        }
	}
}

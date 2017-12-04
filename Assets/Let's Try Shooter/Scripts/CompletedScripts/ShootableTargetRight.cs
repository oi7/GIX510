﻿using UnityEngine;
using System.Collections;

public class ShootableTargetRight : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 1;

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
            //if health has fallen below zero, change its position and size 
            gameObject.SetActive(false);
        }
	}
}

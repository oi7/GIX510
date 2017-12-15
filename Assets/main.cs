using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
    FoveInterface f;
    public GameObject objectL;
    public GameObject objectR;
    public float startTimeL;
    public float startTimeR;
    public float hitForce = 100f;
    float durationTime;
    int countTime = 1;
    ArrayList successRate = new ArrayList();
    ArrayList selectionTime = new ArrayList();

    // Use this for initialization
    void Start () {
      f = GetComponent<FoveInterface>();
    }
		// Update is called once per frame
	void Update () {
        //Using main camera or the information of main as here is FoveInterface
        //Vector3 headPosition = UnityEngine.FoveInterfaceBase.GetHMDPosition(); 
        //Quaternion headRotation = UnityEngine.FoveInterfaceBase.GetHMDRotation();

        RaycastHit hit;
        Ray ray = new Ray(f.transform.position, f.transform.forward);
        bool isHit = Physics.Raycast(ray, out hit, Mathf.Infinity);
       
     //   f.EyeRays rays = FoveInterface.GetEyeRays();

        // TODO: calculate the convergence point in FoveInterface

        // Just hack in to use the left eye for now...
     

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootableTargetLeft healthLeft = objectL.GetComponent<ShootableTargetLeft>();
            ShootableTargetRight healthRight = objectR.GetComponent<ShootableTargetRight>();
            if (f.transform.forward.x < 0)
            {
                startTimeL = Time.time;
                healthLeft.Damage(countTime);
                if (isHit)
                {
                    successRate.Add(1);
                    Debug.Log("LEFT Hit successfully");
                }
                else
                {
                    successRate.Add(0);
                    Debug.Log("Left failed");
                }
            }
            if (f.transform.forward.x > 0)
            {
                
                healthRight.Damage(countTime);
                startTimeR = Time.time;
                if (isHit)
                {
                    Debug.Log("Right Hit successfully");
                    successRate.Add(1);
                }
                else
                {
                    successRate.Add(0);
                    Debug.Log("Right failed");
                }
            }
          
            durationTime = System.Math.Abs(startTimeL - startTimeR);
            selectionTime.Add(durationTime);
            Debug.Log(startTimeL + "-"+ startTimeR + "=" + durationTime);

           
              

       
           
        }

    

        //if (isHit)
        //{
        //    ShootableTargetLeft healthLeft = hit.collider.GetComponent<ShootableTargetLeft>();
        //    ShootableTargetRight healthRight = hit.collider.GetComponent<ShootableTargetRight>();


        //    // If there was a health script attached for left target
        //    if (healthLeft != null && Input.GetKeyDown(KeyCode.Space))
        //    {
        //        // Call the damage function of that script, passing in our gunDamage variable
        //        startTimeL = Time.time;
        //        healthLeft.Damage(countTime);
        //        Debug.Log(f.transform.forward.ToString());
        //    }

        //    // If there was a health script attached for right target
        //    if (healthRight != null && Input.GetKeyDown(KeyCode.Space))
        //    {
        //        // Call the damage function of that script, passing in our gunDamage variable
        //        startTimeR = Time.time;
        //        healthRight.Damage(countTime);
        //        Debug.Log(f.transform.forward.ToString());
        //    }
        //    durationTime = System.Math.Abs(startTimeL - startTimeR);
        //    selectionTime.Add(durationTime);
        //    Debug.Log(startTimeL + "-"+ startTimeR + "=" + durationTime);
        //    if (hit.rigidbody != null)
        //    {
        //        // Add force to the rigidbody we hit, in the direction from which it was hit
        //        hit.rigidbody.AddForce(-hit.normal * hitForce);
        //    }

        //}


    }

        }
      
  
   
    



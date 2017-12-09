using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
    FoveInterface f;
    int countTime = 1;

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
    
        if (isHit)
        {
            ShootableTargetLeft healthLeft = hit.collider.GetComponent<ShootableTargetLeft>();
            ShootableTargetRight healthRight = hit.collider.GetComponent<ShootableTargetRight>();


            // If there was a health script attached for left target
            if (healthLeft != null)
            {
                // Call the damage function of that script, passing in our gunDamage variable
                healthLeft.Damage(countTime);
            }

            // If there was a health script attached for right target
            if (healthRight != null)
            {
                // Call the damage function of that script, passing in our gunDamage variable
                healthRight.Damage(countTime);
            }
         
            
    }
}

        }
      
  
   
    



using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour {
    FoveInterface f;

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
            if (hit.collider.tag == "desk") 
            {
                print("This is a desk");
            }
            else if(hit.collider.tag == "cube")
            {
                print("This is a cube");
            }
        }
      
   

       //if (Physics.Raycast(
       //         headAngles,
       //         headRotation,
       //         out hitInfo,
       //         20.0f,
       //         Physics.DefaultRaycastLayers))
       // {
           
       //     // If the Raycast has succeeded and hit a hologram
       //     // hitInfo's point represents the position being gazed at
       //     // hitInfo's collider GameObject represents the hologram being gazed at

       // }
    }
    


    Vector2 GetAngles(Vector3 direction, Vector3 forward, Vector3 up)
    {
        Vector3 directionOnPlane = Vector3.ProjectOnPlane(direction, forward);
        Vector3 upOnPlane = Vector3.ProjectOnPlane(up, forward);
        // angle between direct and forward
        float theta = Vector3.Angle(direction, forward);
        // angle on visual plane
        float phi = Vector3.Angle(directionOnPlane, upOnPlane);
        float sign = Mathf.Sign(Vector3.Dot(Vector3.Cross(directionOnPlane, upOnPlane), forward));
        phi = -(phi * sign - 90);
        return new Vector2(theta, phi);
    }
}

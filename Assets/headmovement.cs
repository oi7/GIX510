using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headmovement : MonoBehaviour {
    public FoveInterface f;
    // Use this for initialization
    void Start()
    {
        Debug.Log(f.transform);
    }

    // Latepdate ensures that the object doesn't lag behind the user's head motion
    void Update()
    {
       // FoveInterface.EyeRays rays = FoveInterface.GetEyeRays();

        // TODO: calculate the convergence point in FoveInterface

        // Just hack in to use the right eye for now...

        RaycastHit hit;
        Ray ray = new Ray(f.transform.position, f.transform.forward);
        bool isHit = Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (isHit) // Vector3 is non-nullable; comparing to null is always false
        {
            Debug.Log("hitsuccefully");
            transform.position = hit.point;
        }
        else
        {
            transform.position = ray.GetPoint(3.0f);
        }
    }
}

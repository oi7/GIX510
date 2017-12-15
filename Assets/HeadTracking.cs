using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTracking : MonoBehaviour
{
    public FoveInterface f;
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(f.transform.position, f.transform.forward);
        bool isHit = Physics.Raycast(ray, out hit, Mathf.Infinity);

        if (hit.point != Vector3.zero) // Vector3 is non-nullable; comparing to null is always false
        {
            transform.position = hit.point;
        }
        else
        {
            transform.position = ray.GetPoint(3.0f);
        }
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
            Debug.Log(startTimeL + "-" + startTimeR + "=" + durationTime);

        }

    }
}
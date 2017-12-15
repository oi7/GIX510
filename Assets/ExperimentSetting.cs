using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentSetting : MonoBehaviour {
    public GameObject CursorLeft;
    public GameObject CursorRight;
    public GameObject CursorCenter;
    
	// Use this for initialization
	void Start () {
        CursorLeft.SetActive(false);
        CursorRight.SetActive(false);
        CursorCenter.SetActive(true);
     
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.F1))
        {
            CursorCenter.SetActive(false);
            CursorLeft.SetActive(true);
            CursorRight.SetActive(true);
        }

    }
}

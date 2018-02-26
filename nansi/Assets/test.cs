using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, (float)9, 0), ForceMode.Force);
        print(Physics.gravity.magnitude);

    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, (float)9, 0), ForceMode.Force);
    }
}

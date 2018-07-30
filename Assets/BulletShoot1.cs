using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot1 : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	void Update () {
        GetComponent<Rigidbody>().velocity = transform.forward * 6;
        Destroy(this, 2.0f);
    }
}

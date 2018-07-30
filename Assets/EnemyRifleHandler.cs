using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRifleHandler : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPoint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void FireWeapon()
    {
        Instantiate(
            bullet,
            bulletSpawnPoint.position,
            bulletSpawnPoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(0f, 0f, player.transform.position.z) + offset;
    }
}

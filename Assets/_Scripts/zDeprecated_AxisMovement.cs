using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMovement : MonoBehaviour 
{
	public float speed;
	public float rotSpeed;

	public void Update()
	{
		Vector3 movFwd = transform.forward * Input.GetAxis ("Vertical");
		Vector3 movRight = transform.right * Input.GetAxis ("Horizontal");
		Vector3 totalMov = (movFwd + movRight) * speed;
		transform.position += totalMov * Time.deltaTime;

		float rotY = Input.GetAxis ("Mouse X") * rotSpeed * Time.deltaTime;
		transform.Rotate (0, rotY, 0);
	}
}
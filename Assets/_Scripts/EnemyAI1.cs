using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AI : MonoBehaviour 
{
	public enum Estados { Alejar, Acercar, Idle }

	public Estados estado;
	public Transform target;
	public float distanciaMinima;
	public float distanciaMaxima;
	public float velocidad;

	public void Update()
	{
		if (estado == Estados.Alejar) Alejar ();
		else if (estado == Estados.Acercar) Acercar();
		else if (estado == Estados.Idle) Idle();
	}

	public void Acercar()
	{
		float distanciaATarget = Vector3.Distance (transform.position, target.position);
		if (distanciaATarget > distanciaMaxima) 
		{
			Vector3 dir = Vector3.Normalize (target.position - transform.position);
			transform.position += dir * velocidad * Time.deltaTime;
		} 
		else 
		{
			estado = Estados.Idle;
		}
	}

	public void Alejar()
	{		
		float distanciaATarget = Vector3.Distance (transform.position, target.position);
		if (distanciaATarget < distanciaMinima) 
		{
			Vector3 dir = Vector3.Normalize (target.position - transform.position);
			transform.position += -dir * velocidad * Time.deltaTime;
		} 
		else 
		{
			estado = Estados.Idle;
		}
	}

	public void Idle()
	{	
		float distanciaATarget = Vector3.Distance (transform.position, target.position);
		if (distanciaATarget > distanciaMaxima) 
		{
			estado = Estados.Acercar;
		} 
		else if (distanciaATarget < distanciaMinima) 
		{
			estado = Estados.Alejar;
		}
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, distanciaMinima);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, distanciaMaxima);
	}
}
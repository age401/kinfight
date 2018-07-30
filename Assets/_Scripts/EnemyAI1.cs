using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI1 : MonoBehaviour 
{
	public enum States { Alejar, Acercar, Idle, Disparar }

	public States estado;
	public Transform target;
    
	public float distanciaMinima;
	public float distanciaMaxima;
	public float velocidad;

    public GameObject enemyWeapon;

    public void Update()
	{
		if (estado == States.Alejar) Alejar ();
		else if (estado == States.Acercar) Acercar();
		else if (estado == States.Idle) Idle();
        else if (estado == States.Disparar) Disparar();
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
			estado = States.Idle;
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
			estado = States.Idle;
		}
	}

	public void Idle()
	{	
		float distanciaATarget = Vector3.Distance (transform.position, target.position);
        if (distanciaATarget > distanciaMinima && distanciaATarget < distanciaMinima)
        {
            Disparar();
        }
		if (distanciaATarget > distanciaMaxima) 
		{
			estado = States.Acercar;
		} 
		else if (distanciaATarget < distanciaMinima) 
		{
			estado = States.Alejar;
		}
	}

    public void Disparar()
    {
        enemyWeapon.EnemyRifleHandler.FireWeapon();
    }

    // Gizmos Reference
	public void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, distanciaMinima);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere (transform.position, distanciaMaxima);
	}
}
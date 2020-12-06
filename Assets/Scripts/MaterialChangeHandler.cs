using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeHandler : MonoBehaviour
{

	public Transform playerLocation;
	private float distanceToGun;
	public Material MatA;
	public Material MatB;


	private void Update()
	{
		LerpMatUsingPos();
	}

	void LerpMatUsingPos()
	{
		Renderer gunRenderer = this.GetComponent<Renderer>();

		distanceToGun = Vector3.Distance(playerLocation.position, transform.position);
		//Debug.Log(distanceToGun);

		float matLerpValue = 4f / distanceToGun;

		// Lerp the color using and return the final value
		gunRenderer.material.Lerp(MatA, MatB, matLerpValue);
		Debug.Log(matLerpValue);
	}
}

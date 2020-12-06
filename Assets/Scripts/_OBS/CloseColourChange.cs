using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseColourChange : MonoBehaviour
{

	public Transform playerLocation2;
	private float distanceToGun2;
	public Color colorA;
	public Color colorB;


    private void Update()
    {
		LerpColorUsingPos();
	}

    void LerpColorUsingPos()
	{
		Renderer gunRenderer = this.GetComponent<Renderer>();

		distanceToGun2 = Vector3.Distance(playerLocation2.position, transform.position);
		//Debug.Log(distanceToGun);

		float lerpValue2 = 5f/distanceToGun2;

		// Lerp the color using and return the final value
		gunRenderer.material.color = Color.Lerp(colorA, colorB, lerpValue2);
		Debug.Log(lerpValue2);
	}
}

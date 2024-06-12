using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class DirectionFleche : MonoBehaviour
{
	public Transform objetCible;
	public float vitesseFleche;

	// Update is called once per frame
	void Update()
	{
		Vector3 positionRelative = objetCible.position - transform.position;

		Quaternion rotation = Quaternion.LookRotation(positionRelative, Vector3.up);
		transform.rotation = rotation;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVitesse : MonoBehaviour
{

	public Rigidbody vaisseauRb;
	public Text vitesseVaisseauText;

	private float vitesse;

	void FixedUpdate()
	{
		vitesse = vaisseauRb.velocity.magnitude;

	}

	// Update is called once per frame
	void Update()
	{
		vitesseVaisseauText.text = vitesse.ToString("F2") + "m/s";
	}
}

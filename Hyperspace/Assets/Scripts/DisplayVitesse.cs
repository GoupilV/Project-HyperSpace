using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayVitesse : MonoBehaviour
{

	public Rigidbody vaisseauRb;
	public TMP_Text vitesseVaisseauText;

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

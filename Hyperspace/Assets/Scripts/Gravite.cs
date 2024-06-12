using Unity.VisualScripting;
using UnityEngine;

public class Gravite : MonoBehaviour
{
	public Transform joueur;
	Rigidbody rbVaisseau;
	public float rangeGravite;
	public float intensiteGravite;
	public float multiGravite;
	public float factExpo = 3f;
	public float distanceMini = 1f;
	public float distanceJoueur;


	void Start()
	{
		rbVaisseau = joueur.GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		ForceGravitationelle();
	}
	void ForceGravitationelle()
	{
		distanceJoueur = Vector3.Distance(joueur.position, transform.position);
		if (distanceJoueur <= rangeGravite)
		{
			distanceJoueur = Mathf.Max(distanceJoueur, distanceMini);

			Vector3 direction = (transform.position - joueur.position).normalized;
			float magnitudeForce = (intensiteGravite / Mathf.Pow(distanceJoueur, factExpo)) * multiGravite;
			Vector3 forceAttraction = direction * magnitudeForce;
			rbVaisseau.AddForce(forceAttraction, ForceMode.Force);
		}
	}
}

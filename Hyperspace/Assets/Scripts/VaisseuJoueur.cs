using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class VaisseuJoueur : MonoBehaviour
{
	Rigidbody vaisseauRB;
	public float delaiRespawn = 3f;
	/*public ParticleSystem[] explosionParticules;*/




	// Inputs Joueur
	float mvVertical;
	float mvHorizontal;
	float inputSourisX;
	float inputSourisY;
	float inputRoll;

	// Multi vitesse
	[SerializeField]
	float multVitesse = 1;
	[SerializeField]
	float multVitesseAngle = 0.5f;
	[SerializeField]
	float multVitesseAngleRoll = 0.05f;

	[SerializeField]
	ParticleSystem[] exhaustParticleSystems;

	public AudioSource sonReacteur;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		vaisseauRB = GetComponent<Rigidbody>();

		if (exhaustParticleSystems == null || exhaustParticleSystems.Length == 0)
		{
			exhaustParticleSystems = GetComponentsInChildren<ParticleSystem>(true);
			exhaustParticleSystems = exhaustParticleSystems.Where(ps => !ps.gameObject.CompareTag("Explosion")).ToArray();
		}
		/*if (explosionParticules == null || explosionParticules.Length == 0)
		{
			explosionParticules = GetComponentsInChildren<ParticleSystem>(true);
			explosionParticules = explosionParticules.Where(ps => !ps.gameObject.CompareTag("Reacteur")).ToArray();

		}*/
	}

	// Update is called once per frame
	void Update()
	{
		mvVertical = Input.GetAxis("Vertical");
		mvHorizontal = Input.GetAxis("Horizontal");
		inputRoll = Input.GetAxis("Roll");

		inputSourisX = Input.GetAxis("Mouse X");
		inputSourisY = Input.GetAxis("Mouse Y");

		if (Input.GetKeyDown(KeyCode.M))
		{
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene("MenuPrincipal");
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		if (mvVertical > 0)
		{
			ActivateParticleSystems(exhaustParticleSystems);

			if (!sonReacteur.isPlaying)
			{
				sonReacteur.Play();
			}
		}
		else
		{
			DeactivateParticleSystems(exhaustParticleSystems);

			if (sonReacteur.isPlaying)
			{
				sonReacteur.Stop();
			}
		}
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Portal"))
		{
			return;
		}
		vaisseauRB.isKinematic = true;

		/*(explosionParticules);*/
		Debug.Log("Explosion triggered!");

		gameObject.SetActive(false);
		ReloadScene();

	}


	void FixedUpdate()
	{
		vaisseauRB.AddForce(vaisseauRB.transform.TransformDirection(Vector3.forward) * mvVertical * multVitesse, ForceMode.VelocityChange);

		vaisseauRB.AddForce(vaisseauRB.transform.TransformDirection(Vector3.right) * mvHorizontal * multVitesse, ForceMode.VelocityChange);

		vaisseauRB.AddTorque(vaisseauRB.transform.right * multVitesseAngle * inputSourisY * -1, ForceMode.VelocityChange);

		vaisseauRB.AddTorque(vaisseauRB.transform.up * multVitesseAngle * inputSourisX, ForceMode.VelocityChange);

		vaisseauRB.AddTorque(vaisseauRB.transform.forward * multVitesseAngleRoll * inputRoll, ForceMode.VelocityChange);
	}

	void ActivateParticleSystems(ParticleSystem[] particleSystems)
	{
		foreach (var ps in particleSystems)
		{
			if (!ps.isPlaying)
			{
				ps.Play();
			}
		}
	}

	void DeactivateParticleSystems(ParticleSystem[] particleSystems)
	{
		foreach (var ps in particleSystems)
		{
			if (ps.isPlaying)
			{
				ps.Stop();
			}
		}
	}
	private void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

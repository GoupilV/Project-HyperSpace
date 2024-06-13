using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionVaisseau : MonoBehaviour
{
	public GameObject explosion;
	public float delaiRespawn = 3f;
	private Rigidbody rbVaisseau;

	void Start()
	{
		rbVaisseau = GetComponent<Rigidbody>();
	}
	private void CollisionAction(Collision collision)
	{
		if (collision.gameObject.CompareTag("Portal"))
		{
			return;
		}

		Instantiate(explosion, transform.position, Quaternion.identity);

		rbVaisseau.isKinematic = true;

		gameObject.SetActive(false);

		Invoke("ReloadScene", delaiRespawn);
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}


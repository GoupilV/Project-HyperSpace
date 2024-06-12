using UnityEngine;

public class SpawnAsteroide : MonoBehaviour
{
	public GameObject asteroide;
	public int nbAsteroide;
	public float rayonSpawn = 10f;

	void Start()
	{
		SpawnRandom();
	}
	void SpawnRandom()
	{
		for (int i = 0; i < nbAsteroide; i++)
		{
			Vector3 posRandom = transform.position + Random.insideUnitSphere * rayonSpawn;
			Quaternion rotation = Random.rotation;
			Instantiate(asteroide, posRandom, rotation);
		}
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, rayonSpawn);
	}
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, rayonSpawn);
	}


}

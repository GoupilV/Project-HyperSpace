using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DistortionCamera : MonoBehaviour
{
	public Rigidbody rbVaisseau;
	public Volume postProcessVolume;
	private LensDistortion lensDistortion;

	public float seuilVitesse;
	public float distortionMax = 1f;
	public float disortionMin = 0f;
	void Start()
	{
		if (postProcessVolume.profile.TryGet(out LensDistortion lensDistor))
		{
			lensDistortion = lensDistor;
		}
		else
		{
			Debug.LogError("La lens distortion n'est pas présente");
		}

	}

	// Update is called once per frame
	void Update()
	{
		float vitesse = rbVaisseau.velocity.magnitude;
		float facteurDistortion = Mathf.Lerp(disortionMin, distortionMax, vitesse / seuilVitesse);

		if (lensDistortion != null)
		{
			lensDistortion.intensity.value = facteurDistortion;
		}
	}
}

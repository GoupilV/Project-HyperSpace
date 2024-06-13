using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerFinal : MonoBehaviour
{
	public GameObject panelVictoire;
	public GameObject canvasInterface;
	public TMP_Text tempsText;
	public string sceneACharger;
	private Timer timer;

	void Start()
	{
		timer = FindObjectOfType<Timer>();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Collision detected with: " + other.gameObject.name);
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player reached the end object!");
			timer.ArretTimer();
			canvasInterface.SetActive(false);
			panelVictoire.SetActive(true);
			AffichageTemps();
			StartCoroutine(ReloadScence(3f));
		}
	}
	void AffichageTemps()
	{
		float tempsPris = timer.TempsPris();

		int minutes = Mathf.FloorToInt(tempsPris / 60f);
		int secondes = Mathf.FloorToInt(tempsPris % 60f);
		int milliS = Mathf.FloorToInt((tempsPris * 100f) % 100f);
		tempsText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, secondes, milliS);
	}
	IEnumerator ReloadScence(float delai)
	{
		yield return new WaitForSeconds(delai);
		Cursor.lockState = CursorLockMode.None;
		SceneManager.LoadScene(sceneACharger);
	}
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerFinal : MonoBehaviour
{
	public GameObject panelVictoire;
	public GameObject canvasInterface;
	public TMP_Text tempsText;
	private Timer timer;
	void Start()
	{
		timer = FindObjectOfType<Timer>();
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("Player"))
		{
			timer.ArretTimer();
			canvasInterface.SetActive(false);
			panelVictoire.SetActive(true);
			AffichageTemps();
			Invoke("RoladScene", 5f);
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
	void ReloadScence()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}

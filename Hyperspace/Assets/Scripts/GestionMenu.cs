using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
	public TMP_Text output;
	private string scene;
	public string niveau1 = "Niveau1";
	public string niveau2 = "Niveau2";
	public string niveau3 = "Niveau3";

	public void HandleOutput(int valeur)
	{
		if (valeur == 0)
		{
			output.text = "1";
			scene = niveau1;
		}
		if (valeur == 1)
		{
			output.text = "2";
			scene = niveau2;
		}
		if (valeur == 2)
		{
			output.text = "3";
			scene = niveau3;
		}

	}

	public void LancerJeu(string scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void FermerJeu()
	{
		Application.Quit();

#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}

	void Update()
	{
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}

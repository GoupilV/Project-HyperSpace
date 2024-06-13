using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GestionChoix : MonoBehaviour
{
	public TMP_Dropdown niveauDropdown;
	private int indexChoix;
	// Start is called before the first frame update
	void Start()
	{
		indexChoix = niveauDropdown.value;
		niveauDropdown.onValueChanged.AddListener(DropdownValeurChangee);
	}
	void DropdownValeurChangee(int index)
	{
		indexChoix = index;
	}
	public void ChargeScene()
	{
		switch (indexChoix)
		{
			case 0:
				{
					SceneManager.LoadScene("Niveau1");
					break;
				}
			case 1:
				{
					SceneManager.LoadScene("Niveau2");
					break;
				}
			case 2:
				{
					SceneManager.LoadScene("Niveau3");
					break;
				}
			default:
				{
					Debug.LogError("Index invalide");
					break;
				}
		}
	}

}

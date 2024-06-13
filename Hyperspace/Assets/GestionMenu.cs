using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public TMP_Text output;
    public string niveau;

    public void HandleOutput(int valeur)
    {
        if(valeur == 0)
        {
            output.text = "1";
            niveau = = "SampleScene";
        }
        if(valeur == 1)
        {
            output.text = "2";
            niveau = "niveau2";
        }
        if (valeur == 2)
        {
            output.text = "3";
            niveau = "niveau3";
        }
    }

    public void LancerJeu()
    {
        SceneManager.LoadScene(niveau);
    }

    public void FermerJeu()
    {
        Application.Quit();
    }

    void  Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}

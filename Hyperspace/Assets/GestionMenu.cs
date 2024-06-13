using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public TMP_Text output;
    private string scene;
    public string sceneAchargerFacile;

    public void HandleOutput(int valeur)
    {
        if(valeur == 0)
        {
            output.text = "1";
            scene = sceneAchargerFacile;
        //    LancerJeu(scene);
        }
        if (valeur == 1)
        {
            output.text ="2";
            // scene = ;
        }
        if (valeur == 2)
        {
            output.text = "3";
            // scene = ;
        }

    }

    public void LancerJeu(string scene)
    {
        SceneManager.LoadScene(scene);
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

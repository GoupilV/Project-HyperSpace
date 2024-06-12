using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Button boutonJouer;
    public Canvas Interface;

    List<string> optionNiveau = new List<string> {"Facile", "Intermédiaire", "Difficile"};
    Dropdown choixNiveau;
    double vitesseFusee;


    // Start is called before the first frame update
    void Start()
    {
        // Récupérer le composant du DropDown choixNiveau
        choixNiveau = GetComponent<Dropdown>;

        // Effacer et mettre les nouvelles options de niveau dans le Dropdown
        choixNiveau.ClearOptions();
        choixNiveau.AddOptions(optionNiveau);

        //Ajouter un listener pour le changement de sélection
        choixNiveau.onValueChanged.AddListener(delegate{SelctionNiveau(choixNiveau);});

        // Ajouter un listener pour le bouton
        boutonJouer.onClick.AddListener(butClick);
    }

    void SelectionNiveau(DropDown niveauChoisi)
    {
        int index = niveauChoisi.value;
        string niveau = optionNiveau[index];

        if (niveau == "Facile")
        {
            Debug.Log("Niveau de difficulté sélectionné: Facile");


        }
        else if (niveau == "Intermédiaire")
        {
            Debug.Log("Niveau de difficulté sélectionné: Intermédiaire");
        }
        else if (niveau == "Difficile")
        {
            Debug.Log("Niveau de difficulté sélectionné: Difficile");
        }

    }

    void butClick()
    {
        // Rend l'interface invisible
        Interface.gameObject.SetActive(false);

        // Lancer le jeu
        //StartHyperSpace();
    }

    /*
    void StartHyperSapce()
    {
    Debug.Log("Le jeu commence !");
    }
    */

    // Update is called once per frame
    void Update()
    {
    
    }


}

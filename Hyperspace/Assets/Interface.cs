using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    List<string> optionNiveau = new List<string> {"Facile", "Intermédiaire", "Difficile"};
    Dropdown choixNiveau;

    // Start is called before the first frame update
    void Start()
    {
        choixNiveau = GetComponent<Dropdown>;
        choixNiveau.ClearOptions();
        choixNiveau.AddOptions(optionNiveau);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

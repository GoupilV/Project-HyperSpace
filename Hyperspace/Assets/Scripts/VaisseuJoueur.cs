using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaisseuJoueur : MonoBehaviour
{
    Rigidbody vaisseauRB;

    // Inputs Joueur
    float mvVertical;
    float mvHorizontal;
    float inputSourisX;
    float inputSourisY;
    float inputRoll;

    // Multi vitesse
    [SerializeField]
    float multVitesse = 1;
    [SerializeField]
    float multVitesseAngle = 0.5f;
    [SerializeField]
    float multVitesseAngleRoll = 0.05f;

    // Références aux systèmes de particules
    [SerializeField]
    ParticleSystem[] exhaustParticleSystems;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        vaisseauRB = GetComponent<Rigidbody>();

        // Vous pouvez obtenir les références aux systèmes de particules de différentes manières,
        // soit par un GetComponentsInChildren, soit en assignant directement depuis l'éditeur.
        if (exhaustParticleSystems == null || exhaustParticleSystems.Length == 0)
        {
            exhaustParticleSystems = GetComponentsInChildren<ParticleSystem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        mvVertical = Input.GetAxis("Vertical");
        mvHorizontal = Input.GetAxis("Horizontal");
        inputRoll = Input.GetAxis("Roll");

        inputSourisX = Input.GetAxis("Mouse X");
        inputSourisY = Input.GetAxis("Mouse Y");

        // Activer/désactiver les particules en fonction du mouvement vertical
        if (mvVertical > 0)
        {
            foreach (var ps in exhaustParticleSystems)
            {
                if (!ps.isPlaying)
                {
                    ps.Play();
                }
            }
        }
        else
        {
            foreach (var ps in exhaustParticleSystems)
            {
                if (ps.isPlaying)
                {
                    ps.Stop();
                }
            }
        }
    }

    void FixedUpdate()
    {
        vaisseauRB.AddForce(vaisseauRB.transform.TransformDirection(Vector3.forward) * mvVertical * multVitesse, ForceMode.VelocityChange);

        vaisseauRB.AddForce(vaisseauRB.transform.TransformDirection(Vector3.right) * mvHorizontal * multVitesse, ForceMode.VelocityChange);

        vaisseauRB.AddTorque(vaisseauRB.transform.right * multVitesseAngle * inputSourisY * -1, ForceMode.VelocityChange);

        vaisseauRB.AddTorque(vaisseauRB.transform.up * multVitesseAngle * inputSourisX, ForceMode.VelocityChange);

        vaisseauRB.AddTorque(vaisseauRB.transform.forward * multVitesseAngleRoll * inputRoll, ForceMode.VelocityChange);
    }
}

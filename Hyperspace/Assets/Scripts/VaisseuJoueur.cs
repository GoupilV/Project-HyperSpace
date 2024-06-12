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

    // Stocker les rotations initiales
    Quaternion[] initialRotations;

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

        // Initialiser les rotations initiales
        initialRotations = new Quaternion[exhaustParticleSystems.Length];
        for (int i = 0; i < exhaustParticleSystems.Length; i++)
        {
            initialRotations[i] = exhaustParticleSystems[i].transform.localRotation;
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
            ActivateParticleSystems(exhaustParticleSystems, Vector3.forward);
        }
        else if (mvVertical < 0)
        {
            ActivateParticleSystems(exhaustParticleSystems, Vector3.back);
        }
        else
        {
            DeactivateParticleSystems(exhaustParticleSystems);
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

    void ActivateParticleSystems(ParticleSystem[] particleSystems, Vector3 direction)
    {
        for (int i = 0; i < particleSystems.Length; i++)
        {
            var ps = particleSystems[i];
            if (!ps.isPlaying)
            {
                ps.Play();
            }

            // Ajuster l'orientation des particules
            if (direction == Vector3.forward)
            {
                ps.transform.localRotation = initialRotations[i];
            }
            else if (direction == Vector3.back)
            {
                ps.transform.localRotation = Quaternion.Euler(initialRotations[i].eulerAngles + new Vector3(0, 180, 0));
            }
        }
    }

    void DeactivateParticleSystems(ParticleSystem[] particleSystems)
    {
        foreach (var ps in particleSystems)
        {
            if (ps.isPlaying)
            {
                ps.Stop();
            }
        }
    }
}

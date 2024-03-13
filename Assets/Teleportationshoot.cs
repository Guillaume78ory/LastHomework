/*
using System.Collections.Generic;
using UnityEngine;

public class TargetTeleporter : MonoBehaviour
{
    public List<Transform> teleportLocations; // Définissez ceci dans l'éditeur Unity avec vos objets de points de téléportation

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet entrant en collision est une balle
        if (collision.gameObject.tag == "Bullet") // Assurez-vous que vos balles ont le tag "Bullet"
        {
            if (teleportLocations.Count > 0)
            {
                // Sélectionne aléatoirement un des points de téléportation
                int randomIndex = Random.Range(0, teleportLocations.Count);
                Transform selectedLocation = teleportLocations[randomIndex];

                // Téléporte la cible à la position sélectionnée
                this.transform.position = selectedLocation.position;
            }
        }
    }
}


*/

using System.Collections.Generic;
using UnityEngine;

public class TargetTeleporter : MonoBehaviour
{
    public List<Transform> teleportLocations; // Points de téléportation
    public GameObject congratulationsPanel; // Panneau de félicitations
    public AudioClip congratulationsSound; // Son de félicitations
    public int hitCount = 0; // Nombre de fois que la cible a été touchée
    private Vector3 originalPosition; // Position originale de la cible
    private AudioSource audioSource; // Source audio pour jouer le son

    // Initialisation
    void Start()
    {
        // Enregistrez la position originale de la cible
        originalPosition = transform.position;

        // Configurez l'audio source
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = congratulationsSound;
        audioSource.playOnAwake = false;
        congratulationsPanel.SetActive(false); // Assurez-vous que le panneau est désactivé au départ
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet entrant en collision a le tag "Bullet"
        if (collision.gameObject.tag == "Bullet")
        {
            hitCount++; // Incrémente le compteur de touches

            if (hitCount >= 30)
            {
                // Faites disparaître la cible et activez le panneau de félicitations
                gameObject.SetActive(false);
                congratulationsPanel.transform.position = originalPosition; // Positionnez le panneau là où la cible a été initialement placée
                congratulationsPanel.SetActive(true);
                audioSource.Play(); // Jouez le son de félicitations
            }
            else if (teleportLocations.Count > 0)
            {
                // Téléportez la cible si elle n'a pas encore été touchée 30 fois
                int randomIndex = Random.Range(0, teleportLocations.Count);
                Transform selectedLocation = teleportLocations[randomIndex];
                transform.position = selectedLocation.position;
            }
        }
    }
}




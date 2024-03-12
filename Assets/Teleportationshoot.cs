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



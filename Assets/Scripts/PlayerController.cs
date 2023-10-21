using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerShoot playerShoot; // Asigna el script PlayerShoot desde el Inspector
    private float vulnerabilityDuration = 4f;
    Collider other;


    private void Update()
    {
        if ((Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.RightControl)) && canShoot)
        {
            SwitchRole();
        }       
    }

    private void SwitchRole()
    {
        playerShoot = GetComponent<PlayerShoot>();
        playerShoot.SwitchShoot();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            if (canShoot == true)
            {
                SwitchRole();
            }
            else
            {

            }
        }
        else if (other.CompareTag("Player2"))
        {
            // Acciones para objetos relacionados con el jugador 2
        }
    }

    public void TakeDamage()
    {
        if (canShoot)
        {
            // Implementa aquí las acciones cuando el jugador recibe daño.
            // Por ejemplo, reducir la vida, mostrar una animación, etc.
            // Inicia el tiempo de vulnerabilidad.
            canShoot = false;
            vulnerabilityDuration = 4f;
        }
    }
}

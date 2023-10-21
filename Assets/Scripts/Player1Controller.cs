using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    private bool isVulnerable = true;
    private float vulnerabilityDuration = 4f;
    private bool hasTorch = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            // Acciones específicas para el jugador 1 cuando mantiene presionada la tecla G.
            // Implementa aquí lo que hace el jugador 1 con G.
        }

        if (Input.GetKeyDown(KeyCode.E) && !isVulnerable && !hasTorch)
        {
            // Acciones para cambiar de rol (recolectar la antorcha) cuando el jugador presiona E.
            // Implementa aquí las acciones del cambio de rol, como recoger la antorcha.
            // Restablece el tiempo de vulnerabilidad si es necesario.
            hasTorch = true;
            SwitchRole();
        }

        if (!isVulnerable)
        {
            // Resta el tiempo de vulnerabilidad.
            vulnerabilityDuration -= Time.deltaTime;

            if (vulnerabilityDuration <= 0)
            {
                // El jugador ya no está vulnerable.
                isVulnerable = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasTorch)
        {
            // Acciones para cambiar el objeto Torch cuando el jugador presiona Espacio y tiene la antorcha.
            // Implementa aquí las acciones del cambio de objeto.
            hasTorch = false;
        }
    }

    private void SwitchRole()
    {
        // Implementa aquí las acciones para cambiar de rol, como recoger la antorcha.
        // Restablece el tiempo de vulnerabilidad si es necesario.
        isVulnerable = false; // Para evitar el cambio de rol inmediato.
        vulnerabilityDuration = 4f; // Asegura que el jugador sea vulnerable durante el cambio.
    }

    public void TakeDamage()
    {
        if (isVulnerable)
        {
            // Implementa aquí las acciones cuando el jugador recibe daño.
            // Por ejemplo, reducir la vida, mostrar una animación, etc.
            // Inicia el tiempo de vulnerabilidad.
            isVulnerable = false;
            vulnerabilityDuration = 4f;
        }
    }
}

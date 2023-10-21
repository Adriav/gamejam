using System.Collections;
using System.Collections.Generic;
// Script Player2Controller.cs para el jugador 2
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private bool hasTorch = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            // Acciones específicas para el jugador 2 cuando mantiene presionada la tecla Control Derecho.
            // Implementa aquí lo que hace el jugador 2 con Control Derecho.
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasTorch)
        {
            // Acciones para cambiar el objeto Torch cuando el jugador presiona Espacio y tiene la antorcha.
            // Implementa aquí las acciones del cambio de objeto.
            hasTorch = false;
        }

        if (Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.G) && hasTorch)
        {
            // Verifica si ambos jugadores están presionando las teclas en simultáneo y tienen la antorcha.
            // Si es así, realiza el cambio de objeto Torch.
            hasTorch = false;
            // Implementa aquí las acciones del cambio de objeto.
        }
    }
}


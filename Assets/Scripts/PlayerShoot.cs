using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  public GameObject proyectilPrefab; // Asigna el prefab del proyectil en el Inspector
  public Transform puntoDeDisparo; // Punto de inicio del proyectil
  private float velocidadDisparo = 7f;
  private float cooldown = 1f;
  private float lastTime;
  void Update()
  {
    if (GetComponent<PlayerController>().canShoot && GetComponent<PlayerController>().isPlayer1)
    {
      if (Input.GetKeyDown(KeyCode.F) && ValidCooldown())
      {
        DispararProyectil();
      }
    }
    else if (GetComponent<PlayerController>().canShoot && !GetComponent<PlayerController>().isPlayer1)
    {
      if (Input.GetKeyDown(KeyCode.RightControl) && ValidCooldown())
      {
        DispararProyectil();
      }
    }
  }

  void DispararProyectil()
  {
    // Instanciar el proyectil prefab
    GameObject proyectil = Instantiate(proyectilPrefab, puntoDeDisparo.position, Quaternion.identity);

    // Configurar la velocidad del proyectil para que se mueva hacia la derecha
    Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(velocidadDisparo, 0f); // Ajusta la velocidad según tus necesidades
    lastTime = Time.time;
  }

  private bool ValidCooldown()
  {
    return Time.time - lastTime >= cooldown;
  }

  public void SwitchShoot()
  {
    GetComponent<PlayerController>().canShoot = !GetComponent<PlayerController>().canShoot;
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
  public GameObject proyectilPrefab; // Asigna el prefab del proyectil en el Inspector
  public Transform puntoDeDisparo; // Punto de inicio del proyectil
  private float velocidadDisparo = 7f;
  private bool canShoot = true;
  [SerializeField]
  private bool player1 = true;
  private float cooldown = 1f;
  private float lastTime;
  void Update()
  {
    if (canShoot && player1)
    {
      if (Input.GetKeyDown(KeyCode.F) && validCooldown())
      {
        DispararProyectil();
      }
    }
    else if (canShoot && !player1)
    {
      if (Input.GetKeyDown(KeyCode.RightControl) && validCooldown())
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

  private bool validCooldown()
  {
    return Time.time - lastTime >= cooldown;
  }
}
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
  public float tiempoVida = 3.0f; // Tiempo de vida del proyectil
  public float distanciaMaxima = 20.0f; // Distancia máxima antes de autodestruirse
  private float distanciaRecorrida = 0.0f;

  private void Start()
  {
    Destroy(gameObject, tiempoVida); // Destruir después de tiempoVida segundos
  }

  private void Update()
  {
    // Actualizar la distancia recorrida
    distanciaRecorrida += Time.deltaTime * GetComponent<Rigidbody2D>().velocity.magnitude;

    // Autodestrucción si se supera la distancia máxima
    if (distanciaRecorrida >= distanciaMaxima)
    {
      Destroy(gameObject);
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Enemy"))
    {
      Destroy(gameObject);
    }
  }
}

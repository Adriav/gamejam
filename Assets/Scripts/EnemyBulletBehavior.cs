using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    private float tiempoDeVida = 2f; // Tiempo de vida en segundos.;
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    [SerializeField] GameObject bullet;
    public float velocidadProyectil = 2f;
    private List<Vector2> direcciones = new List<Vector2>();
    private void Start()
    {
        Invoke("Explosion", tiempoDeVida);
        direcciones.Add(new Vector2(1, 0)); // Derecha
        direcciones.Add(new Vector2(1, 1)); // Derecha y arriba
        direcciones.Add(new Vector2(1, -1)); // Derecha y abajo
        direcciones.Add(new Vector2(0, 1)); // Arriba
        direcciones.Add(new Vector2(0, -1)); // Abajo
        direcciones.Add(new Vector2(-1, 1)); // Izquierda y arriba
        direcciones.Add(new Vector2(-1, 0)); // Izquierda
        direcciones.Add(new Vector2(-1, -1)); // Izquierda y abajo
    }



    void Explosion()
    {
        for (int i = 0; i < direcciones.Count; i++)
        {
            Vector2 direccion = direcciones[i];
            GameObject proyectil = Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            rb.velocity = direccion.normalized * velocidadProyectil;
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}

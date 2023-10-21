using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehavior : MonoBehaviour
{
    private float tiempoDeVida = 2.5f; // Tiempo de vida en segundos.;
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    private void Start()
    {
        Invoke("Explosion", tiempoDeVida);
    }



    void Explosion()
    {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in objetos)
        {
            Debug.Log(colisionador.gameObject.name);
           
             
               

            

        }

        Destroy(gameObject);

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}

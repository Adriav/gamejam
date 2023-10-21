using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{
   
    public GameObject proyectilPrefab;
    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos = 1.5f;
    private float tiempoParaSiguienteDisparo = 0f;

    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;
    // Start is called before the first frame update
    void Start()

    {
    


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Explosion();
        }
        

       /* if (Time.time >= tiempoParaSiguienteDisparo)
            {
                Disparar();
                tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
            
             }*/
    }

    void Disparar()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidadProyectil, 0);

    }

    void Explosion() {

        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);
        foreach (Collider2D colisionador in objetos) {
            Rigidbody2D rb = colisionador.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 direccion = colisionador.transform.position - transform.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb.AddForce(direccion * fuerzaFinal);
            
            }
        
        }

        Destroy(gameObject);
    
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }




}

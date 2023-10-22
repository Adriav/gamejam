using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparos : MonoBehaviour
{
    public Transform objetivo; 
    public GameObject proyectilPrefab; 
    public float velocidadProyectil = 5f; 
    public float tiempoEntreDisparos = 1.5f; 
    private float tiempoParaSiguienteDisparo = 0f;
    private AudioSource audioSource;

    private void Awake()
    {
        tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (objetivo != null)
        {    
            Vector2 direction = objetivo.position;         
            if (Time.time >= tiempoParaSiguienteDisparo)
            {                
                Disparar();
                tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
            }
        }
    }

    void Disparar()
    {
        if (objetivo != null)
        {
            audioSource.Play();
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            Vector2 direccionProyectil = (objetivo.position - transform.position).normalized;
            rb.velocity = direccionProyectil * velocidadProyectil;
            Destroy(proyectil, 5f);
        }
    }
}

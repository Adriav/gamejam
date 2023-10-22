using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparos : MonoBehaviour
{
    private Transform objetivo; 
    public GameObject proyectilPrefab; 
    public float velocidadProyectil = 5f; 
    public float tiempoEntreDisparos; 
    private float tiempoParaSiguienteDisparo = 0f;
    private AudioSource audioSource;
    private float MAX_TIME = 3f;
    private float MIN_TIME = 1.5f;
    private System.Random random = new System.Random();

    private void Awake()
    {
        tiempoEntreDisparos = (float)(random.NextDouble() * (MAX_TIME - MIN_TIME)) + MIN_TIME;
        tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        objetivo = GameManager.Instance.TorchPlayer;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos; // 2f
    private float tiempoParaSiguienteDisparo = 0f;
    private AudioSource audioSource;
    private float MAX_TIME = 4f;
    private float MIN_TIME = 2.5f;
    private System.Random random = new System.Random();

    private List<Vector2> direcciones = new List<Vector2>();


    private void Start()
    {
        tiempoEntreDisparos = (float)(random.NextDouble() * (MAX_TIME - MIN_TIME)) + MIN_TIME;
        direcciones.Add(new Vector2(-1, (float)0.1)); // Izquierda y arriba
        direcciones.Add(new Vector2(-1, 0)); // Izquierda
        direcciones.Add(new Vector2(-1, (float)-0.1)); // Izquierda y abajo
        tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Time.time >= tiempoParaSiguienteDisparo)
        {
            Disparar();
            tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        audioSource.Play();
        for (int i = 0; i < direcciones.Count; i++)
        {
            Vector2 direccion = direcciones[i];
            GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
            Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
            rb.velocity = direccion.normalized * velocidadProyectil;
            Destroy(proyectil, 5f);
        }
    }
}

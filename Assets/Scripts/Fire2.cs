using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{

    public GameObject proyectilPrefab;
    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos; // 4.5 a 6.5f
    private float tiempoParaSiguienteDisparo = 0f;
    private float tiempoRecarga; // tiempoEntreDisparos - 1
    [SerializeField] private float radio;
    private AudioSource audioSource;
    private float MAX_TIME = 6.5f;
    private float MIN_TIME = 4.5f;
    private System.Random random = new System.Random();

    void Start()
    {
        tiempoEntreDisparos = (float)(random.NextDouble() * (MAX_TIME - MIN_TIME)) + MIN_TIME;
        tiempoRecarga = tiempoEntreDisparos - 1;
        tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tiempoRecarga)
        {
            // Logica de hacer la animacion de preparacion
        }
        if (Time.time >= tiempoParaSiguienteDisparo)
        {
            Disparar();

            tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        audioSource.Play();
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidadProyectil, 0);
    }
}

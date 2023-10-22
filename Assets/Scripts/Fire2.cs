using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{

    public GameObject proyectilPrefab;
    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos = 6f;
    private float tiempoParaSiguienteDisparo = 0f;
    //public float tiempoDeVida = 0.1f; // Tiempo de vida en segundos.;
    [SerializeField] private float radio;
    private AudioSource audioSource;
    // private Transform spawnPoint;
    //  public Color nuevoColor = Color.red;
    private Animator animator;
    private bool isShoot = false;

    void Start()
    {
        // spawnPoint = transform;
        animator = GetComponent<Animator>();
        animator.SetBool("disparo", isShoot);
        tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tiempoParaSiguienteDisparo)
        {
            Disparar();
          
            tiempoParaSiguienteDisparo = Time.time + tiempoEntreDisparos;
        }

      
           Explode();
        
    }

    void Disparar()
    {
        animator.SetBool("disparo", isShoot);
        audioSource.Play();
        GameObject proyectil = Instantiate(proyectilPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidadProyectil, 0);
      

    }

    void Explode()
    {

        
    }

 

}

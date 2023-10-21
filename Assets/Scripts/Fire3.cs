using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public float velocidadProyectil = 5f;
    public float tiempoEntreDisparos = 1.5f;
    private float tiempoParaSiguienteDisparo = 0f;

    private List<Vector2> direcciones = new List<Vector2>();


    private void Start()
    {
       
        direcciones.Add(new Vector2(-1, (float)0.1)); // Izquierda y arriba
        direcciones.Add(new Vector2(-1, 0)); // Izquierda
        direcciones.Add(new Vector2(-1, (float)-0.1)); // Izquierda y abajo
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

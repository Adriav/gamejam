using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public int damageAmount = 1; // Cantidad de da�o que causa la bala.
    [SerializeField] private List<Behaviour> components;

    private void Start()
    {
        currentHealth = maxHealth;
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(damageAmount);
            Destroy(other.gameObject); // Destruye la bala al colisionar con el enemigo.
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void ActivateEnemy()
    {
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
    }
}


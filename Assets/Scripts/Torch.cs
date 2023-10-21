using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("Heat Values")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelSlashLoss;
    [SerializeField] private float fuelHitLoss;
    [SerializeField] private float fuelTimeLoss;

    [SerializeField] private float currentFuel;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentFuel = maxFuel;
    }

    void Update()
    {
        //Check if about to run out

        //Check if loses
        if (currentFuel <= 0)
        {
            GameManager.Instance.IsGameOver = true;
        }
        //Decrease the current heat
        currentFuel -= Time.deltaTime * fuelTimeLoss;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }

    public void DoSlash()
    {
        anim.SetTrigger("Slash");
        currentFuel -= fuelSlashLoss;
    }

    public void DoHit()
    {
        currentFuel -= fuelHitLoss;
    }
}

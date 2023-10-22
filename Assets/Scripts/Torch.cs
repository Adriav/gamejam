using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [Header("Fuel Values")]
    [SerializeField] private float maxFuel;
    [SerializeField] private float fuelSlashLoss;
    [SerializeField] private float fuelTimeLoss;
    [SerializeField] private float fuelHitValue;
    public float currentFuel;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentFuel = maxFuel;
    }

    void Update()
    {
        //Game is in a menu
        if (GameManager.Instance.IsPaused || GameManager.Instance.IsGameOver)
            return;
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
        if (other.CompareTag("EnemyBullet"))
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
        if (currentFuel > fuelHitValue)
            currentFuel = fuelHitValue;
        else
            GameManager.Instance.IsGameOver = true;
    }

    public void DoSwap(bool state)
    {
        currentFuel = maxFuel;
        SetVisible(state);
    }

    public void SetVisible(bool state)
    {
        GetComponent<SpriteRenderer>().enabled = state;
    }
}
